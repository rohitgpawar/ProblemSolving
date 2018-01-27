/*
 Given binary tree print boundry nodes of the binary tree.

 */
namespace ProblemSolving
{
    public class BoundryTraversalOfBT
    {
        public static void BoundryTraversalOfBTMain()
        {
            TreeNode root = TreeNode.GenerateBinaryTreeWithDepth(4);
            PrintBoundryNodes(root);
        }

        public static void PrintBoundryNodes(TreeNode node)
        {
            if(node != null)
            {
                //Print Root Node
                System.Console.WriteLine(node.val);
                //First Print the left SubTree nodes top-bottom
                PrintLeftSubTree(node.left);
                //Print all the leaf nodes make sure not dublicate
                PrintLeafTree(node.left);
                PrintLeafTree(node.right);
                //Print all Right subtree nodes bottom-up
                PrintRightSubTree(node.right);
            }

        }

        /// <summary>
        /// Print the left boundry of the tree. Dont print leaf nodes
        /// </summary>
        /// <param name="node"></param>
        public static void PrintLeftSubTree(TreeNode node)
        {
            if(node != null)
            {
                if(node.left != null)
                {//Print self and go left
                    System.Console.WriteLine(node.val);
                    PrintLeftSubTree(node.left);
                }
                else if(node.right != null)
                {// No left child so print self and go right
                    System.Console.WriteLine(node.val);
                    PrintLeftSubTree(node.right);
                }
                //Do not consider leaf nodes 
            }
        }

        /// <summary>
        /// Print Right sub tree with right most nodes Bottom-up GoRight -> then print
        /// </summary>
        /// <param name="node"></param>
        public static void PrintRightSubTree(TreeNode node)
        {
            if(node != null)
            {
                if(node.right != null)
                {//right child so go right and then print
                    PrintRightSubTree(node.right);
                    System.Console.WriteLine(node.val);
                }
                else if(node.left != null)
                {// No right child but has left child go left and print
                    PrintRightSubTree(node.left);
                    System.Console.WriteLine(node.val);
                }
                //Do not consider leaf nodes.
            }
        }

        /// <summary>
        /// Print all leaf nodes InOrder Left PrintRoot Right
        /// </summary>
        /// <param name="node"></param>
        public static void PrintLeafTree(TreeNode node)
        {
            if(node !=null)
            {
                PrintLeafTree(node.left);
                if(node.left == null && node.right == null)
                {
                    System.Console.WriteLine(node.val);
                }
                PrintLeafTree(node.right);
            }
        }

    }
}
