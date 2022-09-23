using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class Groups
    {
       public  List<GroupGraph>? list;

        internal GroupGraph? GetNewGroup(Prezzo i2)
        {
            this.list ??= new List<GroupGraph>();

            var max = this.list.Count == 0 ? 1 : (this.list.Max(x => x.idInt) + 1);

            if (i2.dtComu == null) return null;
            GroupGraph groupGraph = new(id: max, idImpianto: i2.idImpianto, i2.descCarburante, i2.isSelf);
            this.list.Add(groupGraph);
            return groupGraph;
        }
    }
}
