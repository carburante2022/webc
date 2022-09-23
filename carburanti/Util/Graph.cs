using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Util
{
    internal class Graph
    {
        internal static void Write()
        {
            Model.Graph.Graph graph = carburanti.VariabiliGlobali.VarGlob.allData.GetGraph();
            File.WriteAllText("items.json", Newtonsoft.Json.JsonConvert.SerializeObject(graph.GetItems().items));
            File.WriteAllText("groups.json", Newtonsoft.Json.JsonConvert.SerializeObject(graph.GetGroups().list));
        }
    }
}
