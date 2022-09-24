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
}