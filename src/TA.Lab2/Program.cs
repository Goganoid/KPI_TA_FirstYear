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

    public  static bool CheckFileExists(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"File {path} not found!");
            return false;
        }

        return true;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose algorithm:\n1 Graph Coloring(Welsh Powell)\n2 Find path(Dijkstra)\n3 Find paths for students ");
            var input = Console.ReadLine()!.Trim();
            
            if (input.Trim() == "1")
            {
                Graph graph = new Graph(PromptPath());
                GcAlgorithm.GreedyColoring(graph,0);
            }
            else if(input.Trim() =="2")
            {
                Graph graph = new Graph(PromptPath());
                DijkstraAlgorithm.Dijkstra(graph,0);
            }
            else if (input.Trim() == "3")
            {
                Console.WriteLine("Looking for dist_graph.txt,cost_graph.txt,simple_graph.txt");
                if (!CheckFileExists("dist_graph.txt") ||
                    !CheckFileExists("cost_graph.txt") ||
                    !CheckFileExists("simple_graph.txt"))
                {
                    Console.WriteLine("Can't continue");
                    return;
                }
                Graph distGraph = new Graph("dist_graph.txt");
                Graph costGraph = new Graph("cost_graph.txt");
                Graph simpleGraph = new Graph("simle_graph.txt");
                
            }
    }
}


