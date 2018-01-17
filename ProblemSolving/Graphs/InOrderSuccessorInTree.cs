using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Graphs
{
    /// <summary>
    /// CTCI Q:4.6 pg-75
    /// </summary>
    public class InOrderSuccessorInTree
    {
        public static TreeNode FindInOrderSuccessorInTree(TreeNode node)
        {
            if (node == null)
                return null;
            if(node.right != null)
            {//right path exists
                node = node.right;
                while(node.left != null)
                {
                    node = node.left;
                }
                return node;
            }
            while(node.parent != null && node.parent.val < node.val)
            {
                node = node.parent;
            }
            return node;
        }
    }
}
