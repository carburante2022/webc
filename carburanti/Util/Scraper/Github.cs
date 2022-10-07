#region

using carburanti.Model;
using carburanti.Model.Dates;
using carburanti.VariabiliGlobali;
using Newtonsoft.Json;

#endregion

namespace carburanti.Util.Scraper;

internal static class Github
{
    internal static void Download()
    {
        Download2(""); // data.json is stored
        
        var start = new DateTime(2022, 9, 22);
        var today = DateTime.Now;
        while (true)
        {
            var dateOnlyCustom = (new DateOnlyCustom(start));
            var s = dateOnlyCustom.ToString("_");
            Download2(s);
            
            if (start.Year == today.Year && start.Month == today.Month && start.Day == today.Day)
            {
                return;
            }
            
            start = start.AddDays(1);
        }
    }

    private static void Download2(string s)
    {
        var path = "https://raw.githubusercontent.com/carburante2022/webc/main/data/data";
        path += s;
        path += ".json";
        var json = Downloader.Download(path);
        if (json.Contains("<!DOCTYPE html>") || string.IsNullOrEmpty(json)) return;
        try
        {
            var d = JsonConvert.DeserializeObject<AllData>(json);
            if (d != null)
                VarGlob.allData = d;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}