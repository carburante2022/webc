#region

using carburanti.Model.Dates;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
public class AllData
{
    public Dictionary<DateOnlyCustom, PrezziGiorno>? prezziGiornalieri;

    internal void AggiornaPrezzi(DateOnlyCustom dateOnly, PrezziGiorno prezziGiorno)
    {
        prezziGiornalieri ??= new Dictionary<DateOnlyCustom, PrezziGiorno>();
        prezziGiornalieri[dateOnly] = prezziGiorno;
    }

    internal Graph.Graph GetGraph()
    {
        return new Graph.Graph(this);
    }

    public Dictionary<DateOnlyCustom, AllData> GetDatasSplittedInDays()
    {
        var r = new Dictionary<DateOnlyCustom, AllData>();
        if (prezziGiornalieri == null)
            return r;
        
        foreach (var key in prezziGiornalieri.Keys)
        {
            var x = new AllData();
            x.AggiornaPrezzi(key, prezziGiornalieri[key]);
            r[key] = x;
        }

        return r;
    }
}