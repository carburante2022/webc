using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class Graph
    {
        private readonly AllData allData;
        private readonly Items items = new();
        private readonly Groups groups = new();
        public StatsAll StatsAll = new();


        public Graph(AllData allData)
        {
            this.allData = allData;
            this.GenerateItemsAndGroups();
        }

        private void GenerateItemsAndGroups()
        {
            if (allData.prezziGiornalieri == null)
                return;

            foreach (KeyValuePair<DateOnlyCustom, PrezziGiorno> i in allData.prezziGiornalieri)
            {
                if (i.Value.prezzi != null)
                {
                    StatsAll.Calcola(i);
                }
            }



            foreach (KeyValuePair<DateOnlyCustom, PrezziGiorno> i7 in allData.prezziGiornalieri)
            {
                var x8 = StatsAll.GetStats(i7.Key);
                if (x8 != null)
                {
                    foreach (KeyValuePair<string, Dictionary<bool, Prezzo>> i in x8 )
                    {
                        if (i.Value != null)
                        {
                            foreach (KeyValuePair<bool, Prezzo> i3 in i.Value)
                            {
                                var i2 = i3.Value;

                                if (string.IsNullOrEmpty(i2.descCarburante) == false && i2.isSelf != null)
                                {
                                    int? groupId = GetGroupAndCreateIt(i2);
                                    if (groupId != null)
                                        this.items.Aggiungi(i2, groupId.Value, i7.Key);
                                }
                            }
                        }
                    }
                }
            }
        }

    

        private int? GetGroupAndCreateIt(Prezzo i2)
        {
            this.groups.list ??= new List<GroupGraph>();
            foreach (GroupGraph x in this.groups.list)
            {
                if (i2.descCarburante == x.descCarburante && i2.isSelf == x.isSelf)
                {
                    return x.id;
                }
            }

            GroupGraph? groupGraph = this.groups.GetNewGroup(i2);
            if (groupGraph == null)
                return null;

            return groupGraph.id;
        }

        internal Groups GetGroups()
        {
            return this.groups;
        }

        internal Items GetItems()
        {
            return this.items;
        }
    }
}