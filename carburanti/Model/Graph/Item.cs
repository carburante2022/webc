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
        public bool valid = false;

        public Item()
        {

        }

        public Item(Prezzo i2, int groupId)
        {
            this.group = groupId;
            if (i2.dtComu == null || i2.prezzo == null)
                this.valid = false;
            else
            {
                this.valid = true;
                this.x = i2.dtComu.Value.Year.ToString() + "-" + i2.dtComu.Value.Month.ToString() + "-" + i2.dtComu.Value.Day.ToString();
                this.y = i2.prezzo.Value;
            }
        }
    }
}