using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q-4.3 Pg-75
    /// Given a Binary Tree design an algorithm to create a linkedlist of all nodes at each depth.
    /// </summary>
    public class ListOfDepthsInTree
    {
        public static void ListOfDepthsInTreeMain()
        {
            TreeNode treeNode = TreeNode.GenerateBinaryTreeWithDepth(5);
            List<LinkedList<TreeNode>> linkedListByDepth = GetListsByDepthInTree(treeNode);
            List<LinkedList<TreeNode>> linkedListByDepth2 = GetListsByDepthInTree_Approach2(treeNode);
            Print_Level_Order.Print_Level_OrderTree(treeNode);
        }

        public static List<LinkedList<TreeNode>> GetListsByDepthInTree(TreeNode node)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            Queue<TreeNode> nextNodes = new Queue<TreeNode>();
            List<LinkedList<TreeNode>> linkedListByDepth = new List<LinkedList<TreeNode>>();
            nodes.Enqueue(node);
            linkedListByDepth.Add(new LinkedList<TreeNode>());
            while (nodes.Count >0 )
            {
                TreeNode currentNode = nodes.Dequeue();
                linkedListByDepth.Last().AddLast(currentNode);
                if(currentNode.left!= null)
                    nextNodes.Enqueue(currentNode.left);
                if(currentNode.right != null)
                    nextNodes.Enqueue(currentNode.right);
                if(nodes.Count == 0 && nextNodes.Count > 0)
                {
                    nodes = new Queue<TreeNode>(nextNodes);
                    nextNodes = new Queue<TreeNode>();
                    linkedListByDepth.Add(new LinkedList<TreeNode>());
                }
            }
            return linkedListByDepth;

        }

        public static List<LinkedList<TreeNode>> GetListsByDepthInTree_Approach2(TreeNode node)
        {
            List<LinkedList<TreeNode>> linkedListByDepth = new List<LinkedList<TreeNode>>();
            LinkedList<TreeNode> currentList = new LinkedList<TreeNode>();
            if (node != null)
                currentList.AddFirst(node);
            while(currentList.Count > 0)
            {
                linkedListByDepth.Add(new LinkedList<TreeNode>(currentList));
                LinkedList<TreeNode> parents = new LinkedList<TreeNode>(currentList);
                currentList = new LinkedList<TreeNode>();
                foreach(TreeNode parent in parents)
                {
                    if(parent.left!=null)
                        currentList.AddLast(parent.left);
                    if (parent.right != null)
                        currentList.AddLast(parent.right);
                }

            }

            return linkedListByDepth;
        
        }
    }
}
