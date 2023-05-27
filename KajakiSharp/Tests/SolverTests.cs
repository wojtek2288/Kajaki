using Kajaki;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Tests;

public class SolverTests
{
    [Theory]
    [InlineData(12, 15)]
    [InlineData(13, 16)]
    [InlineData(14, 17)]
    [InlineData(2, 4)]
    [InlineData(3, 5)]
    [InlineData(50, 120)]
    [InlineData(20, 190)]
    [InlineData(100, 200)]
    [InlineData(200, 400)]
    [InlineData(500, 1000)]
    [InlineData(1000, 2000)]
    public void Solver_works_correctly(int peopleCount, int? pairCount)
    {
        var graph = Generator.Generator.GenerateGraph(peopleCount, pairCount);

        var res = Solver.Solve(graph);
        var convertedRes = ConvertAndSkipNulls(res);
        var edgeComparer = new EdgeComparer();

        foreach (var edge in graph.EdgeDictionary.Keys)
        {
            Assert.Contains(convertedRes, r => edgeComparer.Equals(r, edge));
        }

        Assert.Equal(graph.EdgeDictionary.Count, convertedRes.Count);
    }

    [Fact]
    public void Solver_correctly_solves_example_from_documentation()
    {
        var graph = new Graph(4);

        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(1, 3);

        var actual = Solver.Solve(graph);

        var expected = new List<((int, int), (int, int)?)>
        {
            ((0, 1), (2, 3)),
            ((1, 2), null),
            ((1, 3), null),
        };

        Assert.Equal(expected, actual);
    }

    private static List<(int, int)> ConvertAndSkipNulls(List<((int, int) pair1, (int, int)? pair2)> solution)
    {
        List<(int, int)> convertedList = solution
            .SelectMany(p => new[] { p.pair1, p.pair2 })
            .Where(p => p.HasValue)
            .Select(p => p!.Value)
            .ToList();

        return convertedList;
    }


    [Fact]
    public void IsMaximumMatichng()
    {
        var graph = new Graph(10);
        graph.AddEdge(0, 3);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 8);
        graph.AddEdge(0, 4);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 4);
        graph.AddEdge(1, 8);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 7);
        graph.AddEdge(3, 7);
        graph.AddEdge(3, 9);
        graph.AddEdge(4, 5);
        graph.AddEdge(4, 9);
        graph.AddEdge(5, 6);
        graph.AddEdge(6, 7);
        graph.AddEdge(6, 9);
        graph.AddEdge(8, 9);

        var res = graph.FindMaxMatching();
        var usedVertices = new HashSet<int>();

        foreach (var edge in res)
        {
            Assert.True(usedVertices.Add(edge.vertice1));
            Assert.True(usedVertices.Add(edge.vertice2));
        }

        var maxMatching = new List<(int vertice1, int vertice2)>()
        {
            (0, 2), (3, 7), (5, 6), (1, 4), (8, 9)
        };

        Assert.True(res.Count == maxMatching.Count);
    }
}