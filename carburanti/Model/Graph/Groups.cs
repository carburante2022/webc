using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model.Graph
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    internal class Groups
    {
       public  List<GroupGraph>? list;

        internal GroupGraph GetNewGroup(Prezzo i2)
        {
            this.list ??= new List<GroupGraph>();

            int max = this.list.Count == 0 ? 1 : (this.list.Max(x => x.id) + 1);

            GroupGraph groupGraph = new(id: max, i2.idImpianto);
            return groupGraph;
        }
    }
}
