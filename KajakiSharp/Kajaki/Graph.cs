using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki;

public class Graph
{
    public int V { get; set; }

    public List<int>[] AdjacencyList { get; private set; }
    public bool[] ActiveVertex { get; private set; }

    public Dictionary<(int v1, int v2), int> EdgeDictionary { get; private set; }

    private int edgeIdx = 0;
    public Graph(int v) 
    {
        V = v;
        AdjacencyList = new List<int>[v];
        for (int i = 0; i < V; i++) 
            AdjacencyList[i] = new List<int> { };
        ActiveVertex = new bool[V];
        EdgeDictionary = new Dictionary<(int v1, int v2), int>(comparer: new EdgeComparer());
    }

    public void AddEdge(int v1, int v2)
    {
        AdjacencyList[v1].Add(v2);
        AdjacencyList[v2].Add(v1);
        
        if(!EdgeDictionary.ContainsKey((v1, v2)))
           EdgeDictionary.Add((v1, v2), edgeIdx++);
    }

    public void RemoveEdge(int v1, int v2)
    {
        AdjacencyList[v1].Remove(v2);
        AdjacencyList[v2].Remove(v1);
        EdgeDictionary.Remove((v1, v2));
    }

    public void RemoveVertex(int v) => ActiveVertex[v] = false;

    public void SetVerticesToActive() 
    {
        for (int i = 0; i < V; i++)
            ActiveVertex[i] = true;
    }

    public bool[,] GetAdjacencyMatrix()
    {
        var b = new bool[V,V];

        for (int v1 = 0; v1 < V; v1++)
            foreach(int v2 in AdjacencyList[v1])
            {
                b[v1, v2] = true;
                b[v2, v1] = true;
            }

        return b;
    }

    public static Graph FromAdjacenctMatrix(bool[,] matrix)
    {
        int v = matrix.GetLength(0);
        var graph = new Graph(v);

        for (int x = 0; x < v; ++x)
            for (int y = x + 1; y < v; ++y)
                if(matrix[x, y])
                    graph.AddEdge(x, y);

        return graph;
    }

    public Graph GetComplementGraph()
    {
        var adjacencyMatrix = GetAdjacencyMatrix();
        for (int x = 0; x < V; ++x)
            for (int y = 0; y < V; ++y)
                adjacencyMatrix[x, y] = !adjacencyMatrix[x, y];

        return FromAdjacenctMatrix(adjacencyMatrix);
    }

    public Graph GetLineGraph()
    {
        var graph = new Graph(edgeIdx);

        for (int v = 0; v < V; ++v)
        {
            foreach(var u in AdjacencyList[v])
            {
                int vuId = EdgeDictionary[(v, u)];
                foreach(var w in AdjacencyList[u])
                {
                    if(w == v)
                        continue;

                    int uwId = EdgeDictionary[(w, u)];
                    graph.AddEdge(vuId, uwId);
                }
            }
        }

        return graph;
    }
}
