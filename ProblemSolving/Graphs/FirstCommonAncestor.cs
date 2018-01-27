namespace ProblemSolving
{
    public class FirstCommonAncestor
    {
        /// <summary>
        /// CTCI Q-4.8 pg-77
        /// Find the common Ancestor of two nodes in tree
        /// </summary>
        public static void FirstCommonAncestorMain()
        {
            TreeNode rootNode = TreeNode.GenerateBinaryTreeWithDepth(5);
            
            TreeNode ancestor = FindFirstCommonAncestor(rootNode,rootNode.right.left.right.right,rootNode.right.left);
        }

        public static TreeNode FindFirstCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null)
                return null;
            if(!Covers(node,p) || !(Covers(node,q)))
            {
                return null;
            }

            return Helper(node, p, q);

        }

        /// <summary>
        /// Check if current node is first Ancestor. Else find and rescure to the covering subtree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static TreeNode Helper(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == p || node == q || node == null)
                return node;
            bool isLeftp = Covers(node.left, p);
            bool isLeftq = Covers(node.left, q);
            if (isLeftp != isLeftq)
                return node;
            TreeNode sideTree = isLeftp ? node.left : node.right;
            return Helper(sideTree, p, q);

        }

        /// <summary>
        /// Check if root node contains node 'p' in its decendents
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Covers(TreeNode root, TreeNode p)
        {
            if (root == null)
                return false;
            if (root == p)
                return true;

            return Covers(root.left, p) || Covers(root.right, p);
        }
    }
}
