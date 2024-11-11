using System.Diagnostics;

namespace Spinner
{
    public class MySpinner
    {
        static bool runSanduhr = true;
        static Stopwatch myStopwatch = new Stopwatch();

        public static void Main(string[] args)
        {
            Console.WriteLine("Beliebige Taste drücken, um Spinner zu beenden\n\n");

            // Threads erzeugen
                Thread tSanduhr = new Thread(ProcessSpinner);
                Thread tInput = new Thread(() => ReadInput());

            // Starten der Threads
                tSanduhr.Start();
                myStopwatch.Start();
                tInput.Start();
        }

        static void ProcessSpinner()
        {
            char[] spinnerChars = ['-', '\\', '|', '/'];
            int index = 0;

            while (runSanduhr)
            {
                Console.Write($"\r{spinnerChars[index]}");
                index = (index + 1) % spinnerChars.Length;
                Thread.Sleep(100);
            }
        }

        static void ReadInput()
        {
            if (Console.ReadKey().Key != 0)
            {
                myStopwatch.Stop();
                runSanduhr = false;
                Console.Clear();
                Console.WriteLine("\nProgramm beendet");
                Console.WriteLine($"Spinner ist {(double)myStopwatch.ElapsedMilliseconds/1000} Sekunden gelaufen.\n\n");
            }
        }
    }
}