namespace Kajaki;

internal class Program
{
    static string Usage = "kajaki.exe [opcjonalne: nazwa pliku wejsciowego] [opcjonalne: nazwa pliku wyjsciowego]";
    static void Main(string[] args)
    {
        if (args.Length > 2)
        {
            Console.WriteLine(Usage);
            return;
        }

        var filename = "C:\\Users\\User\\Documents\\Studia\\kajaki\\Kajaki\\KajakiSharp\\Kajaki\\test.txt"; // args.Length > 0 ? args[0] : null;
        var outFilename = args.Length > 1 ? args[1] : null;

        var graph = GraphLoader.GetGraph(filename);

        var solution = Solver.Solve(graph);
        SolutionPrinter.SaveSolution(solution, outFilename);
    }
}