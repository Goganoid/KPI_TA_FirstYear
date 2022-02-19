namespace TA.Lab2;
using GraphTools;

public static class GcAlgorithm
{
    public  static void GreedyColoring(Graph graph, int src,bool print=true)
    {
        // o(n)
        List<List<int>> Adj = new();
        for (int i = 0; i < graph.VertCount; i++)
        {
            Adj.Add(new List<int>());
        }
        ////
        // o(n)
        foreach (var edge in graph.Edges)
        {
            Adj[edge.Start].Add(edge.End);
            Adj[edge.End].Add(edge.Start);
        }
        ////
        
        // fill with -1 set src color to 0
        // 0(n)
        int[] result = new int[graph.VertCount];
        for (int i = 0; i < graph.VertCount; i++)
        {
            result[i] = -1;
        }
        // o(1)
        result[src] = 0;
       
        //
        for (int i = 1; i < graph.VertCount; i++)
        {
            // fill with true
            bool[] available = new bool[graph.VertCount];
            for (int j = 0; j < graph.VertCount; j++)
            {
                available[j] = true;
            }
            //O(E)
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

        if(print)
            for (int i = 0; i < graph.VertCount; i++)
            {
                Console.WriteLine($"Vertex:{i}|Color:{result[i]}");
            }

    }
}