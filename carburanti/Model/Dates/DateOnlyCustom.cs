#region

using System.ComponentModel;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model.Dates;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
[TypeConverter(typeof(DateTimeCustomTypeConverter))]
public class DateOnlyCustom
{
    public readonly int day;
    public readonly int month;
    public readonly int year;

    public DateOnlyCustom(DateOnly dateOnly)
    {
        year = dateOnly.Year;
        month = dateOnly.Month;
        day = dateOnly.Day;
    }

    public DateOnlyCustom(string value)
    {
        var s = value.Split("-");
        year = Convert.ToInt32(s[0]);
        month = Convert.ToInt32(s[1]);
        day = Convert.ToInt32(s[2]);
    }

    public DateOnlyCustom(DateTime dateOnly)
    {
        year = dateOnly.Year;
        month = dateOnly.Month;
        day = dateOnly.Day;
    }

    public override string ToString()
    {
        return year + "-" + month + "-" + day;
    }

    public string ToString(string sep)
    {
        return year + sep + month + sep + day;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DateOnlyCustom dt) return false;
        return year == dt.year && month == dt.month && day == dt.day;
    }

    public override int GetHashCode()
    {
        return year.GetHashCode() ^ month.GetHashCode() ^ day.GetHashCode();
    }
}