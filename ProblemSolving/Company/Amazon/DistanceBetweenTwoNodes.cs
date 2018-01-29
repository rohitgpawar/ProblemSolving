/*
 Distance between two given nodes in a binary tree. I was asked to write the optimal approach for the this.
 */
namespace ProblemSolving
{
    public class DistanceBetweenTwoNodes
    {
        public static void DistanceBetweenTwoNodesMain()
        {
            TreeNode root = TreeNode.GenerateBinaryTreeWithDepth(5);
            int distance = GetDistanceBetweenTwoNodesMain(root, 31, 1);
        }

        /// <summary>
        /// Provides a check if finding nodes are present and then calls find distance
        /// </summary>
        /// <param name="node"></param>
        /// <param name="node1Val"></param>
        /// <param name="node2Val"></param>
        /// <returns></returns>
        public static int GetDistanceBetweenTwoNodesMain(TreeNode node, int node1Val, int node2Val)
        {
            if (node == null)
            {//No node found
                return -1;
            }
            if(GetChildDistance(node,node1Val,0) >= 0 && GetChildDistance(node,node2Val,0) >= 0)
            {//Both node1 and node2 are children on root
                return GetDistanceBetweenTwoNodes(node, node1Val, node2Val);
            }
            else
            {//Did not find both nodes as children of root.
                return -1;
            }
        }

        /// <summary>
        /// Get the distance between two nodes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="node1Val"></param>
        /// <param name="node2Val"></param>
        /// <returns></returns>
        private static int GetDistanceBetweenTwoNodes(TreeNode node, int node1Val, int node2Val)
        {
            if(node.val==node1Val)
            {//Node1 is found in the Ancestors. Return the distance to Node2
                return GetChildDistance(node, node2Val, 0);
            }
            if(node.val == node2Val)
            {//Node2 is found in the Ancestors. Return disance to node1
                return GetChildDistance(node, node1Val, 0);
            }
            int isNode1Left = GetChildDistance(node.left, node1Val, 0);
            int isNode2Left = GetChildDistance(node.left, node2Val, 0);
            if(isNode1Left > 0 && isNode2Left >0)
            {//Both nodes found in left subtree
                return GetDistanceBetweenTwoNodes(node.left, node1Val, node2Val);
            }
            if(isNode1Left >0 || isNode2Left > 0)
            {//Only one was found in the left subtree hence current node is their ancestor
                return (GetChildDistance(node, node1Val, 0)+GetChildDistance(node,node2Val,0));
            }
            //Look on the right subtree.
            return GetDistanceBetweenTwoNodes(node.right, node1Val, node2Val);
        }
        
        /// <summary>
        /// Gets distance of node to child value. Return -1 if value is not found.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="childVal"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        private static int GetChildDistance(TreeNode node, int childVal, int distance)
        {
            if(node == null)
            {//Child not found
                return -1;
            }
            if(node.val == childVal)
            {// Node found 
                return distance;
            }
            int leftDistance = GetChildDistance(node.left, childVal, distance + 1);
            if (leftDistance > 0)
                return leftDistance;
            int rightDistance = GetChildDistance(node.right, childVal, distance + 1);
            return rightDistance;
        }

    }
}
