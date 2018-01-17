using System.Collections.Generic;

namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q-4.1 pg-75
    /// </summary>
    public class RouteBetweenTwoNodes
    {
        public static void RouteBetweenTwoNodesMain()
        {
            DirectedGaph grph = new DirectedGaph(7);
            grph.AddEdge(0, 1);
            grph.AddEdge(1, 2);
            grph.AddEdge(2, 0);
            grph.AddEdge(2, 3);
            grph.AddEdge(3, 2);
            grph.AddEdge(4, 6);
            grph.AddEdge(5, 4);
            grph.AddEdge(6, 5);

            //bool isRoute = IsRoutePresentDFS(grph, 0, 3);
            bool isRoute = IsRoutePresentBFS(grph, 0, 5);
        }

        public static bool IsRoutePresentDFS(DirectedGaph grph, int source, int destination)
        {
            grph.visited[source] = true;
            if (source == destination) // Reached Destination node
                return true;
            foreach (int vertice in grph.edges[source])
            {
                if (!grph.visited[vertice])
                {
                    return IsRoutePresentDFS(grph, vertice, destination);
                }
            }

            return false;
        }

        public static bool IsRoutePresentBFS(DirectedGaph grph, int source, int destination)
        {
            if (source == destination)
                return true;
            grph.visited[source] = true;
            Queue<int> verticesQueue = new Queue<int>();
            verticesQueue.Enqueue(source);
            while (verticesQueue.Count > 0)
            {
                int vertice = verticesQueue.Dequeue();
                foreach (int adjVertice in grph.edges[vertice])
                {
                    if (adjVertice == destination)
                        return true;
                    if (!grph.visited[adjVertice])
                    {
                        grph.visited[adjVertice] = true;
                        verticesQueue.Enqueue(adjVertice);
                    }
                }
            }
            return false;
        }
    }
}
