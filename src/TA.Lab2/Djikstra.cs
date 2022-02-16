namespace TA.Lab2;
using GraphTools;
public static class DijkstraAlgorithm
{
    public static void Dijkstra(Graph graph,int src)
    {
        int[,] adjMatrix = graph.AdjMatrix;
        // number of vertices
        int V = graph.AdjMatrix.GetLength(0);
        // min distances
        int[] dist = new int[V];
        // visited
        bool[] sptSet = new bool[V];
        
        int[] parents = new int[V];
        // initialisation
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }
        dist[src] = 0;
        parents[src] = -1;
        
        for (int count = 0; count < V - 1; count++) {
            
            int u = MinDistance(dist, sptSet,V);
            
            sptSet[u] = true;
 
            // Update dist value of the adjacent
            // vertices of the picked vertex.
            for (int v = 0; v < V; v++)
                // update if not visited && edge u-v exists && distance is less than current
                if (!sptSet[v] && 
                    adjMatrix[u, v] != 0 && 
                    dist[u] != int.MaxValue &&
                    dist[u] + adjMatrix[u, v] < dist[v])
                {
                    dist[v] = dist[u] + adjMatrix[u, v];
                    parents[v] = u;
                }
                   
        }
        PrintSolution(dist,V,parents,src);
    }
    private static void PrintSolution(int[] dist,int vertices,int[] parents,int src)
    {
        Console.Write("Vertex\t Distance\tPath");
         
        for (int vertexIndex = 0;
             vertexIndex < vertices;
             vertexIndex++)
        {
            if (vertexIndex != src)
            {
                Console.Write("\n" + src+ " -> ");
                Console.Write(vertexIndex + " \t\t ");
                Console.Write(dist[vertexIndex] + "\t\t");
                PrintPath(vertexIndex, parents);
            }
        }
    }
    private static void PrintPath(int currentVertex, int[] parents)
    {
        // if src node
        if (currentVertex == -1)
        {
            return;
        }
        PrintPath(parents[currentVertex], parents);
        Console.Write(currentVertex + " ");
    }
    private static int MinDistance(int[] dist, bool[] sptSet, int vertices)
    {
        int min = int.MaxValue, minIndex = -1;
 
        for (int v = 0; v < vertices; v++)
            // if not visited and less than minimal distance
            if (sptSet[v] == false && dist[v] <= min) {
                min = dist[v];
                minIndex = v;
            }

        return minIndex;
    }
}