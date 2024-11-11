using System.Linq.Expressions;

namespace ThreadSafe
{
    public class Programm
    {     
        public static void Main(string[] args)
        {
            StringProcessor sp = new StringProcessor();

            // Erstellen neuer Strings
                Task tCreateString = Task.Run(() => sp.CreateString());
            
            // Ausgabe der Zeichenketten
                Task tPrint = Task.Run(() =>
                {
                    while (true)
                    {
                        Task<StringItem> i = sp.GetStringItem();
                        StringItem item = i.Result;
                        Console.WriteLine($"{item.Value} (Checksum: {item.Checksum})");
                    }
                });

            // Task um auf die Abbruchbedingung zu warten
                Task tInterrupt = Task.Run(() =>
                {
                    if (Console.ReadKey().Key != 0)
                        Console.WriteLine("\n\n\n--------------------------------------------------");
                });

            tInterrupt.Wait();
            Console.WriteLine("Ende");
        }
    }

    public class StringProcessor
    {
        Queue<StringItem> personalQueue { get; set; }

        public StringProcessor()
        {
            personalQueue = new Queue<StringItem>();
        }

        public async Task CreateString(int wordLength = 6)
        {
            string word;
            int cntItems = 0;
            while (true)
            {
                word = "";
                Random r = new Random();
                string l = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                for (int i = 0; i < wordLength; i++) {
                    word = word + l[r.Next(l.Length)];
                };

                Random rnd = new Random();
                Thread.Sleep(rnd.Next(200, 501));
                personalQueue.Enqueue(new StringItem(word));
            }
        }
        public async Task<StringItem> GetStringItem()
        {
            while (true)
            {
                if(personalQueue.Count > 0)
                    return personalQueue.Dequeue();   
            }
        }
    }

    public class StringItem
    {
        public string Value { get; set; }
        public int Checksum { get; set; }

        public StringItem(string value)
        {
            this.Value = value;
            int calcChecksum = 0;
            for (int i = 0; i < this.Value.Length; i++)
            {
                calcChecksum = calcChecksum + (int)this.Value[i];
            }
            this.Checksum = calcChecksum % 196;
        }
    }
}
