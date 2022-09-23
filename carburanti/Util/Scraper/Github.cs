using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Util.Scraper
{
    internal static class Github
    {
        internal static void Download()
        {
            var json = carburanti.Util.Downloader.Download("https://raw.githubusercontent.com/carburante2022/webc/main/data.json");
            if (json.Contains("<!DOCTYPE html>") || string.IsNullOrEmpty(json)) return;
            try
            {
                var d = Newtonsoft.Json.JsonConvert.DeserializeObject<carburanti.Model.AllData>(json);
                if (d != null)
                    carburanti.VariabiliGlobali.VarGlob.allData = d;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
