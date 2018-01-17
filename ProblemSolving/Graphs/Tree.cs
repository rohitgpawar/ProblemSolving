
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProblemSolving
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        /// <summary>
        /// Only used for InOrderSuccessor Problem. Never has value
        /// </summary>
        public TreeNode parent;

        public TreeNode() { }
        public TreeNode(int x) { val = x; }

        public void AddLeft(TreeNode node)
        {

            if (left == null)
            {
                left = node;
            }
            else
            {
                left.AddLeft(node);
            }
        }

        public void AddRight(TreeNode node)
        {
            if (right == null)
            {
                right = node;
            }
            else
            {
                right.AddRight(node);
            }
        }

        public static TreeNode GenerateTree()
        {
            TreeNode tree = new TreeNode(1);
            tree.AddLeft(new TreeNode(2));
            tree.AddLeft(new TreeNode(4));
            tree.AddRight(new TreeNode(3));
            tree.AddRight(new TreeNode(6));
            tree.right.right.AddLeft(new TreeNode(9));
            tree.right.right.left.AddLeft(new TreeNode(11));

            tree.left.AddRight(new TreeNode(5));
            tree.left.right.AddRight(new TreeNode(8));
            tree.left.right.AddLeft(new TreeNode(7));
            tree.left.right.AddLeft(new TreeNode(10));

            return tree;
        }

        /// <summary>
        /// Generates a tree with given depth
        /// </summary>
        /// <param name="depth"> Depth of tree to be generated</param>
        /// <returns></returns>
        public static TreeNode GenerateBinaryTreeWithDepth(int depth)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            Queue<TreeNode> nextNodes = new Queue<TreeNode>();
            TreeNode root = new TreeNode(1);
            nodes.Enqueue(root);
            int countNodes = 1;
            int totalNodes = 0;
            for (int i = 0; i < depth; i++)
            {
                totalNodes += (int)Math.Pow(2, i);
            }
            while(countNodes < totalNodes && nodes.Count>0)
            {
                TreeNode currentNode = nodes.Dequeue();
                currentNode.AddLeft(new TreeNode(++countNodes));
                currentNode.AddRight(new TreeNode(++countNodes));
                nextNodes.Enqueue(currentNode.left);
                nextNodes.Enqueue(currentNode.right);
                if(nodes.Count == 0)
                {
                    nodes = new Queue<TreeNode>(nextNodes);
                    nextNodes = new Queue<TreeNode>();
                }
            }

            return root;
        }

        public void AddNodeBinarySearch(TreeNode node)
        {
            if(val >= node.val)
            {
                if (left == null)
                    left = node;
                else
                    left.AddNodeBinarySearch(node);
            }
            else if(val < node.val)
            {
                if (right == null)
                    right = node;
                else
                    right.AddNodeBinarySearch(node);
            }
        }
        static TreeNode GenerateBinarySearchTreeWithDepth(int depth)
        {
            double totalNodes = 0;
            for (int i = 0; i < depth; i++)
            {
                totalNodes += Math.Pow(2, i);
            }
            TreeNode root = new TreeNode((int)totalNodes/2);
            for(int i=0;i<totalNodes*2;i+=2)
            {
                root.AddNodeBinarySearch(new TreeNode(i));
                root.AddNodeBinarySearch(new TreeNode(i+1));
                root.AddNodeBinarySearch(new TreeNode(i - 1));
            }

            return root;
        }

        public static TreeNode GenerateBinarySearchTree()
        {
            TreeNode tree = new TreeNode(20);
            tree.AddLeft(new TreeNode(10));
            tree.AddRight(new TreeNode(30));
            //tree.left.AddRight(new TreeNode(15));
            //tree.left.AddLeft(new TreeNode(5));
            tree.right.AddRight(new TreeNode(35));
            //tree.right.AddLeft(new TreeNode(25));*/
            return tree;
        }
    }


}
