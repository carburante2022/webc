#region

using carburanti.Model.Dates;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
public class PrezziGiorno
{
    public DateOnlyCustom? dateOnly;
    public List<Prezzo>? prezzi;

    public PrezziGiorno()
    {
    }

    public PrezziGiorno(DateOnlyCustom dateOnly)
    {
        this.dateOnly = dateOnly;
        prezzi = new List<Prezzo>();
    }

    internal void Aggiungi(Prezzo prezzo)
    {
        var inserito = InseritoBool(prezzo);
        if (inserito) return;
        prezzi ??= new List<Prezzo>();
        prezzi.Add(prezzo);
    }

    private bool InseritoBool(Prezzo prezzo)
    {
        return prezzi != null && prezzi.Any(x => x.idImpianto == prezzo.idImpianto);
    }
}