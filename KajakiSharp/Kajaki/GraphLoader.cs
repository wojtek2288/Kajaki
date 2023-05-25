using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki;

internal static class GraphLoader
{
    static string InputFileSchema = "podaj dane wejściowe \nw pierwszej linii [liczba osób] [liczba par] \nw kolejnych liniach [osoba 1] [osoba 2]";

    public static Graph GetGraph(string? filename)
    {
        if (filename == null)
        {
            Console.WriteLine(InputFileSchema);
            return LoadGraph(Console.In);
        }

        using (var reader = new StreamReader(filename))
            return LoadGraph(reader);
    }

    private static Graph LoadGraph(TextReader reader)
    {
        var firstLine = reader.ReadLine();
        if (string.IsNullOrEmpty(firstLine))
            throw new ArgumentNullException("Pierwsza linia nie może być pusta");


        var parts = firstLine.Split(' ');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int n) || !int.TryParse(parts[1], out int countOfLines))
            throw new ArgumentException("Niepoprawne argumenty w pierszej linii");

        var graph = new Graph(n);
        for (int i = 0; i < countOfLines; i++)
        {
            var pairLine = reader.ReadLine();
            if (string.IsNullOrEmpty(pairLine))
                throw new ArgumentNullException($"Linia o numerze {i} jest pusta");

            parts = pairLine.Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int p1) || !int.TryParse(parts[1], out int p2))
                throw new ArgumentException($"Niepoprawne argumenty w linii {i}");

            graph.AddEdge(p1 - 1, p2 - 1);
        }

        return graph;
    }

}
