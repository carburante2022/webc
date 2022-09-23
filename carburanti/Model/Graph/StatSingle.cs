using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class StatSingle
    {
        public  Dictionary<string, Dictionary<bool, List<Prezzo>>> itemsGrouped = new();
        public  Dictionary<string, Dictionary<bool, Prezzo>> summary = new();


        internal void Calcola(KeyValuePair<DateOnlyCustom, PrezziGiorno> i10)
        {
            foreach (Prezzo i2 in i10.Value.prezzi)
            {
                if (string.IsNullOrEmpty(i2.descCarburante) == false && i2.isSelf != null)
                {


                    if (!itemsGrouped.ContainsKey(i2.descCarburante))
                    {
                        itemsGrouped[i2.descCarburante] = new();
                    }

                    if (!itemsGrouped[i2.descCarburante].ContainsKey(i2.isSelf.Value))
                    {
                        itemsGrouped[i2.descCarburante][i2.isSelf.Value] = new List<Prezzo>();
                    }

                    itemsGrouped[i2.descCarburante][i2.isSelf.Value].Add(i2);



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
                                Prezzo p = new()
                                {
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

        internal Dictionary<string, Dictionary<bool, Prezzo>>? GetStat()
        {
            return this.summary;
        }
    }
}