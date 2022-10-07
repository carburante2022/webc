#region

using carburanti.Util;
using carburanti.Util.Scraper;
using carburanti.VariabiliGlobali;
using Newtonsoft.Json;

#endregion

Console.WriteLine("Hello, World!");


Github.Download();

CarburantiOpenDataScraper.Download();

FileSerializationUtil.WriteData();
FileSerializationUtil.DeleteOldFiles();


Graph.Write();