using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    public class Node
    {
        public Node(int value, Node prevNode, Node nextNode)
        {
            Value = value;
            PrevNode = prevNode;
            NextNode = nextNode;
        }
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

}
