using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using CommandLine;

namespace Lesson4
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int value, TreeNode parent=null)
        {
            Value = value;
            Parent = parent;
        }
        
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }


    class BSearchTree : ITree
    {
        private List<TreeNode> nodesList { get;  }
        public void AddItem(int value)
        {
            if (nodesList.Count==0)
                nodesList.Add(new TreeNode(value));     // если дерево пустое-добавляем корень
            InsertIntoParentNode(GetRoot(), value);     // запускаем поиск&вставку начиная с корня
        }

        private TreeNode InsertIntoParentNode(TreeNode parent, int value)
        {
            if (value == parent.Value)
                return parent;
            
            if (value<parent.Value)
            {
                if (parent.LeftChild == null)
                {
                    parent.LeftChild = new TreeNode(value, parent);
                    return parent.LeftChild;
                }
                
                return InsertIntoParentNode(parent.LeftChild, value);
            }

            if (value>parent.Value)
            {
                if (parent.RightChild == null)
                {
                    parent.RightChild = new TreeNode(value, parent);
                    return parent.RightChild;
                }
                
                return InsertIntoParentNode(parent.RightChild, value);
            }

            return null;    // если что-то пошло не так
        }

        public TreeNode GetNodeByValue(int value)
        {
            return GetNodeFromParent(GetRoot(), value);
        }

        public TreeNode GetNodeFromParent(TreeNode parent, int value)
        {
            if (value == parent?.Value)
                return parent;
            if (value < parent?.Value)
                return GetNodeFromParent(parent?.LeftChild, value);
            if (value > parent?.Value)
                return GetNodeFromParent(parent?.RightChild, value);

            return null;    // нода не найдена. например, если parent==null или нет дочерних элементов
        }

        public TreeNode GetRoot()
        {
            foreach (var node in nodesList)
            {
                if (node.Parent == null)
                    return node;
            }

            return null;    //на всякий случай, если по какой-то причине не найдем корень
        }

        public void PrintTree()
        {
            throw new NotImplementedException();        // ***************** ДОДЕЛАТЬ!! *****************
        }

        public void RemoveItem(int value)
        {
            throw new NotImplementedException();        // ***************** ДОДЕЛАТЬ!! *****************
        }
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

}
