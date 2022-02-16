namespace TA.Lab2;
using GraphTools;

public static class GcAlgorithm
{
    public  static void GreedyColoring(Graph graph, int src)
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
        
        // fill with -1 set src color to 0
        int[] result = Enumerable.Repeat(-1, graph.VertCount).ToArray();
        result[src] = 0;
       

        for (int i = 1; i < graph.VertCount; i++)
        {
            // fill with true
            bool[] available = Enumerable.Repeat(true, graph.VertCount).ToArray();
            foreach (var vertex in Adj[i])
            {
                // if colored then make unavailable
                if (result[vertex] != -1) available[result[vertex]] = false;
            }

            int color;
            for (color = 0; color < graph.VertCount; color++)
            {
                // first available color
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