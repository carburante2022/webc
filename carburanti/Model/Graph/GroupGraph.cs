#region

using Newtonsoft.Json;

#endregion

namespace carburanti.Model.Graph;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
internal class GroupGraph
{
#pragma warning disable IDE0052 // Rimuovi i membri privati non letti
    // ReSharper disable once InconsistentNaming
    private readonly string? content;
#pragma warning restore IDE0052 // Rimuovi i membri privati non letti
    internal string? descCarburante;
    internal string id;
    internal long? idImpianto;
    internal int idInt;
    internal bool? isSelf;

    public GroupGraph(int id, long? idImpianto, string? descCarburante, bool? isSelf)
    {
        idInt = id;
        this.id = idInt.ToString();
        this.idImpianto = idImpianto;
        this.descCarburante = descCarburante;
        this.isSelf = isSelf;
        content = GetContent();
    }

    private string GetContent()
    {
        var r = "";

        if (isSelf != null)
            r += isSelf.Value ? "[self]" : "[noself]";
        r += " ";

        if (!string.IsNullOrEmpty(descCarburante))
            r += descCarburante;

        r = r.Trim();
        return string.IsNullOrEmpty(r) ? "xxx" : r;
    }
}