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
            this.descCarburante = descCarburante;
            this.isSelf = isSelf;
            this.content = GetContent();
        }

        private string? GetContent()
        {
            var r = "";

            if (this.isSelf != null)
                r += this.isSelf.Value ? "[self]" : "[noself]";
            r += " ";

            if (!string.IsNullOrEmpty(descCarburante))
                r += descCarburante;

            r = r.Trim();
            return string.IsNullOrEmpty(r) ? "xxx" : r;
        }
    }
}