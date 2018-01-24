namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q-4.10 pg 77
    /// Given two binary tress find if t2 is subtree of t1. t2 is subtree if t1 is cut at a node n that will be same as t2.
    /// </summary>
    public class CheckSubtree
    {
        public static void CheckSubtreeMain()
        {
            TreeNode treeNode = TreeNode.GenerateBinaryTreeWithDepth(5);
            TreeNode treeNode2= new TreeNode();
            TreeNode.CloneTreeFromNode(treeNode.right.left.right, treeNode2);
            treeNode2.AddLeft(new TreeNode(40));
            bool isSubTreePresent = IsSubtree(treeNode, treeNode2);
        }

        /// <summary>
        /// Checks if T2 is subtree in T1
        /// </summary>
        /// <param name="T1">Source Tree</param>
        /// <param name="T2">Tree to be found</param>
        /// <returns></returns>
        public static bool IsSubtree(TreeNode T1, TreeNode T2)
        {
            if(T1 == null)
            {
                return false;
            }
            else if(T1.val == T2.val && MatchTree(T1,T2))
            {
                return true;
            }
            return IsSubtree(T1.left, T2) || IsSubtree(T1.right, T2);
        }

        /// <summary>
        /// Checks if All the nodes match in the tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="T2"></param>
        /// <returns></returns>
        public static bool MatchTree(TreeNode node, TreeNode T2)
        {
            if(node == null && T2 == null)
            {
                return true;
            }
            else if(node == null || T2 == null)
            {
                return false;
            }
            else if(node.val != T2.val)
            {
                return false;
            }
            return MatchTree(node.left, T2.left) && MatchTree(node.right, T2.right);
        }


    }
}
