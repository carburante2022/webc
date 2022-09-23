using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class GroupGraph
    {
        internal long? idImpianto;
#pragma warning disable IDE0052 // Rimuovi i membri privati non letti
        private readonly string? content;
#pragma warning restore IDE0052 // Rimuovi i membri privati non letti
        internal int id;
        internal string? descCarburante;
        internal bool? isSelf;

        public GroupGraph(int id, long? idImpianto, string? descCarburante, bool? isSelf)
        {
            this.id = id;
            this.idImpianto = idImpianto;
            this.content = idImpianto.ToString() ?? "xxx";
            this.descCarburante = descCarburante;
            this.isSelf = isSelf;
        }
    }
}