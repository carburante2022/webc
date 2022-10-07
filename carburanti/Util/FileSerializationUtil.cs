#region

using carburanti.VariabiliGlobali;
using Newtonsoft.Json;

#endregion

namespace carburanti.Util;

public static class FileSerializationUtil
{
    public static void WriteData()
    {
        var datas = VarGlob.allData.GetDatasSplittedInDays();
        foreach (var dataKey in datas.Keys)
        {
            var path = "data/data_" + dataKey.ToString("_") + ".json";
            var s = JsonConvert.SerializeObject(datas[dataKey], Formatting.Indented);
            File.WriteAllText(path, s);
        }
    }

    public static void DeleteOldFiles()
    {
        FileDelete("data/data.json");
    }

    private static void FileDelete(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch
        {
            // ignored
        }
    }
}