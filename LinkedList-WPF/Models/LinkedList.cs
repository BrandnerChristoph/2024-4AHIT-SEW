using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_WPF.Models
{
    public class MyLinkedList<T>
    {
        public Node<T> Head {  get; set; }
        public MyLinkedList() {
            this.Head = null;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T data)
        {
            if (Head == null)
            {
                AddFirst(data);
                return;
            }

            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node<T>(data);
        }

        public bool Remove(T data)
        {
            if (Head == null) return false;

            if (Head.Data.Equals(data))
            {
                Head = Head.Next;
                return true;
            }

            Node<T> current = Head;
            while (current.Next != null && !current.Next.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current.Next == null) return false;

            current.Next = current.Next.Next;
            return true;
        }

        public Node<T> Find(T data)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return current;
                current = current.Next;
            }
            return null;
        }
    }
}
