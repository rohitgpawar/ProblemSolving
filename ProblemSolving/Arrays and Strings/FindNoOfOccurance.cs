using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class FindNoOfOccurance
    {
        public static void FrequencyOfNoInArray(int[] arry)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < arry.Length; i++)
            {
                if (dict.ContainsKey(arry[i]))
                {
                    int count;
                    dict.TryGetValue(arry[i], out count);
                    dict[arry[i]] = count + 1;
                }
                else
                {
                    dict.Add(arry[i], 1);
                }
            }

            Console.WriteLine("Number\t Occurance");
            foreach (KeyValuePair<int,int> kvp in dict)
            {
                Console.WriteLine("{0}\t {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
