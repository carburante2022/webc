using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model.Dates
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class DateOnlyCustom
    {
        public int year;
        public int month;
        public int day;

        public DateOnlyCustom(DateOnly dateOnly)
        {
            this.year = dateOnly.Year;
            this.month = dateOnly.Month;
            this.day = dateOnly.Day;
        }

        public override string ToString() {
            return this.year.ToString() + "-" + this.month.ToString() + "-" + this.day.ToString();
        }
    }
}
