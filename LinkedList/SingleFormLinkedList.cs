using GeometrischeForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SingleFormLinkedList
    {
        FormNode FirstNode { get; set; } = null;

        public void Add(Form form)
        {
            FormNode newNode = new FormNode(form);
            if (FirstNode == null)
            {
                // ersten Knoten einfügen
                FirstNode = newNode;
            }
            else
            {
                // Knoten am Ende einfügen
                FormNode current = FirstNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode; // beim aktuell letzten Knoten wird der neue Knoten hinzugefügt
            }
        }
        public void Remove(FormNode form)
        {
            if (this.FirstNode == null)  // Wenn die Liste leer ist
            {
                Console.WriteLine("Liste ist leer.");
                return;
            }

            // Wenn der Kopf entfernt werden soll
            if (this.FirstNode.Content.Equals(form))
            {
                this.FirstNode = this.FirstNode.Next;  // Setze den Kopf auf den nächsten Knoten
                return;
            }

            // Durchlaufe die Liste, um den Knoten zu finden, der entfernt werden soll
            FormNode current = this.FirstNode;
            FormNode previous = null;
            while (current != null && !current.Content.Equals(form))
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)  // Wenn der Wert nicht gefunden wurde
            {
                Console.WriteLine($"{form.ToString()} nicht in der Liste gefunden.");
                return;
            }

            // Entferne den Knoten, indem der Zeiger des vorherigen Knotens auf den nächsten gesetzt wird
            previous.Next = current.Next;
        }

        public void PrintList()
        {
            FormNode current = this.FirstNode;  // Start beim ersten Knoten
            while (current != null)
            {
                Console.Write(current.Content.ToString() + " -> ");
                current = current.Next;  // Gehe zum nächsten Knoten
            }
            Console.WriteLine("null");  // Ende der Liste
        }
    }
}
