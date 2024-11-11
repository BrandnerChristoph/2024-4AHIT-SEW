using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Aufgabe 1: Zähle von 1 bis 5
        Task task1 = Task.Run(() =>
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"Aufgabe 1: {i}");
                Thread.Sleep(500); // Warte 500 Millisekunden
            }
        });

        Task task2 = PrintLetters();
        
        Task.WaitAll(task1, task2);

        Console.WriteLine("Beide Aufgaben sind abgeschlossen.");
    }

    /// <summary>
    /// Ausgabe der Kleinbuchstaben mit einer Verzögerung von 200 Millisekunden
    /// </summary>
    /// <returns></returns>
    public async static Task PrintLetters()
    {
        for (int i = 97; i <= 122; i++)
        {
            Console.WriteLine($"Aufgabe 2: {(char)i}");
            await Task.Delay(200); // Warte 200 Millisekunden
        }

    }
}