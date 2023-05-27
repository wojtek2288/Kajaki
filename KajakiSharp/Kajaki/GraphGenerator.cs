using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki
{
    public static class GraphGenerator
    {
        public static Graph Generate(int peopleCount, int? pairCount)
        {
            var random = new Random();

            var maxPairs = peopleCount * (peopleCount - 1) / 2;

            if (!pairCount.HasValue)
                pairCount = random.Next(maxPairs) + 1;

            var selectedPairs = Enumerable.Range(1, maxPairs).OrderBy(num => random.Next()).Take(pairCount.Value);

            var pairs = selectedPairs.Select(num => ConvertPairIdToPair(num, peopleCount));

            var graph = new Graph(peopleCount);

            foreach (var pair in pairs)
            {
                graph.AddEdge(pair.p1 - 1, pair.p2 - 1);
            }

            return graph;
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
}
