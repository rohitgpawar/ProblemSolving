using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving
{
    public class DirectedGaph
    {
        public List<int>[] edges;
        public bool[] visited;
        public DirectedGaph(int Vertices)
        {
            edges = new List<int>[Vertices];
            for (int i = 0; i < Vertices; i++)
            {
                edges[i] = new List<int>();
            }
            visited = new bool[Vertices];
        }

        public void AddEdge(int origin, int destination)
        {
            edges[origin].Add(destination);
        }
    }

    public class Graph
    {
        public int verticesCount;
        List<int>[] graphEdges;//= new List<int>[verticesCount];

        public Graph(int V)
        {
            verticesCount = V;
            graphEdges = new List<int>[verticesCount];
            for (int i = 0; i < V; i++)
            {
                graphEdges[i] = new List<int>();
            }
        }

        public void addEdge(int s, int dest)
        {
            graphEdges[s - 1].Add(dest);
            graphEdges[dest - 1].Add(s);
        }

        public bool CanMeet(int u, int v, int w)
        {
            bool canMeet = false;
            try
            {
                List<HashSet<int>> uwPaths = GetAllPaths(u, w);
                List<HashSet<int>> vwPaths = GetAllPaths(v, w);
                for (int i = 0; i < uwPaths.Count; i++)
                {
                    for (int j = 0; j < vwPaths.Count; j++)
                    {
                        if (uwPaths[i].Intersect(vwPaths[j]).Count() == 1)
                        {
                            canMeet = true;
                            break;
                        }
                    }
                    if (canMeet)
                        break;
                }

            }
            catch (Exception ex)
            {

            }
            return canMeet;
        }


        public List<HashSet<int>> GetAllPaths(int s, int d)
        {
            List<HashSet<int>> allPathsToDestination = new List<HashSet<int>>();
            int[] paths = new int[verticesCount];
            bool[] visited = new bool[verticesCount];
            int pathIndex = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                visited[i] = false;
            }
            FindAllPaths(s, d, visited, pathIndex, paths, allPathsToDestination);
            return allPathsToDestination;
        }

        void FindAllPaths(int s, int d, bool[] visited, int pathIndex, int[] paths, List<HashSet<int>> allPathsToDestination)
        {
            if (visited[s - 1])
                return;
            visited[s - 1] = true;
            paths[pathIndex] = s;
            pathIndex++;
            if (s == d)
            {
                HashSet<int> path = new HashSet<int>(paths);
                path.Remove(0);
                allPathsToDestination.Add(path);
            }
            else
            {
                foreach (int i in graphEdges[s - 1])
                {
                    if (!visited[i - 1])
                        FindAllPaths(i, d, visited, pathIndex, paths, allPathsToDestination);
                }
            }

            pathIndex--;
            if (pathIndex >= 0)
                paths[pathIndex] = 0;
            visited[s - 1] = false;
        }
    }
}
