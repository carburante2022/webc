using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model.Dates
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    [TypeConverter(typeof(DateTimeCustomTypeConverter))]
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

        public DateOnlyCustom(string value)
        {
            var s = value.Split("-");
            this.year = Convert.ToInt32(s[0]);
            this.month = Convert.ToInt32(s[1]);
            this.day = Convert.ToInt32(s[2]);
        }

        public override string? ToString() {
            return this.year.ToString() + "-" + this.month.ToString() + "-" + this.day.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj is DateOnlyCustom dt)
            {
                if (this.year == dt.year && this.month == dt.month && this.day == dt.day)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.year.GetHashCode() ^ this.month.GetHashCode() ^ this.day.GetHashCode();
        }
    }
}
