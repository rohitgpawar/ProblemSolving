using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class GraphSubSting
{
    public char value;
    public List<int> graphEdges;
    public GraphSubSting(char val, int nodeCount)
    {
        value = val;
        graphEdges = new List<int>(nodeCount);
    }
    public void addEdge(int d)
    {
        graphEdges.Add(d);
    }



}
class CountSubstingInGraph
{
    static public int FindPatternInGraph(string pattern, int n, int s, int d, GraphSubSting[] graphArry)
    {
        StringBuilder pathString = new StringBuilder();
        int pathCounter = 0;
        bool pathFound = false;
        bool[] visited = new bool[n];
        FindPath(s, d, pathString, pathCounter, graphArry, pathFound, visited);
        return (pathString.Length - pathString.Replace(pattern, "").Length) / pattern.Length;
    }
    static public bool FindPath(int s, int d, StringBuilder pathString, int pathCounter, GraphSubSting[] graphArry, bool pathFound, bool[] visited)
    {
        pathString.Append(graphArry[s].value);
        pathCounter++;
        if (!visited[s])
        { visited[s] = true; }

        if (s == d)
        {
            pathFound = true;
            return pathFound;
        }
        foreach (int childNode in graphArry[s].graphEdges)
        {
            if (!visited[childNode])
                pathFound = FindPath(childNode, d, pathString, pathCounter, graphArry, pathFound, visited);
        }
        if (!pathFound)
        {
            pathCounter--;
            pathString.Remove(pathCounter, 1);
        }
        return pathFound;
    }
    public static void CountSubstingInGraphMain()
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int q = Convert.ToInt32(tokens_n[1]);
        GraphSubSting[] GraphSubSting = new GraphSubSting[n];
        string s = Console.ReadLine();
        int position = 0;
        foreach (char c in s)
        {
            GraphSubSting[position] = new GraphSubSting(c, n);
            position++;
        }
        string p = Console.ReadLine();
        for (int a0 = 0; a0 < n - 1; a0++)
        {
            string[] tokens_u = Console.ReadLine().Split(' ');
            int u = Convert.ToInt32(tokens_u[0]);
            int v = Convert.ToInt32(tokens_u[1]);
            GraphSubSting[u - 1].addEdge(v - 1);
            GraphSubSting[v - 1].addEdge(u - 1);
        }
        for (int a0 = 0; a0 < q; a0++)
        {
            string[] tokens_u = Console.ReadLine().Split(' ');
            int u = Convert.ToInt32(tokens_u[0]);
            int v = Convert.ToInt32(tokens_u[1]);
            Console.WriteLine(FindPatternInGraph(p, n, u - 1, v - 1, GraphSubSting));
        }
    }
}
