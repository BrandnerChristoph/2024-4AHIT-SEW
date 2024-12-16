using JsonInterface.Models;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace JsonInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<School> SchoolItems = new List<School>();
        public MainWindow()
        {
            InitializeComponent();
            LoadJsonFileAsync("https://www.salzburg.gv.at/ogd/645dbdfe-857f-4485-b111-b88d5b2f32d0/Schulstandorte.json");
        }

        private async Task LoadJsonFileAsync(string strDownloadUrl)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string json = (new WebClient()).DownloadString(strDownloadUrl);
                this.SchoolItems = JsonConvert.DeserializeObject<List<School>>(json);
                /*
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(strDownloadUrl);

                    // If the response is successful, we'll 
                    // interpret the response as Json 
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ToString();
                        this.SchoolItems = JsonConvert.DeserializeObject<List<School>>(json); 
                    }
                }
                */
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}