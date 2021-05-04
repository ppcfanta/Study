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

        public BSearchTree()
        {
            nodesList = new List<TreeNode>();
        }
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
            var treeStruct = TreeHelper.GetTreeInLine(this);
            int posX = 50;
            foreach (var node in treeStruct)
            {
                PrintNode(node.Node, posX, node.Depth);

                if (node.Node.LeftChild != null)
                    PrintNode(node.Node.LeftChild, posX - 15, node.Depth+1);
                if (node.Node.RightChild != null)
                    PrintNode(node.Node.RightChild, posX + 15, node.Depth+1);
            }

        }

        private void PrintNode(TreeNode node, int cursorPos, int cursorY)
        {
            Console.SetCursorPosition(cursorPos, cursorY);
            Console.WriteLine($"{node.Value}");
        }

        public void RemoveItem(int value)
        {
            TreeNode nodeToDel = GetNodeByValue(value);
            DelNode(nodeToDel);
        }

        private void DelNode(TreeNode nodeToDel)
        {
            if (nodeToDel.LeftChild == null && nodeToDel.RightChild == null)    // если у ноды нет потомков
            {
                DelMeFromParent(nodeToDel);
                nodesList.Remove(nodeToDel);
                nodeToDel = null;
                return;     //  ветку перестраивать не нужно, выходим
            }

            var childNodeList = new List<TreeNode>();
            AddChildNodes(ref childNodeList, nodeToDel);    // получаем список дочерних нод
            foreach (var node in childNodeList)
                nodesList.Remove(node);     // удаляем дочрние ноды из основного списка дерева

            foreach (var node in childNodeList)
                AddItem(node.Value);    // добавляем все дочерние ноды заново в дерево(с перестроением)

            childNodeList.Clear();
        }
        
        private void DelMeFromParent(TreeNode nodeToDel)
        {
            if (nodeToDel.Parent.LeftChild.Equals(nodeToDel))   // если удаляемая нода - левый потомок своего родителя
                nodeToDel.LeftChild = null;
            if (nodeToDel.Parent.RightChild.Equals(nodeToDel))  // если правый
                nodeToDel.RightChild = null;
        }
        private void AddChildNodes(ref List<TreeNode> listOfChildren, TreeNode rootNode)
        {
            if (rootNode.LeftChild != null)
            {
                listOfChildren.Add(rootNode.LeftChild);
                AddChildNodes(ref listOfChildren, rootNode.LeftChild);
            }
            if (rootNode.RightChild != null)
            {
                listOfChildren.Add(rootNode.RightChild);
                AddChildNodes(ref listOfChildren, rootNode.RightChild);
            }

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
