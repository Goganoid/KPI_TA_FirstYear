namespace TA.Lab2;
using GraphTools;

public static class GcAlgorithm
{
    public  static void GreedyColoring(Graph graph)
    {
        
        List<List<int>> Adj = new();
        
        for (int i = 0; i < graph.VertCount; i++)
        {
            Adj.Add(new List<int>());
        }
        foreach (var edge in graph.Edges)
        {
            Adj[edge.Start].Add(edge.End);
            Adj[edge.End].Add(edge.Start);
        }
        
        int[] result = Enumerable.Repeat(-1, graph.VertCount).ToArray();
        result[0] = 0;
       

        for (int i = 1; i < graph.VertCount; i++)
        {
            bool[] available = Enumerable.Repeat(true, graph.VertCount).ToArray();
            foreach (var vertex in Adj[i])
            {
                if (result[vertex] != -1) available[result[vertex]] = false;
            }

            int color;
            for (color = 0; color < graph.VertCount; color++)
            {
                if (available[color]) break;
            }

            result[i] = color;

        }

        for (int i = 0; i < graph.VertCount; i++)
        {
            Console.WriteLine($"Vertex:{i}|Color:{result[i]}");
        }

    }
}