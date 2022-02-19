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
    public  Edge[] Edges;
    public readonly int VertCount;
    public readonly int EdgeCount;
    public int[,] AdjMatrix => GraphMethods.GetAdjacencyMatrix(Edges, VertCount);

    public Graph(string path)
    {
        var lines = File.ReadAllLines(path);
        // Console.WriteLine("Input:");
        // foreach (var line in lines) Console.WriteLine(line);
        // parse first line
        try
        {
            var size = Array.ConvertAll(lines[0].Trim().Split(), int.Parse);
            VertCount = size[0];
            EdgeCount = size[1];
            Edges = lines.Skip(1).Select(line =>
            {
                var values = Array.ConvertAll(line.Trim().Split(), double.Parse);
                int weight = values.Length == 3 ? (int) (values[2] * 10) : 1;
                return new Edge {Start = (int) values[0], End = (int) values[1], Weight = weight};
            }).ToArray();
        }
        catch (FormatException e)
        {
            Console.WriteLine("File has invalid format");
            throw;
        }
    }

    public Graph(int edges, int possibleVertices)
    {
        var random = new Random();
        Edges = new Edge[edges];
        for(int i=0;i<edges;i++)
        {
            Edges[i].Start = random.Next(possibleVertices);
            int endVertex = Edges[i].Start;
            while (endVertex==Edges[i].Start)
            {
                endVertex = random.Next(possibleVertices);
            }
            Edges[i].End = endVertex;
            Edges[i].Weight = random.Next(20);
        }

        VertCount = Edges.Max(edge => Math.Max(edge.Start, edge.End))+1;
        EdgeCount = edges;
        
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
            // Console.WriteLine($"{Math.Abs(edges[i].Start)} , {edges[i].End}");
            adjacencyMatrix[Math.Abs(edges[i].Start) , edges[i].End] = edges[i].Weight;
            // if not directed
            if(edges[i].Start>0) adjacencyMatrix[edges[i].End , edges[i].Start] = edges[i].Weight;
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
