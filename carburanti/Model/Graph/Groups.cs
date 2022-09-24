#region

using Newtonsoft.Json;

#endregion

namespace carburanti.Model.Graph;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
internal class Groups
{
    public List<GroupGraph>? list;

    internal GroupGraph? GetNewGroup(Prezzo i2)
    {
        list ??= new List<GroupGraph>();

        var max = list.Count == 0 ? 1 : list.Max(x => x.idInt) + 1;

        if (i2.dtComu == null) return null;
        GroupGraph groupGraph = new(max, i2.idImpianto, i2.descCarburante, i2.isSelf);
        list.Add(groupGraph);
        return groupGraph;
    }
}