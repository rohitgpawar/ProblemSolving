using System;
using System.Collections.Generic;
using System.Linq;
/*
 Given a directed graph you need to complete the function topoSort which returns an array having the topologically sorted elements of the array 
 and takes two arguments . The first argument is the Graph graph represented as adjacency list and the second is the number of vertices V 
     */
     // OUTDATED WATCH FOR BuildOrder.cs
namespace ProblemSolving
{
    public class TopologicalSort
    {


        static public int topoSort()
        {
            int N = 6;
            List<int[]> graph = new List<int[]>();
            graph.Add(new int[]{5,0});
            graph.Add(new int[]{5,2});
            graph.Add(new int[]{2,3});
            graph.Add(new int[]{4,0});
            graph.Add(new int[]{4,1});
            graph.Add(new int[]{1,3});

            int[] startedge = graph.First();
            graph.Remove(startedge);
            Stack<int> visitedVertex = new Stack<int>();
            Stack<int> sortedVertex = new Stack<int>();
            // Your code here
            for (int i = 0; i < N; i++)
            {
                int currentVertex = startedge[0];
                int outgoingVertex = startedge[1];
                if (visitedVertex.Count == 0 || visitedVertex.Peek() != currentVertex)
                {
                    visitedVertex.Push(currentVertex);
                }
                if (visitedVertex.Count == 0 || visitedVertex.Peek() != outgoingVertex)
                {
                    visitedVertex.Push(outgoingVertex);
                }
                int[] nextedge = graph.Find(qry => qry[0] == outgoingVertex);
                if (nextedge == null)
                {
                    while (nextedge == null)
                    {
                        if (!sortedVertex.Contains(outgoingVertex))
                            sortedVertex.Push(outgoingVertex);
                        visitedVertex.Pop();
                        if (visitedVertex.Count != 0)
                        {
                            nextedge = graph.Find(qry => qry[0] == visitedVertex.Peek());
                            outgoingVertex = visitedVertex.Peek();
                        }
                        else
                        {
                            break;
                        }

                    } 
                    if (nextedge == null)
                    {
                        if(graph.Count>0)
                        nextedge = graph.First();
                        //graph.Remove(startedge);
                    }
                }

                startedge = nextedge;
                if(graph.Count > 0)
                    graph.Remove(startedge);

            }
            foreach (int sorted in sortedVertex)
            {
                Console.Write(" {0}", sorted);
            }
            Console.ReadLine();
            return 0;

        }
    }
}
