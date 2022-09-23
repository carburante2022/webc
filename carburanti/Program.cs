// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



carburanti.Util.Scraper.Github.Download();

carburanti.Util.Scraper.CarburantiOpenDataScraper.Download();

string s = Newtonsoft.Json.JsonConvert.SerializeObject(carburanti.VariabiliGlobali.VarGlob.allData);
File.WriteAllText("data.json", s);

carburanti.Util.Graph.Write();