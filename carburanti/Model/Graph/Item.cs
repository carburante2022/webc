using Newtonsoft.Json;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class Item
    {
        public string? x;
        public decimal y;
        public int group;
        public bool valid;

        public Item()
        {

        }

        public Item(Prezzo i2, int groupId, Dates.DateOnlyCustom dtComu)
        {
            this.group = groupId;
            if (i2.dtComu == null || i2.prezzo == null)
                this.valid = false;
            else
            {
                this.valid = true;
                this.x = dtComu.ToString();
                this.y = i2.prezzo.Value;
            }
        }
    }
}