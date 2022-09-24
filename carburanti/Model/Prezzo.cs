#region

using System.Globalization;
using carburanti.Model.Dates;
using Newtonsoft.Json;

#endregion

namespace carburanti.Model;

[Serializable]
[JsonObject(MemberSerialization.Fields)]
public class Prezzo
{
    private DateOnly dateOnly;
    public string? descCarburante;
    public DateOnlyCustom? dtComu;
    public long? idImpianto;
    public bool? isSelf;
    public decimal? prezzo;
    public TimeOnly? ttComu;

    public Prezzo()
    {
    }

    public Prezzo(dynamic record)
    {
        idImpianto = Convert.ToInt64(record.idImpianto);
        descCarburante = record.descCarburante;

        prezzo = decimal.Parse(record.prezzo, new NumberFormatInfo { NumberDecimalSeparator = "." });
        isSelf = record.isSelf == "1";
        string dt = record.dtComu;
        var d2 = dt.Split(" ");
        var d3 = d2[0].Split("/");
        var d4 = d2[1].Split(":");
        dateOnly = new DateOnly(Convert.ToInt32(d3[2]), Convert.ToInt32(d3[1]), Convert.ToInt32(d3[0]));
        dtComu = new DateOnlyCustom(dateOnly);
        ttComu = new TimeOnly(Convert.ToInt32(d4[0]), Convert.ToInt32(d4[1]), Convert.ToInt32(d4[2]));
    }
}