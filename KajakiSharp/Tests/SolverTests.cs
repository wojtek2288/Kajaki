using Kajaki;
using Xunit;

namespace Tests;

public class SolverTests
{
    [Fact]
    public void Solver_works_correctly()
    {
        var graph = new Graph(5);

        Solver.Solve(graph);
    }
}