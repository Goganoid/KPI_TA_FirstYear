namespace TA.Lab2;
using GraphTools;
using System.Diagnostics;
class Program
{

    private static void TimeIt(int graphs,int edgeStep,int vertStep,Action<Graph,int,bool> graphFunction, int repeats)
    {
        var sw = new Stopwatch();
        var time = new double[graphs];
      
        for (int i = 0; i < repeats; i++)
        {
            Console.WriteLine($"Iteration={i}");
            int j = 0;
            int edges = 15;
            int vertices = 10;
            for(int g=0;g<graphs;g++)
            {
                sw.Start();
                graphFunction(new Graph(edges,vertices), 0,false);
                sw.Stop();
                Console.WriteLine($"\tEdges={edges} Vertices={vertStep} Elapsed={sw.ElapsedTicks}");
                edges += edgeStep;
                vertices += vertStep;
                time[j]+=sw.ElapsedTicks;
                j++;
                sw.Reset();
            }
        }

        for (int i = 0; i < time.Length; i++)
        {
            time[i] /= repeats;
            time[i] = Math.Round(time[i]);
        }
        Console.WriteLine($"[{String.Join(',',time)}]");
    }
    

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
        Console.WriteLine("Choose algorithm:\n1 Graph Coloring(Welsh Powell)\n2 Find path(Dijkstra)\n3 Find paths for students\n4 Random Generation ");
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
                Graph distGraph = new Graph(PromptPath());
                DijkstraAlgorithm.Dijkstra(distGraph,0);
                
            }
            else if (input.Trim() == "4")
            {
                Console.WriteLine("Timing Dijkstra");
                TimeIt(20,250,200,DijkstraAlgorithm.Dijkstra,5);
                Console.WriteLine("Timing Dijkstra");
                TimeIt(20,250,200,GcAlgorithm.GreedyColoring,5);
            }
    }
}


