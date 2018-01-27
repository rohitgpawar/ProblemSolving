using System;
using System.Collections.Generic;

namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q-4.7 pg-76
    /// Write code to solve the Build order. This is called Topological sort.
    /// </summary>
    public class BuildOrder
    {
        public static void BuildOrderMain()
        {
            DirectedGaph graph = new DirectedGaph(6);
            graph.AddEdge(0, 3);
            graph.AddEdge(5, 1);
            graph.AddEdge(5, 0);
            graph.AddEdge(1, 3);
            graph.AddEdge(3, 2);
            //graph.AddEdge(3, 0);
            GetBuildOrder(graph);
        }

        public static Stack<int> GetBuildOrder(DirectedGaph graph)
        {
            HashSet<int> addedToBuild = new HashSet<int>();// Store which are added to build order
            Stack<int> buildOrder = new Stack<int>(); // Store what is the build order
            for (int i = 0; i < graph.edges.Length; i++)
            {//GO DFS for all edges
                if (!addedToBuild.Contains(i)) // If not already added to build then DFS
                    DFS(graph, i, buildOrder, addedToBuild, new HashSet<int>());
            }
            return buildOrder;
        }

        public static void DFS(DirectedGaph graph, int position, Stack<int> buildOrder, HashSet<int> addedToBuild, HashSet<int> visiting)
        {
            if (visiting.Contains(position))
            {//If visited in this cycle then its Cyclic
                throw new Exception("Cyclic Dependency");
            }
            else
            {//Add to check for cycles
                visiting.Add(position);
            }
            foreach (int dependent in graph.edges[position])
            {//GO DFS for all dependents
                if (!addedToBuild.Contains(dependent))
                    DFS(graph, dependent, buildOrder, addedToBuild, visiting);
            }
            buildOrder.Push(position);
            addedToBuild.Add(position);
        }

    }
}

