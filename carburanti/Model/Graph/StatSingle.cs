using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class StatSingle
    {
        public  Dictionary<string, Dictionary<bool, List<Prezzo>?>> itemsGrouped = new();
        public  Dictionary<string, Dictionary<bool, Prezzo>> summary = new();


        internal void Calcola(KeyValuePair<DateOnlyCustom, PrezziGiorno> i10)
        {
            var valuePrezzi = i10.Value.prezzi;
            if (valuePrezzi != null)
                foreach (var i2 in valuePrezzi.Where(i2 => string.IsNullOrEmpty(i2.descCarburante) == false && i2.isSelf != null))
                {
                    if (i2.descCarburante != null && !itemsGrouped.ContainsKey(i2.descCarburante))
                    {
                        itemsGrouped[i2.descCarburante] = new Dictionary<bool, List<Prezzo>?>();
                    }

                    if (i2.isSelf != null && i2.descCarburante != null && !itemsGrouped[i2.descCarburante].ContainsKey(i2.isSelf.Value))
                    {
                        itemsGrouped[i2.descCarburante][i2.isSelf.Value] = new List<Prezzo>();
                    }

                    if (i2.descCarburante == null || i2.isSelf == null) continue;
                    var prezzos = itemsGrouped[i2.descCarburante][i2.isSelf.Value];
                    prezzos?.Add(i2);
                }

            foreach (var i in itemsGrouped)
            {
                foreach (var i3 in i.Value)
                {
                    var i2 = i3.Value;
                    var avg = MediaPrezzo(i2);

                    if (avg == null) continue;
                    if (i2 == null) continue;
                    
                    var prezzo = i2[0];
                    var prezzoDescCarburante = prezzo.descCarburante;
                    if (prezzoDescCarburante != null && !summary.ContainsKey(prezzoDescCarburante))
                    {
                        summary[prezzoDescCarburante] = new Dictionary<bool, Prezzo>();
                    }

                    var prezzoIsSelf = prezzo.isSelf;
                    if (prezzoIsSelf == null || prezzoDescCarburante == null ||
                        summary[prezzoDescCarburante].ContainsKey(prezzoIsSelf.Value)) continue;
                    
                    Prezzo p = new()
                    {
                        descCarburante = prezzoDescCarburante,
                        prezzo = avg.Value,
                        isSelf = prezzoIsSelf,
                        idImpianto = prezzo.idImpianto,
                        dtComu = prezzo.dtComu,
                        ttComu = prezzo.ttComu
                    };
                    summary[prezzoDescCarburante][prezzoIsSelf.Value] = p;
                }
            }
        }

        private static decimal? MediaPrezzo(IReadOnlyCollection<Prezzo>? i2)
        {
            if (i2 == null || i2.Count == 0)
                return null;

            decimal total = 0;
            var count = 0;
            foreach (var i3 in i2.Where(i3 => i3.prezzo != null))
            {
                if (i3.prezzo == null) continue;
                
                total += i3.prezzo.Value;
                count++;
            }
            return total / count;
        }

        internal Dictionary<string, Dictionary<bool, Prezzo>>? GetStat()
        {
            return this.summary;
        }
    }
}