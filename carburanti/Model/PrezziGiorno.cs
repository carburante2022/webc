using carburanti.Model.Dates;
using Newtonsoft.Json;

namespace carburanti.Model
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class PrezziGiorno
    {
        public List<Prezzo>? prezzi;
        public DateOnlyCustom? dateOnly;

        public PrezziGiorno()
        {

        }

        public PrezziGiorno(DateOnlyCustom dateOnly)
        {
            this.dateOnly = dateOnly;
            this.prezzi = new List<Prezzo>();
        }

        internal void Aggiungi(Prezzo prezzo)
        {
            var inserito = InseritoBool(prezzo);
            if (inserito) return;
            this.prezzi ??= new List<Prezzo>();
            this.prezzi.Add(prezzo);
        }

        private bool InseritoBool(Prezzo prezzo)
        {
            return prezzi != null && this.prezzi.Any(x => x.idImpianto == prezzo.idImpianto);
        }
    }
}
