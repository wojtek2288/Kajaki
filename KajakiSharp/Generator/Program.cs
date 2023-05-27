using System.IO;

namespace Generator;

public class Program
{
    static string Usage = "generator.exe [nazwa pliku] [liczba osób] [opcjonalne: liczba par]";

    static void Main(string[] args)
    {
        if (args.Length != 2 && args.Length != 3) 
        {
            Console.WriteLine(Usage);
            return;
        }

        string filename = args[0];
        int peopleCount = int.Parse(args[1]);
        int? pairCount = args.Length == 3 ? int.Parse(args[2]) : null;
        Generator.GenerateInputFile(filename, peopleCount, pairCount);
    }
}

public static class Generator
{
    public static void GenerateInputFile(string filename, int peopleCount, int? pairCount)
    {
        var random = new Random();

        var maxPairs = peopleCount * (peopleCount - 1) / 2;

        if (!pairCount.HasValue)
            pairCount = random.Next(maxPairs) + 1;

        var selectedPairs = Enumerable.Range(1, maxPairs).OrderBy(num => random.Next()).Take(pairCount.Value);

        var pairs = selectedPairs.Select(num => ConvertPairIdToPair(num, peopleCount));

        using (StreamWriter sw = File.CreateText(filename))
        {
            sw.WriteLine($"{peopleCount} {pairs.Count()}");
            foreach (var pair in pairs)
                sw.WriteLine($"{pair.p1} {pair.p2}");
        }
    }

    public static (int p1, int p2) ConvertPairIdToPair(int id, int peopleCount)
    {
        int n = (int)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * (double)id)) / 2);
        int sum = (int)(n + 1) * n / 2;

        int firstPerson = peopleCount - n;
        int secondPerson = peopleCount + id - sum;

        return (firstPerson, secondPerson);
    }
}