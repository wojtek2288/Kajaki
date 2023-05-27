using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki;

public class SolutionPrinter
{
    public static void SaveSolution(List<((int, int) pair1, (int, int)? pair2)> solution, string? filename)
    {
        if (filename == null)
            SaveSolution(solution, Console.Out);
        else
        {
            using (var writer = new StreamWriter(filename))
                SaveSolution(solution, writer);
        }
    }

    public static void SaveSolution(List<((int, int) pair1, (int, int)? pair2)> solution, TextWriter writer)
    {
        foreach (var pairs in solution)
        {
            writer.Write($"{pairs.pair1.Item1 + 1,2} {pairs.pair1.Item2 + 1,2}, ");
            if (pairs.pair2 != null)
                writer.WriteLine($"{pairs.pair2?.Item1 + 1,2} {pairs.pair2?.Item2 + 1,2}");
            else
                writer.WriteLine($"{"-",2} {"-",2}");
        }
    }
}
