#region

using carburanti.VariabiliGlobali;
using Newtonsoft.Json;

#endregion

namespace carburanti.Util;

internal static class Graph
{
    internal static void Write()
    {
        var graph = VarGlob.allData.GetGraph();
        File.WriteAllText("data/items.json", JsonConvert.SerializeObject(graph.GetItems().items));
        File.WriteAllText("data/groups.json", JsonConvert.SerializeObject(graph.GetGroups().list));
    }
}