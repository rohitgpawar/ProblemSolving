/*
 Given a list of item association relationships, write an algorithm that outputs the largest item association group. If two groups have the same number of items then select the group which contains
 the item that appears in lexicographic order.

 Input
 itemAssociation:
 [[Item1,Item2]
 [Item3,Item4]
 [Item4,Item5]]

 Output:
 [Item3,Item4,Item5]

 LEXICOGRAPHIC: Means arrange strings according to alphabatical order. USE Linq.OrderBy(s=>s) where s will the string to order by.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class CountLargestGroup
    {
        public static void Start()
        {
            string[,] itmAss = new string[4,2];
            itmAss[0,0] = "z1";
            itmAss[0, 1] = "b1";
            itmAss[1, 0] = "b1";
            itmAss[1, 1] = "c1";
            itmAss[2, 0] = "a2";
            itmAss[2, 1] = "b2";
            itmAss[3, 0] = "a2";
            itmAss[3, 1] = "d2";
            string[] output = CountLargestGroupMain(itmAss);
        }
        public static string[] CountLargestGroupMain(string[,] itemAssociation)
        {
            string[] largestGrp = new string[0];
            List<int> maxGrpNumbers = new List<int>();
            int rows = itemAssociation.GetLength(0);
            int cols = itemAssociation.GetLength(1);
            List<string> sortedGrpList = new List<string>();
            Dictionary<int, HashSet<string>> associationGrps = new Dictionary<int, HashSet<string>>();
            int grpCount = 1;
            HashSet<string> associations = new HashSet<string>();
            if(!string.IsNullOrEmpty(itemAssociation[0, 0]))
                associations.Add(itemAssociation[0, 0]);
            if (!string.IsNullOrEmpty(itemAssociation[0, 1]))
                associations.Add(itemAssociation[0, 1]);
            associationGrps.Add(grpCount, associations);
            grpCount++;
            int maxGrpCount = 2;
            for (int i = 1; i < rows; i++)
            {
                associations = new HashSet<string>();
                if(!string.IsNullOrEmpty(itemAssociation[i, 0]))
                    associations.Add(itemAssociation[i, 0]);
                if(!string.IsNullOrEmpty(itemAssociation[i, 1]))
                    associations.Add(itemAssociation[i, 1]);
                bool grpExist = false;

                foreach (KeyValuePair<int,HashSet<string>> kvp in associationGrps)
                {
                    if (kvp.Value.Contains(itemAssociation[i, 0]) || kvp.Value.Contains(itemAssociation[i, 1]))
                    {
                        kvp.Value.UnionWith(associations);
                        grpExist = true;
                        if (kvp.Value.Count > maxGrpCount)
                        {
                            sortedGrpList.Clear();
                            maxGrpNumbers.Clear();
                            sortedGrpList.AddRange(kvp.Value.ToList());
                            maxGrpNumbers.Add(kvp.Key);
                            maxGrpCount = kvp.Value.Count;
                        }
                        else if (kvp.Value.Count == maxGrpCount)
                        {
                            sortedGrpList.AddRange(kvp.Value.ToList());
                            maxGrpNumbers.Add(kvp.Key);
                        }
                    }
                }
                if (!grpExist)
                {
                    associationGrps.Add(grpCount, associations);
                    grpCount++;
                }
            }

            sortedGrpList = sortedGrpList.OrderBy(s=>s).ToList();
            foreach (int maxGrpNo in maxGrpNumbers)
            {
                if((associationGrps[maxGrpNo]).Contains(sortedGrpList.First()))
                {
                    largestGrp = new string[(associationGrps[maxGrpNo]).Count];
                    (associationGrps[maxGrpNo]).CopyTo(largestGrp);
                    break;
                }
            }
            return largestGrp;
        }
        
    }
}
