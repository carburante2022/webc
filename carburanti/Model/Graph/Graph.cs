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
        private readonly Dictionary<string, Dictionary<bool, List<Prezzo>>> itemsGrouped = new();
        private readonly Dictionary<string, Dictionary<bool, Prezzo>> summary = new();

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
                        if (string.IsNullOrEmpty(i2.descCarburante) == false && i2.isSelf != null)
                        {
                            if (!itemsGrouped.ContainsKey(i2.descCarburante))
                            {
                                itemsGrouped[i2.descCarburante] = new();
                            }

                            if (!itemsGrouped[i2.descCarburante].ContainsKey(i2.isSelf.Value)) {
                                itemsGrouped[i2.descCarburante][i2.isSelf.Value] = new List<Prezzo>();
                            }

                            itemsGrouped[i2.descCarburante][i2.isSelf.Value].Add(i2);



                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<bool, List<Prezzo>>> i in itemsGrouped)
            {
                if (i.Value != null)
                {
                    foreach (KeyValuePair<bool, List<Prezzo>> i3 in i.Value)
                    {
                        List<Prezzo> i2 = i3.Value;
                        decimal? avg = MediaPrezzo(i2);

                        if (avg != null)
                        {


                            if (!summary.ContainsKey(i2[0].descCarburante))
                            {
                                summary[i2[0].descCarburante] = new();
                            }

                            if (!summary[i2[0].descCarburante].ContainsKey(i2[0].isSelf.Value))
                            {
                                Prezzo p = new() {
                                    descCarburante = i2[0].descCarburante,
                                    prezzo = avg.Value,
                                     isSelf = i2[0].isSelf,
                                      idImpianto = i2[0].idImpianto,
                                       dtComu = i2[0].dtComu,
                                        ttComu = i2[0].ttComu 
                                };
                                summary[i2[0].descCarburante][i2[0].isSelf.Value] = p;
                            }
                        }
                    }
                }
            }


            foreach (KeyValuePair<string, Dictionary<bool, Prezzo>> i in summary)
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
                                this.items.Aggiungi(i2, groupId.Value);
                        }
                    }
                }
            }
        }

        private static decimal? MediaPrezzo(List<Prezzo> i2)
        {
            if (i2 == null || i2.Count == 0)
                return null;

            decimal total = 0;
            int count = 0;
            foreach (var i3 in i2)
            {
                if (i3.prezzo != null)
                {
                    total += i3.prezzo.Value;
                    count++;
                }
            }
            return total / count;
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