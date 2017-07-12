using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class PalindromeTransformSolution
    {
        const int maxL = 1001;
        const int maxN = 100001;

        public static int[] arr = new int[maxL];
        public static int[][] LPS = new int[maxL][];
        public static int[] mark= new int[maxN];
        public static Dictionary<int,List<int>> G = new Dictionary<int, List<int>>();

        static void dfs(int s, int cc)
        {
            mark[s] = cc;
            foreach (int kvp  in G[s])
                if (mark[kvp]==0)
                    dfs(kvp, cc);
        }

        static int lps(int[] arr, int L)
        {
            int i, j, len;
            for (i = 0; i < L; i++)
            { LPS[i] = new int[maxL];
                LPS[i][i] = 1;
            }


            for (len = 2; len <= L; len++)
            {
                for (i = 0; i < L + 1 - len; i++)
                {
                    j = i + len - 1;
                    if (mark[arr[i]] == mark[arr[j]])
                    {
                        if (len == 2)
                            LPS[i][j] = 2;
                        else
                            LPS[i][j] = LPS[i + 1][j - 1] + 2;
                    }
                    else
                        LPS[i][j] = LPS[i][j - 1] > LPS[i + 1][j] ? LPS[i][j - 1] : LPS[i + 1][j];
                }
            }
            return LPS[0][L - 1];
        }

        public static void PalindromeTransformSolutionMain()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int m = Convert.ToInt32(tokens_n[2]);
            for (int a0 = 0; a0 < k; a0++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(tokens_x[0]);
                int y = Convert.ToInt32(tokens_x[1]);
                if (G.ContainsKey(x))
                {
                    List<int> values = G[x];
                    values.Add(y);
                }
                else
                {
                    G[x] = new List<int>() {y};
                }
                if (G.ContainsKey(y))
                {
                    List<int> values = G[y];
                    values.Add(x);
                }
                else
                {
                    G[y] = new List<int>() { x };
                }
            }

            int cc = 1;
            for (int i = 1; i <= n; ++i)
                if (mark[i] == 0)
                {
                    dfs(i, cc);
                    cc++;
                }

            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            Console.WriteLine("{0}\n", lps(a, m));
            
        }

    }
}
