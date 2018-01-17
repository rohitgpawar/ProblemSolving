using ProblemSolving;
using System;
using System.Collections.Generic;
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