using System;
using System.Collections.Generic;

namespace ProblemSolving
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
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

    }

    
    public class Print_Level_Order
    {
        
        static public TreeNode fillTree()
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
        
        public static void Start(string[] args)
        {
            TreeNode root = fillTree();
            Queue<TreeNode> currentlevel = new Queue<TreeNode>();
            Queue<TreeNode> nextLevel = new Queue<TreeNode>();
            currentlevel.Enqueue(root);
            TreeNode parent = root;
            while (currentlevel.Count > 0)
            {
                TreeNode current = currentlevel.Dequeue();
                Console.Write(current.val + " ");
                if (current.left != null)
                {
                    nextLevel.Enqueue(current.left);
                }
                if(current.right != null)
                {
                    nextLevel.Enqueue(current.right);
                }
                if (currentlevel.Count == 0)
                {
                    Console.WriteLine();
                    currentlevel = new Queue<TreeNode>(nextLevel);
                    nextLevel = new Queue<TreeNode>();
                }
            }
            Console.ReadLine();
        }
    }
}
