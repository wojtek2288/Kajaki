namespace Kajaki;

internal class Program
{
    static string Usage = "kajaki.exe [opcjonalne: nazwa pliku]";
    static void Main(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine(Usage);
            return;
        }

        var filename = "test.txt"; //args.Length != 0 ? args[0] : null;
        var graph = GraphLoader.GetGraph(filename);

        Solver.Solve(graph);

    }
}