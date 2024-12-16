using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommunicationClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Host_txtB.Text = "127.0.0.1";
            Port_txtB.Text = "5000";
        }
        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageBox_txtB.Text;

            if (string.IsNullOrWhiteSpace(message))
            {   
                MessageBox.Show("Bitte geben Sie eine Nachricht ein.");
                return;
            }

            try
            {
                string hostName = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

                MessageItem response = await SendMessageToServerAsync(new MessageItem(message, myIP, UserName_txtB.Text));
                ResponseBox_lstB.Items.Add($"Serverresponse: {response.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }

        private async Task<MessageItem> SendMessageToServerAsync(MessageItem message)
        {
            using (TcpClient client = new TcpClient(Host_txtB.Text, int.Parse(Port_txtB.Text)))
            {
                NetworkStream stream = client.GetStream();
                var json = JsonSerializer.Serialize(message);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(json), 0, Encoding.UTF8.GetBytes(json).Length);


                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                //return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return JsonSerializer.Deserialize<MessageItem>(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
        }
    }
}