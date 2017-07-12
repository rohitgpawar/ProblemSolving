using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/*
 Bonnie and Clyde have decided to meet at a restaurant to have Sushi. The city is given in the form of an undirected graph with n nodes (numbered from 1..n) and m edges (without any parallel edges or self loops). Bonnie's house is located at node u and Clyde's house is located at node v. The famous restaurant Sushi Grand is located at node w.

Your task is to find out if Bonnie and Clyde can meet at Sushi Grand such that their path has no common node other than the destination w.

For example,
In the graph shown below, Bonnie's path goes from and Clyde's path goes from . 

	Sample Input 0

4 4 3  
1 2  
2 3  
2 4  
3 1  
2 4 1
1 4 3
1 4 2  

Sample Output 0

NO
YES
YES


	 */
public class Graph {
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
		graphEdges[s-1].Add(dest);
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
        visited[s-1] = true;
        paths[pathIndex] = s;
        pathIndex++;
        if (s == d)
        {
            HashSet < int > path = new HashSet<int>(paths);
            path.Remove(0);
            allPathsToDestination.Add(path);
        }
        else
        {
            foreach (int i in graphEdges[s-1])
            {
                if (!visited[i-1])
                    FindAllPaths(i, d, visited, pathIndex, paths, allPathsToDestination);
            }
        }
        
        pathIndex--;
		if(pathIndex >= 0)
			paths[pathIndex] = 0;
        visited[s-1] = false;
    }
}



class AllPathInGraph {

	public static void AllPathInGraphMain() {
		string[] tokens_n = "4 4 3".Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
		int m = Convert.ToInt32(tokens_n[1]);
		int q = Convert.ToInt32(tokens_n[2]);
        Graph graph = new Graph(n);
        //for (int a0 = 0; a0 < m; a0++) {
        {
            graph.addEdge(1, 2);
            graph.addEdge(2, 3);
            graph.addEdge(2, 4);
            graph.addEdge(3, 1);
        }
        graph.CanMeet(1, 4, 2);

  //      for (int a0 = 0; a0 < q; a0++) {
		//	string[] tokens_u = Console.ReadLine().Split(' ');
		//	int u = Convert.ToInt32(tokens_u[0]);
		//	int v = Convert.ToInt32(tokens_u[1]);
		//	int w = Convert.ToInt32(tokens_u[2]);
  //          graph.GetAllPaths(u, w);
		//}

	}
}