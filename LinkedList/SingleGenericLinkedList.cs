using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SingleGenericLinkedList<T>
    {
        GenericNode<T> FirstNode { get; set; } = null;

        public void Add(T contentData)
        {
            GenericNode<T> newNode = new GenericNode<T>(contentData);
            if (FirstNode == null)
            {
                // ersten Knoten einfügen
                FirstNode = newNode;
            }
            else
            {
                // Knoten am Ende einfügen
                GenericNode<T> current = FirstNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode; // beim aktuell letzten Knoten wird der neue Knoten hinzugefügt
            }
        }

        public void PrintList()
        {
            GenericNode<T> current = this.FirstNode;  // Start beim ersten Knoten
            while (current != null)
            {
                Console.Write(current.Content.ToString() + " -> ");
                current = current.Next;  // Gehe zum nächsten Knoten
            }
            Console.WriteLine("null");  // Ende der Liste
        }
    }
}
