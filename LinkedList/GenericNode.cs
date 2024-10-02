using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class GenericNode<T> // generische Klasse
    {
        public T Content { get; set; }
        public GenericNode<T> Next { get; set; }

        public GenericNode(T content, GenericNode<T> next = null)
        {
            this.Content = content;
            this.Next = next;
        }
    }
}
