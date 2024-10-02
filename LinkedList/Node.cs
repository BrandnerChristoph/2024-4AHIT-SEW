using GeometrischeForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public string Content { get; set; }
        public Node Next { get; set; }

        public Node(string content, Node next = null) {
            this.Content = content;
            this.Next = next;
        }
    }
}


