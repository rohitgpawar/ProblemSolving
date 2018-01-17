using System;
using System.Collections.Generic;

namespace ProblemSolving
{

    public class Print_Level_Order
    {
        public static void Print_Level_OrderMain()
        {
            TreeNode root = TreeNode.GenerateTree();
            Print_Level_OrderTree(root);
        }

        public static void Print_Level_OrderTree(TreeNode root)
        {
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
