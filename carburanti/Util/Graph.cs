namespace carburanti.Util
{
    internal static class Graph
    {
        internal static void Write()
        {
            var graph = VariabiliGlobali.VarGlob.allData.GetGraph();
            File.WriteAllText("data/items.json", Newtonsoft.Json.JsonConvert.SerializeObject(graph.GetItems().items));
            File.WriteAllText("data/groups.json", Newtonsoft.Json.JsonConvert.SerializeObject(graph.GetGroups().list));
        }
    }
}
