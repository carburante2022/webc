#region

using carburanti.Model.Dates;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model.Graph;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
internal class StatsAll
{
    public Dictionary<DateOnlyCustom, StatSingle>? stats;

    internal void Calcola(KeyValuePair<DateOnlyCustom, PrezziGiorno> i)
    {
        stats ??= new Dictionary<DateOnlyCustom, StatSingle>();
        if (!stats.ContainsKey(i.Key)) stats[i.Key] = new StatSingle();

        stats[i.Key].Calcola(i);
    }

    internal Dictionary<string, Dictionary<bool, Prezzo>>? GetStats(DateOnlyCustom key)
    {
        stats ??= new Dictionary<DateOnlyCustom, StatSingle>();
        return stats.ContainsKey(key) ? stats[key].GetStat() : null;
    }
}