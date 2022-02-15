namespace TA.Lab2;
using GraphTools;

class Program
{

    private static string PromptPath()
    {
        string path;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter the path to file");
                path = Console.ReadLine() ?? "";
                var file = File.OpenRead(path);
                if (file.Length == 0)
                {
                    Console.WriteLine("is empty");
                    continue;
                }
                break;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Incorrect file path");
            }
        }

        return path;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose algorithm:\n1 Graph Coloring(Welsh Powell)\n2 Find path(Dijkstra)");
            var input = Console.ReadLine()!.Trim();
            Graph graph = new Graph(PromptPath());
            if (input == "1")
            {
                GcAlgorithm.GreedyColoring(graph);
            }
            else
            {
                DijkstraAlgorithm.Dijkstra(graph,0);
            }
    }
}


