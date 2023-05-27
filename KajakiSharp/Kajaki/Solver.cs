using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki;

public static class Solver
{
    public static List<((int, int) pair1, (int, int)? pair2)> Solve(Graph graph)
    {
        var result = new List<((int, int) pair1, (int, int)? pair2)>();

        var lineGraph = graph.GetLineGraph(out var originVertices);
        var complementGraph = lineGraph.GetComplementGraph();
        var maxMatching = complementGraph.FindMaxMatching();
        
        foreach (var matching in maxMatching)
        {
            var pair1 = originVertices[matching.vertice1];
            var pair2 = originVertices[matching.vertice2];

            complementGraph.RemoveVertex(matching.vertice1);
            complementGraph.RemoveVertex(matching.vertice2);

            result.Add((pair1, pair2));
        }

        for (int v = 0; v < complementGraph.V; ++v)
        {
            if (complementGraph.ActiveVertex[v])
            {
                var pair = originVertices[v];

                result.Add(((pair), null));
            }
        }

        return result;
    }
}
