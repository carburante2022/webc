namespace carburanti.Util.Scraper
{
    internal static class Github
    {
        internal static void Download()
        {
            var json = Downloader.Download("https://raw.githubusercontent.com/carburante2022/webc/main/data.json");
            if (json.Contains("<!DOCTYPE html>") || string.IsNullOrEmpty(json)) return;
            try
            {
                var d = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.AllData>(json);
                if (d != null)
                    VariabiliGlobali.VarGlob.allData = d;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
