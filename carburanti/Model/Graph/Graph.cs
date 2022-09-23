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

            foreach (var i in allData.prezziGiornalieri.Where(i => i.Value.prezzi != null))
            {
                StatsAll.Calcola(i);
            }



            foreach (var i7 in allData.prezziGiornalieri)
            {
                var x8 = StatsAll.GetStats(i7.Key);
                if (x8 == null) continue;
                foreach (var i in x8 )
                {
                    foreach (var i3 in i.Value)
                    {
                        var i2 = i3.Value;

                        if (string.IsNullOrEmpty(i2.descCarburante) != false || i2.isSelf == null) continue;
                        var groupId = GetGroupAndCreateIt(i2);
                        if (groupId != null)
                            this.items.Aggiungi(i2, groupId.Value, i7.Key);
                    }
                }
            }
        }

    

        private int? GetGroupAndCreateIt(Prezzo i2)
        {
            this.groups.list ??= new List<GroupGraph>();
            foreach (var x in this.groups.list.Where(x => i2.descCarburante == x.descCarburante && i2.isSelf == x.isSelf))
            {
                return x.id;
            }

            var groupGraph = this.groups.GetNewGroup(i2);

            return groupGraph?.id;
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