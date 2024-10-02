// Repository für Personen
using GenericRepository;

GenericRepository<Person> personRepository = new GenericRepository<Person>();

personRepository.Add(new Person { Id = 1, Name = "Max Mustermann" });
personRepository.Add(new Person { Id = 2, Name = "Anna Müller" });

Console.WriteLine("Alle Personen:");
personRepository.PrintAll();
Console.WriteLine("----------------------------------------");

var person = personRepository.GetById(1);
Console.WriteLine($"Person mit ID 1: {person}");

personRepository.Remove(2);
personRepository.PrintAll();
Console.WriteLine("----------------------------------------");

// Repository für Produkte
GenericRepository<Product> productRepository = new GenericRepository<Product>();

productRepository.Add(new Product { Id = 1, ProductName = "Laptop" });
productRepository.Add(new Product { Id = 2, ProductName = "Smartphone" });

Console.WriteLine("Alle Produkte:");
productRepository.PrintAll();
Console.WriteLine("----------------------------------------");

var product = productRepository.GetById(2);
Console.WriteLine($"Produkt mit ID 2: {product}");

productRepository.Remove(1);
productRepository.PrintAll();
Console.WriteLine("----------------------------------------");