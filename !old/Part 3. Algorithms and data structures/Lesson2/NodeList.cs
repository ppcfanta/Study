using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lesson2
{
    public class NodeList : ILinkedList
    {
        private List<Node> nodeList;

        public NodeList()
        {
            nodeList = new List<Node>();
        }

        public void PrintNodeList()
        {
            var currNode = GetFirst();
            while (currNode != null)
            {
                Console.Write(currNode.Value+"\t");
                currNode = currNode.NextNode;
            }
        }
        public Node GetFirst()
        {
            foreach (var node in nodeList)
            {
                if (node.PrevNode == null)      // ищем первый элемент двусвязанного списка
                    return node;
            }
            return null;
        }
        public Node GetLast()
        {
            foreach (var node in nodeList)
            {
                if (node.NextNode == null)      // ищем последний элемент двусвязанного списка
                    return node;
            }
            return null;
        }

        public Node GetNodeByIndex(int index)
        {
            if (index > nodeList.Count - 1)
                return null;
            return nodeList[index];
        }

        public void AddNode(int value)
        {
            var prev = GetLast();
            var node = new Node(value, prev, null);
            if (prev!=null)
                prev.NextNode = node;
            nodeList.Add(node);
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node(value, node, node.NextNode);
            node.NextNode = newNode;
            nodeList.Add(newNode);
            if (node.NextNode != null)
                node.NextNode.PrevNode = newNode;

        }

        public Node FindNode(int searchValue)
        {
            foreach (var item in nodeList)
            {
                if (item.Value==searchValue)
                    return item;
            }
            return null;        // элемент не найден
        }

        public int GetCount()
        {
            return nodeList.Count;
        }

        public void RemoveNode(int index)
        {
            if (index > nodeList.Count - 1)
                return;     // если пытаемся удалить элемента по индексу, выходящему за рамки - ничего не делаем.

            nodeList[index - 1].NextNode = nodeList[index].NextNode;
            nodeList.RemoveAt(index);
        }

        public void RemoveNode(Node node)
        {
            Node prev, next;
            prev = node.PrevNode;
            next = node.NextNode;
            prev.NextNode = next;
            nodeList.Remove(node);
        }
    }

}
