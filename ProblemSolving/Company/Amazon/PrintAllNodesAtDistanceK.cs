/**
 * Amazon
 * Print all nodes at distance k from a given node
Given a binary tree, a target node in the binary tree, and an integer value k, print all the nodes that are at distance k from the given target node. 
No parent pointers are available

 **/
namespace ProblemSolving
{
    public class PrintAllNodesAtDistanceK
    {
        public static void PrintAllNodesAtDistanceKMain()
        {
            TreeNode node = TreeNode.GenerateBinaryTreeWithDepth(5);
            PrintAllNodesAtDistanceKFromNode(node,5, 2);
        }

        
        /// <summary>
        /// Print decendent nodes with distance K
        /// </summary>
        /// <param name="node"></param>
        /// <param name="k"></param>
        public static void PrintDownNodeKDistance(TreeNode node, int k)
        {
            if (node == null || k < 0)
            {
                return;
            }
            if(k==0)
            {
                System.Console.Write(node.val+ "  ");
            }
            PrintDownNodeKDistance(node.left, k - 1);
            PrintDownNodeKDistance(node.right, k - 1);
        }

        /// <summary>
        /// Find target node. If target node was found on left subtree then print down of parents right subtree and vice versa
        /// </summary>
        /// <param name="node"></param>
        /// <param name="targetValue"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int PrintAllNodesAtDistanceKFromNode(TreeNode node, int targetValue, int k)
        {
            if (node == null || k < 0)
            {
                return -1;
            }
            if(node.val == targetValue)
            {
                PrintDownNodeKDistance(node, k);
                return 0;
            }

            int dl = PrintAllNodesAtDistanceKFromNode(node.left, targetValue, k);

            if (dl != -1)
            {// Target node found in the left subtree

                if (dl + 1 == k)
                {// current Node is at distance K from target
                    System.Console.Write(node.val + "  ");
                }
                else
                {
                    //Print parents right decendents which are at distance 2 from target node.
                    PrintDownNodeKDistance(node.right, k - dl - 2);
                }
                return dl + 1;
            }

            dl = PrintAllNodesAtDistanceKFromNode(node.right, targetValue, k);//Find target in right subtree
            if(dl != -1)
            {// Target found in right subtree
                if (dl + 1 == k)
                {
                    System.Console.Write(node.val + "  ");
                }
                else
                {
                    PrintDownNodeKDistance(node.left, k - dl - 2);
                }
                return dl + 1;
            }
            return -1;
        }
    }
}
