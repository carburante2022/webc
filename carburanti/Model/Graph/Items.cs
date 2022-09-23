using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class Items
    {
        public List<Item>? items;

        internal void Aggiungi(Prezzo i2, int groupId, Dates.DateOnlyCustom dtComu)
        {
            this.items ??= new List<Item>();
            Item item = new(i2, groupId, dtComu);
            if (item.valid)
                this.items.Add(item);
        }
    }
}
