using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class Graph
    {
        private AllData allData;
        private Items items = new Items();
        private Groups groups = new Groups();

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
                    foreach (Prezzo i2 in i.Value.prezzi)
                    {
                        int groupId = GetGroupAndCreateIt(i2);
                        this.items.Aggiungi(i2, groupId);
                    }
                }
            }
        }

        private int GetGroupAndCreateIt(Prezzo i2)
        {
            this.groups.list ??= new List<GroupGraph>();
            foreach (var x in this.groups.list)
            {
                if (i2.idImpianto == x.idImpianto)
                {
                    return x.id;
                }
            }

            GroupGraph groupGraph = this.groups.GetNewGroup(i2);
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