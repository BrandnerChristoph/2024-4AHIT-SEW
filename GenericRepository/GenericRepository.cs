using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
    public class GenericRepository<T> where T : IEntity
    {
        public List<T> items  = new List<T>();

        // Einfügen eines neuen Elements
        public void Add(T item)
        {
            items.Add(item);
            Console.WriteLine($"Item hinzugefügt: {item.Id}");
        }

        // Löschen eines Elements anhand der ID
        public void Remove(int id)
        {
            var item = items.Find(x => x.Id == id);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"Item mit ID {id} entfernt.");
            }
            else
            {
                Console.WriteLine($"Item mit ID {id} nicht gefunden.");
            }
        }

        // Abrufen eines Elements anhand der ID
        public T GetById(int id)
        {
            foreach (var item in items)
            {
                if (item.Id == id)
                    return item;
            }
            throw new Exception("Element wurde auf Basis der ID nicht gefunden!");

            // Alternativ-Implementierung
            //return items.Find(x => x.Id == id);
        }

        // Anzeigen aller Elemente
        public void PrintAll()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Item ID: {item.Id}");
            }
        }
    }
}
