#region

using carburanti.Model.Dates;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model.Graph;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
public class Item
{
    public string? group;
    public int groupInt;
    public bool valid;
    public string? x;
    public decimal y;

    public Item()
    {
    }

    public Item(Prezzo i2, int groupId, DateOnlyCustom dtComu)
    {
        groupInt = groupId;
        group = groupId.ToString();
        if (i2.dtComu == null || i2.prezzo == null)
        {
            valid = false;
        }
        else
        {
            valid = true;
            x = dtComu.ToString();
            y = i2.prezzo.Value;
        }
    }
}