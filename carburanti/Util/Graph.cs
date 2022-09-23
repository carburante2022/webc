namespace carburanti.Util
{
    internal static class Graph
    {
        internal static void Write()
        {
            var graph = VariabiliGlobali.VarGlob.allData.GetGraph();
            File.WriteAllText("items.json", Newtonsoft.Json.JsonConvert.SerializeObject(graph.GetItems().items));
            File.WriteAllText("groups.json", Newtonsoft.Json.JsonConvert.SerializeObject(graph.GetGroups().list));
        }
    }
}
