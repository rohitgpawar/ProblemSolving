
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
        public int childCount;

        /// <summary>
        /// Only used for InOrderSuccessor Problem. Never has value
        /// </summary>
        public TreeNode parent;

        public TreeNode() { }
        public TreeNode(int x) { val = x; childCount = 1; }

        /// <summary>
        /// Add new node to the extreme left of the tree
        /// </summary>
        /// <param name="node"></param>
        public void AddLeft(TreeNode node)
        {
            //childCount++;
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
            int currentChildCount = totalNodes-1;
            while (countNodes < totalNodes && nodes.Count>0)
            {
                TreeNode currentNode = nodes.Dequeue();
                currentNode.childCount = currentChildCount+1;
                currentNode.AddLeft(new TreeNode(++countNodes));
                currentNode.AddRight(new TreeNode(++countNodes));
                nextNodes.Enqueue(currentNode.left);
                nextNodes.Enqueue(currentNode.right);
                if(nodes.Count == 0)
                {
                    currentChildCount = (totalNodes - countNodes) / nextNodes.Count;
                    nodes = new Queue<TreeNode>(nextNodes);
                    nextNodes = new Queue<TreeNode>();
                }
            }

            return root;
        }

        /// <summary>
        /// Clone a Tree from given node to the destination node
        /// </summary>
        /// <param name="node"> Source node</param>
        /// <param name="newNode">Destination node</param>
        public static void CloneTreeFromNode(TreeNode node, TreeNode newNode)
        {
            if(newNode.val == 0)
            {
                newNode.val = node.val;
            }
            if(node.left != null )
            {
                newNode.left = new TreeNode(node.left.val);
                CloneTreeFromNode(node.left, newNode.left);
            }
            if (node.right!= null)
            {
                newNode.right = new TreeNode(node.right.val);
                CloneTreeFromNode(node.right, newNode.right);
            }
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
