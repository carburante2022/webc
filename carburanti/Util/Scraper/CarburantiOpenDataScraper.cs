using CsvHelper;
using System.Globalization;
using carburanti.Model;
using carburanti.Model.Dates;

namespace carburanti.Util.Scraper
{
    internal static class CarburantiOpenDataScraper
    {
        public static void Download()
        {
            const string url = "https://www.mise.gov.it/images/exportCSV/prezzo_alle_8.csv";
            var r = Downloader.Download(url);
            var firstNewLine = r.IndexOf('\n');
            var data = r[..firstNewLine].Trim();
            var dateOnly = GetDateEstratto(data);
            var recordsString = r[firstNewLine..].Trim();

            var m = Memory.GenerateStreamFromString(recordsString);

            using var reader = new StreamReader(m);
            using var csv = new CsvReader(reader, CultureInfo.GetCultureInfoByIetfLanguageTag("it"));
            var records = csv.GetRecords<dynamic>().ToList();
            var prezziGiorno = new PrezziGiorno(dateOnly);
            foreach (var prezzo in records.Select(record => new Prezzo(record)))
            {
                prezziGiorno.Aggiungi(prezzo);
            }
            VariabiliGlobali.VarGlob.allData ??= new AllData();
            VariabiliGlobali.VarGlob.allData.AggiornaPrezzi(dateOnly, prezziGiorno);
        }

        private static DateOnlyCustom GetDateEstratto(string data)
        {
            var s = data.Split(' ');
            var s2 = s[2].Split("-");

            var dt = new DateOnly(Convert.ToInt32(s2[0]), Convert.ToInt32(s2[1]), Convert.ToInt32(s2[2]));
            return new DateOnlyCustom(dt);
        }
    }
}
