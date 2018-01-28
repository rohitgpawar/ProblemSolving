using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    class ProblemSolving
    {
        //static 
        static void Main(string[] args)
        {
            DistributeChocolateAmongKStudents.DistributeChocolateAmongKStudentsMain();
            CheckContiguousIntergers.CheckContiguousIntergersMain();
            ClosestNumberFromList.ClosestNumberFromListMain();
            Sorting.MergeSort.ApplyMergeSort(new int[5] { 5, 4, 3, 2, 1 }, 0, 4);
            PrintAllNodesAtDistanceK.PrintAllNodesAtDistanceKMain();
            FindMissingNumber.FindMissingNumberMain();
            MaxSumSubArray.MaxSumSubArrayMain();
            MaxSubArrayWithGivenSum.MaxSubArrayWithGivenSumMain();
            StockBuySellMaxProfit.StockBuySellMaxProfitMain();
            BoundryTraversalOfBT.BoundryTraversalOfBTMain();
            TreePathsWithSum.TreePathsWithSumMain();
            RandomNode.RandomNodeMain();
            EquilibriumInArray.EquilibriumInArrayMain();
            IntegerToRoman.IntegerToRomanMain();
            CheckSubtree.CheckSubtreeMain();
            Interview.Bluewolf.BluewolfMain();
            GetAllCombinationOfArray.GetAllCombinationOfArrayMain();
            BST_GetArrayFromTree.BST_GetArrayFromTreeMain();
            FirstCommonAncestor.FirstCommonAncestorMain();
            BuildOrder.BuildOrderMain();
            CheckBinarySearchTree.CheckBinarySearchTreeMain();
            CheckBalancedTree.CheckBalancedTreeMain();
            ListOfDepthsInTree.ListOfDepthsInTreeMain();
            RouteBetweenTwoNodes.RouteBetweenTwoNodesMain();
            SubsetSumInArray.SubsetSumInArrayMain();
            MaxSubArrayWithGivenSum.MaxSubArrayWithGivenSumMain();
            string hh = "Hello";
            //IEnumerable<int> ll = hh.ToArray<int>();
            SumDigitsToASingleDigit.SumDigitsToASingleDigitMain();
            FizzBuzz.FizzBuzzMain();
            FindNearestSmallerNumberToRight_Array.FindNearestSmallerNumberToRight_ArrayMain();
            char[] word = new char[10];
            word[0] = 'l';
            word[1] = 'o';
            word[2] = 'v';
            word[3] = 'e';
            word[4] = '\0';
            word.ToString();
            HashSet<string> w = new HashSet<string>();
            w.Add("love");
            string word1 = new string(word);
            word1 = word1 + 'f';
            w.Contains(word1);

            int[][] _memo = new int[1000000][];
            //CountCityAndRoad.CountCityAndRoadMain();
            TwoRobots.TwoRobotsMain();
            MakeEqual.MakeEqualMain();
            PalindromeTransformSolution.PalindromeTransformSolutionMain();
            CountLargestGroup.Start();
            CountAnagram.CountAnagramMain();
            StringBuilder strbld = new StringBuilder();
            strbld.Append('c');
            int i = 'C';
            CountSubstingInGraph.CountSubstingInGraphMain();
            AllPathInGraph.AllPathInGraphMain();
            PalindromeTransform.PalindromeTransformMain();
            PatternMatch.PatternMatchMain();
            MaxPalindromeInTable.MaxPalindromeInTableMain();
            SortedList<int, int> sortedList = new SortedList<int, int>();
            sortedList.Capacity = 2;
            sortedList.Add(1, 1);
            sortedList.Add(2, 2);
            sortedList.Add(3, 3);
            List<List<int>> graphEdges = new List<List<int>>();
            graphEdges[0][0] = 0;
            Hashtable openWith = new Hashtable();
            openWith.Add("txt", "notepad.exe");
            openWith["txt"] = "New";

            //Paranthesis_Check.Start(args);
            //Print_Level_Order.Start(args);
            //LongestValidParenthesis.Start();
            //TopologicalSort.topoSort();
            //Console.WriteLine(ArrayRotatedMin.FindMinFromRotatedArray(new int[] {12,102,205,-1,0,5,6,7,8,9,10,11}));
            //bool isUniqueCharInString = UniqueCharInString.StringHasUniqueChar("Rohit");
            //bool permutable = StringPermutation.AreTwoStringsPermutable("ABC", "BCD");
            //string urlifed = URLify.URLifyString("Hi    This  is  Rohit     ",20);
            //bool isPalindromePermutation = PalindromePermutation.CheckPalindromePermutation("Tact coa");
            //bool isOneAway = OneAway.isOneEditAway("pales", "bale");
            //string compressedString = StringCompression.GetCompressedString("aaabccdddaabbff");
            //RotateMatrix.GetRotateMatrix();
            //ZeroMatrix.SetZeroMatrix();
            //bool rotatedString = StringRotation.isStringRotation("waterbottle","lewaterbott");
            //RemoveDuplicates.RemoveDuplicatefromLL();
            //KthToLast.GetKthFromLastInLL(1);
            //Partition.PartitionLL(1);
            //MinimalBinaryTree.GetMinimalBinaryTree();
            //ReverseArrayRecursion.MakeArrayReverse(new int[] { 3, 5, 1, 7, 9 }, 0);
            //bool matchFound = ArrayValueAndIndexMatch.FindMatching(new int[] { 0, 5, 5, 3 }, 0, 4);
            //IntToBinary.GetBinary(10);
            //Console.WriteLine();
            //Console.WriteLine(Convert.ToString(101, 2));
            //Console.WriteLine(DistinctCount.CountDistinct(new int[] { 0, 1,1,1,2,2,2,5, 5, 3 }, 0,1));
            //FindValuesAsSumInArray.FindSumInArray(new int[] { 0, 1, 2, 4, 5 }, 0,7, new System.Collections.Generic.Stack<int>());
            //FindMin.FindMinInArray(new int[] { 5,3,2,1,10,15,25,35,45,65 }, 0, 10);
            //FindLargestNegativeNumber.FindLargestNegativeInArray(new int[] { 5, 3, 2, 1,-5,-10,-11,-20,-34,-67 }, 0, 9);
            //ReverseLL.ReverseLinkedList();
            //FindCommonIn3List.FindCommonElements(new int[] { 1,2,3,10,20,27,35,40}, new int[] { 2,4,10,20,25,36,40}, new int[] { 3,10,12,20,25,36,40});
            //FindNoOfOccurance.FrequencyOfNoInArray(new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 22, 33, 22, 33, 22, 55, 44, 66, 77, 88 });
            //ThreeWayPartitionInArray.PartitionRGBInArray(new char[] {'R','G','B', 'R', 'B', 'G', 'B', 'R', 'G', 'B', 'R', 'G','G','B','B','R','G','R' });
            //LargestInConcaveArray.GetLargestInConcaveArray(new int[] { 1,2,3,4,5,6,7,8,9,20,40,41,42,43,43,45,49,48,47,46,45,30,25,22,18,14,12,10,5,3,2,1 });
            //IslandProblem.CountIslands(new int[4, 5] { { 1, 1, 0, 0, 0 }, { 1, 1, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 1, 1 }, });
            //MinSubArrayWithValue.FindShortestSubArrayWithValue(new int[] { 1, 11, 100, 1, 0, 200, 3, 2, 1, 250 },280);
            //ReverseVowelsInString.ReverseVowels("leetcode");
            HashSet<int> oddNumbers = new HashSet<int>();
            oddNumbers.Add(2);
            oddNumbers.Add(1);
            oddNumbers.Add(2);
            int[][] array = new int[7][];
            array[0] = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 };
            array[1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            array[2] = new int[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            array[3] = new int[] { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 };
            array[4] = new int[] { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 };
            array[5] = new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            array[6] = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 };

            GroupAndWall.GetNumberOfGroups(array);
            Console.Read();

        }


    }
}
