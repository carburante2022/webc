#region

using carburanti.Util;
using carburanti.Util.Scraper;
using carburanti.VariabiliGlobali;
using Newtonsoft.Json;

#endregion

Console.WriteLine("Hello, World!");


Github.Download();

CarburantiOpenDataScraper.Download();

var s = JsonConvert.SerializeObject(VarGlob.allData, Formatting.Indented);
File.WriteAllText("data/data.json", s);

Graph.Write();