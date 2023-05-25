using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki;

public static class Solver
{
    public static void Solve(Graph startGraph)
    {
        var graph = startGraph.GetLineGraph();
        graph = graph.GetComplementGraph();



    }



}
