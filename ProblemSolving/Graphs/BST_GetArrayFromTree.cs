using System.Collections.Generic;

namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q 4.9 pg-76
    /// Get all possible input array combinations from a given Binary Search Tree
    /// </summary>
    public class BST_GetArrayFromTree
    {
        public static void BST_GetArrayFromTreeMain()
        {
            TreeNode root = TreeNode.GenerateBinarySearchTree();
            List<List<int>> sequences = allSequences(root);
        }

        public static List<List<int>> allSequences(TreeNode node)
        {
            List<List<int>> result = new List<List<int>>();

            if(node == null)
            {
                result.Add(new List<int>());
                return result;
            }

            List<int> prefix = new List<int>();
            prefix.Add(node.val);

            List<List<int>> leftSequence = allSequences(node.left);
            List<List<int>> rightSequence = allSequences(node.right);

            foreach(List<int> leftseq in leftSequence)
            {
                foreach(List<int> rightseq in rightSequence)
                {
                    List<List<int>> weavedList = new List<List<int>>();
                    WeaveLists(leftseq, rightseq, prefix, weavedList);
                    result.AddRange(weavedList);
                }
            }
            return result;
        }

        public static void WeaveLists(List<int> first, List<int> second, List<int> prefix, List<List<int>> output)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                List<int> result = new List<int>(prefix);
                result.AddRange(first);
                result.AddRange(second);
                output.Add(result);
                return;
            }

            int headFirst = first[0];
            first.RemoveAt(0);
            prefix.Add(headFirst);
            WeaveLists(first, second, prefix, output);
            first.Insert(0, headFirst);
            prefix.RemoveAt(prefix.Count - 1);

            int headSecond = second[0];
            second.RemoveAt(0);
            prefix.Add(headSecond);
            WeaveLists(first, second, prefix, output);
            second.Insert(0, headSecond);
            prefix.RemoveAt(prefix.Count - 1);

        }
    }
}
