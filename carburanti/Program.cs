#region

using carburanti.Util;
using carburanti.Util.Scraper;

#endregion

Console.WriteLine("Hello, World!");


Github.Download();

CarburantiOpenDataScraper.Download();

FileSerializationUtil.WriteData();
FileSerializationUtil.DeleteOldFiles();


Graph.Write();