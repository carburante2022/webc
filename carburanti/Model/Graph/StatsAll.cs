using carburanti.Model.Dates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class StatsAll
    {
        public Dictionary<DateOnlyCustom, StatSingle>? stats;

        internal void Calcola(KeyValuePair<DateOnlyCustom, PrezziGiorno> i)
        {
            stats ??= new Dictionary<DateOnlyCustom, StatSingle>();
            if (!stats.ContainsKey(i.Key))
            {
                stats[i.Key] = new StatSingle();
            }

            stats[i.Key].Calcola(i);

            
        }

        internal Dictionary<string, Dictionary<bool, Prezzo>>? GetStats(DateOnlyCustom key)
        {
            this.stats ??= new Dictionary<DateOnlyCustom, StatSingle>();
            if (this.stats.ContainsKey(key))
                return this.stats[key].GetStat();

            return null;
        }

   
    }
}
