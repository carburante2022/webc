using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class Prezzo
    {
        public long? idImpianto;
        public string? descCarburante;
        public decimal? prezzo;
        public bool? isSelf;
        public DateOnly? dtComu;
        public TimeOnly? ttComu;

        public Prezzo(dynamic record)
        {
            ;

            this.idImpianto = Convert.ToInt64( record.idImpianto);
            ;
            this.descCarburante = record.descCarburante;

            this.prezzo = decimal.Parse(record.prezzo, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            this.isSelf = record.isSelf == "1";
            string dt = record.dtComu;
            ;
            var d2 = dt.Split(" ");
            ;
            var d3 = d2[0].Split("/");
            var d4 = d2[1].Split(":");
            ;
            this.dtComu = new DateOnly(Convert.ToInt32(d3[2]), Convert.ToInt32(d3[1]), Convert.ToInt32(d3[0]));
            this.ttComu = new TimeOnly(Convert.ToInt32(d4[0]), Convert.ToInt32(d4[1]), Convert.ToInt32(d4[2]));
            ;
        }
    }
}
