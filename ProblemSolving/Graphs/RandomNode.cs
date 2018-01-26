/*
 CTCI   Q-4.10 pg 77
 Get a Random node from a binary tree, make sure all the nodes are considered.

     */
using System;

namespace ProblemSolving
{
    public class RandomNode
    {
        public static Random random = new Random();
        public static void RandomNodeMain()
        {
            TreeNode root = new TreeNode();
            root = TreeNode.GenerateBinaryTreeWithDepth(4);
            int randomNode = random.Next(root.childCount);
            TreeNode randomOutput = GetRandomNode(root, randomNode);
        }

        public static TreeNode GetRandomNode(TreeNode node, int randomNode)
        {
            if(node.left == null)
            {
                return node;
            }
            
            if(randomNode == node.left.childCount)
            {
                return node;
            }
            else if(randomNode < node.left.childCount)
            {// random node is in left subtree
                return GetRandomNode(node.left, randomNode);
            }
            else //if(randomNode> node.left.childCount)
            {// random node is in right subtree
                return GetRandomNode(node.right, randomNode-(node.left.childCount+1));
            }
        }
    }
}
