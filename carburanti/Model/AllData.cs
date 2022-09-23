using carburanti.Model.Dates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class AllData
    {
        public Dictionary<DateOnlyCustom, PrezziGiorno>? prezziGiornalieri;

        internal void AggiornaPrezzi(DateOnlyCustom dateOnly, PrezziGiorno prezziGiorno)
        {
            this.prezziGiornalieri ??= new Dictionary<DateOnlyCustom, PrezziGiorno>();
            this.prezziGiornalieri[dateOnly] = prezziGiorno;
        }

        internal Graph.Graph GetGraph()
        {
            return new Graph.Graph(this);
        }
    }
}
