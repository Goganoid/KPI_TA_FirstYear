namespace GraphTools;
using System.Collections.Generic;



public struct Edge
{
    public int Start;
    public int End;
    public int Weight;
}

public class Graph
{
    public readonly Edge[] Edges;
    public readonly int VertCount;
    public readonly int EdgeCount;
    public int[,] AdjMatrix => GraphMethods.GetAdjacencyMatrix(Edges, VertCount);

    public Graph(string path)
    {
        var lines = File.ReadAllLines(path);
        Console.WriteLine("Input:");
        foreach (var line in lines) Console.WriteLine(line);
        // parse first line
        var size = Array.ConvertAll(lines[0].Trim().Split(), int.Parse);
        VertCount = size[0];
        EdgeCount = size[1];
        Edges = lines.Skip(1).Select(line =>
        {
            var values = Array.ConvertAll(line.Trim().Split(), int.Parse);
            int weight = values.Length == 3 ? values[2] : 1;
            return new Edge {Start = values[0], End = values[1], Weight = weight};
        }).ToArray();
    }

    public int[,] AsArray()
    {
        var arr = new int[Edges.Length, 2];
        for (var i = 0; i < Edges.Length; i++)
        {
            arr[i, 0] = Edges[i].Start;
            arr[i, 1] = Edges[i].End;
        }

        return arr;
    }
}

public static class GraphMethods
{
   public static int[,] GetAdjacencyMatrix(Edge[] edges, int n)
    {
        var adjacencyMatrix = new int[n, n];
        for (var i = 0; i < edges.Length; i++)
        {
            adjacencyMatrix[edges[i].Start , edges[i].End] = edges[i].Weight;
            adjacencyMatrix[edges[i].End , edges[i].Start] = edges[i].Weight;
        }

        return adjacencyMatrix;
    }
    public static void PrintMatrix(int[,] matrix)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
                Console.Write($" {matrix[i, j].ToString().PadLeft(2,' ')} ");
            Console.Write("\n");
        }
    }
}
