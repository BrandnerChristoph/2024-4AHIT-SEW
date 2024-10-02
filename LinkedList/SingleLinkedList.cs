using GeometrischeForm.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SingleLinkedList
    {
        Node FirstNode { get; set; } = null;

        public void Add(string strInput)
        {
            Node newNode = new Node(strInput);
            if (FirstNode == null)
            {
                // ersten Knoten einfügen
                FirstNode = newNode;
            } else
            {
                // Knoten am Ende einfügen
                Node current = FirstNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                // beim aktuell letzten Knoten wird der neue Knoten hinzugefügt
                current.Next = newNode; 
            }
        }
        public void Remove(string strToRemove)
        {
            if (this.FirstNode == null)  // Wenn die Liste leer ist
            {
                Console.WriteLine("Liste ist leer.");
                return;
            }

            // Wenn der Kopf entfernt werden soll
            if (this.FirstNode.Content== strToRemove)
            {
                this.FirstNode = this.FirstNode.Next;  // Setze den Kopf auf den nächsten Knoten
                return;
            }

            // Durchlaufe die Liste, um den Knoten zu finden, der entfernt werden soll
            Node current = this.FirstNode;
            Node previous = null;
            while (current != null && current.Content != strToRemove)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)  // Wenn der Wert nicht gefunden wurde
            {
                Console.WriteLine($"Wert {strToRemove} nicht in der Liste gefunden.");
                return;
            }

            // Entferne den Knoten, indem der Zeiger des vorherigen Knotens auf den nächsten gesetzt wird
            previous.Next = current.Next;
        }



        public void PrintList()
        {
            Node current = this.FirstNode;  // Start beim ersten Knoten
            while (current != null)
            {
                Console.Write(current.Content + " -> ");
                current = current.Next;  // Gehe zum nächsten Knoten
            }
            Console.WriteLine("null");  // Ende der Liste
        }

        public void printListRec()
        {
            this.PrintRecImpl(this.FirstNode);

        }
        private void PrintRecImpl(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.Content + " -> ");
            PrintRecImpl(node.Next);
        }
    }
}
