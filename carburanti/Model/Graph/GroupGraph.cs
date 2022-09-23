using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class GroupGraph
    {
        internal long? idImpianto;
        private string content;
        internal int id;

        public GroupGraph(int id, long? idImpianto, DateOnlyCustom dateOnlyCustom)
        {
            this.id = id;
            this.idImpianto = idImpianto;
            this.content = dateOnlyCustom.ToString();
        }
    }
}