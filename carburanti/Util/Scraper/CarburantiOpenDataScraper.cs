using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using carburanti.Model;

namespace carburanti.Util.Scraper
{
    internal class CarburantiOpenDataScraper
    {
        public static void Download()
        {
            string url = "https://www.mise.gov.it/images/exportCSV/prezzo_alle_8.csv";
            var r = Util.Downloader.Download(url);
            var firstNewLine = r.IndexOf('\n');
            var data = r.Substring(0, firstNewLine).Trim();
            DateOnly dateOnly = GetDateEstratto(data);
            var recorsString = r.Substring(firstNewLine).Trim();

            var m = Util.Memory.GenerateStreamFromString(recorsString);

            using (var reader = new StreamReader(m))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfoByIetfLanguageTag("it")))
            {
                List<dynamic> records = csv.GetRecords<dynamic>().ToList();
                ;
                PrezziGiorno prezziGiorno = new PrezziGiorno(dateOnly);
                foreach (var record in records)
                {
                    Prezzo prezzo = new(record);
                    prezziGiorno.Aggiungi(prezzo);
                }
                VariabiliGlobali.VarGlob.allData ??= new AllData();
                VariabiliGlobali.VarGlob.allData.AggiornaPrezzi(dateOnly, prezziGiorno);
            }
        }

        private static DateOnly GetDateEstratto(string data)
        {
            ;
            var s = data.Split(' ');
            var s2 = s[2].Split("-");

            return new DateOnly(Convert.ToInt32(s2[0]), Convert.ToInt32(s2[1]), Convert.ToInt32(s2[2]));
        }
    }
}
