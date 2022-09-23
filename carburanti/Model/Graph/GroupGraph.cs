using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class GroupGraph
    {
        internal long? idImpianto;
#pragma warning disable IDE0052 // Rimuovi i membri privati non letti
        // ReSharper disable once InconsistentNaming
        private readonly string? content;
#pragma warning restore IDE0052 // Rimuovi i membri privati non letti
        internal string id;
        internal int idInt;
        internal string? descCarburante;
        internal bool? isSelf;

        public GroupGraph(int id, long? idImpianto, string? descCarburante, bool? isSelf)
        {
            this.idInt = id;
            this.id = idInt.ToString();
            this.idImpianto = idImpianto;
            this.content = idImpianto.ToString() ?? "xxx";
            this.descCarburante = descCarburante;
            this.isSelf = isSelf;
        }
    }
}