#region

using carburanti.Model.Dates;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model.Graph;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
internal class Items
{
    public List<Item>? items;

    internal void Aggiungi(Prezzo i2, int groupId, DateOnlyCustom dtComu)
    {
        items ??= new List<Item>();
        Item item = new(i2, groupId, dtComu);
        if (item.valid)
            items.Add(item);
    }
}