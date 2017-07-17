/*
 Longest SubSequence palindrome. with trasformations to its parents.
 */
/*
 Sample Input 0

10 7 6
1 3
5 7
3 5
2 6
2 4
8 4
10 9
1 9 2 3 10 3

Sample Output 0

5

Sample Input 1

10 8 15
1 2
1 3
2 7
3 1
4 5
6 8
9 6
10 5
1 4 5 7 9 8 1 3 10 4 5 10 2 7 8

Sample Output 1

10


 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving
{
    class Node
    {
        public Node Parent;

        public int Rank;

        public int Value;
    }

    public class PalindromeTransformSolution
    {
        static Node Find(Node n)
        {
            if (n.Parent != n)
            {
                n.Parent = Find(n.Parent);
            }

            return n.Parent;
        }

        static void Union(Node x, Node y)
        {
            var xRoot = Find(x);
            var yRoot = Find(y);

            if (xRoot == yRoot)
                return;

            if (xRoot.Rank < yRoot.Rank)
                xRoot.Parent = yRoot;
            else if (xRoot.Rank > yRoot.Rank)
                yRoot.Parent = xRoot;
            else
            {
                if (xRoot.Value < yRoot.Value)
                {
                    //Arbitrarily make one root the new parent
                    yRoot.Parent = xRoot;
                    xRoot.Rank = xRoot.Rank + 1;
                }
                else
                {
                    xRoot.Parent = yRoot;
                    yRoot.Rank = yRoot.Rank + 1;
                }
            }
        }

        static int[,] dpmat;

        static int LongestSubpalindrome(int[] a)
        {
            dpmat = new int[a.Length, a.Length];

            return LongestSubpalindrome(a, 0, a.Length - 1);
        }

        static int LongestSubpalindrome(int[] a, int sIdx, int eIdx)
        {
            if (dpmat[sIdx, eIdx] > 0)
            {
                return dpmat[sIdx, eIdx];
            }

            if (sIdx > eIdx)
            {
                return 0;
            }

            if (sIdx == eIdx)
            {
                return 1;
            }

            if (a[sIdx] == a[eIdx])
            {
                var r = 2 + LongestSubpalindrome(a, sIdx + 1, eIdx - 1);

                dpmat[sIdx, eIdx] = r;

                return r;
            }

            var skipLeft = LongestSubpalindrome(a, sIdx + 1, eIdx);

            var skipRight = LongestSubpalindrome(a, sIdx, eIdx - 1);

            dpmat[sIdx, eIdx] = Math.Max(skipLeft, skipRight);

            return dpmat[sIdx, eIdx];
        }

        static void Solve(ICollection<Node> nodes, int[] a)
        {
            // transform to representative characters
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = Find(nodes.ElementAt(a[i] - 1)).Value;
            }

            //Console.Error.WriteLine(string.Join(" ", a.Select(i => i.ToString())));

            // dp the solution
            var max = LongestSubpalindrome(a);

            Console.WriteLine(max);
        }

        public static void PalindromeTransformSolutionMain()
        {
            var nodes = new List<Node>();

            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int m = Convert.ToInt32(tokens_n[2]);

            for (var i = 0; i < n; i++)
            {
                var node = new Node();

                node.Parent = node;
                node.Value = i + 1;

                nodes.Add(node);
            }

            for (int a0 = 0; a0 < k; a0++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(tokens_x[0]);
                int y = Convert.ToInt32(tokens_x[1]);

                Union(nodes[x - 1], nodes[y - 1]);
            }
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            Solve(nodes, a);
        }

    }
}
