using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class GroupGraph
    {
        internal long? idImpianto;
        internal int id;

        public GroupGraph(int id, long? idImpianto)
        {
            this.id = id;
            this.idImpianto = idImpianto;
        }
    }
}