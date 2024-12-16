using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.IO;

namespace Htl.Wy.Communication
{
    public class CommServer
    {
        private static List<TcpClient> connectedClients = new List<TcpClient>();

        private static async Task StartServerAsync(int port = 5000)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server gestartet. Warte auf Verbindungen...");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"Hostname: {IPAddress.Any}| Port: {port}");
            Console.ResetColor();
            Console.WriteLine("=======================================================");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                connectedClients.Add(client);
                //Console.WriteLine("Client verbunden!");
                HandleClientAsync(client); // Asynchron behandeln
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];

                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                MessageItem msgItem = JsonSerializer.Deserialize<MessageItem>(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{msgItem.SenderName} (from {msgItem.SenderIp} at {msgItem.CreatedAt}): ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{msgItem.Message} ");

                //await BroadcastMessageAsync(msgItem, client);

                var json = JsonSerializer.Serialize(msgItem);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(json));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler bei der Clientverarbeitung: {ex.Message}");
            }
            finally
            {
                //client.Close();
            }
        }

        /*
        private static async Task BroadcastMessageAsync(MessageItem messageItem, TcpClient sender)
        {
            //messageItem.Message = "Serverantwort: " + messageItem.Message;
            var json = JsonSerializer.Serialize(messageItem);

            foreach (TcpClient client in connectedClients)
            {
                //if (client != sender) // Nachricht nicht an mich selbst senden
                if(true)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        await stream.WriteAsync(Encoding.UTF8.GetBytes(json));
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{ex.Message}");
                    }
                    finally
                    {
                        Console.ResetColor();
                    }
                }
            }
        }
        */

        async static Task Main(string[] args)
        {            
            try
            {
                if (args.Length == 1)
                    await StartServerAsync(int.Parse(args[0])); // Start mit Parameter (Port)

                await StartServerAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}