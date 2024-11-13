using System.Diagnostics.Metrics;
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

namespace Task_CancellationToken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource cts;
        public MainWindow()
        {
            InitializeComponent();
            startBtn.IsEnabled = true;
            cancelBtn.IsEnabled = false;
        }

        /* // Alernative mit fehlender Nebenläufigkeit
        private async void Start_btn(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                progessBar.Value = i;
                progessLbl.Content = i.ToString() + "%";
            }
        }
        */
        
        private async void Start_btn(object sender, RoutedEventArgs e)
        {
            startBtn.IsEnabled = false;
            cancelBtn.IsEnabled = true;

            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;    // Gibt eine Benachrichtigung darüber weiter, dass Vorgänge abgebrochen werden sollen.

            /////////////////////////////////////////////////////////////////
            /// Progress von int - Rückgabe über die Methode Report() in Zeile 76
            var progress = new Progress<int>(value =>   // Wert aus dem Report wird in weiterer Folge verwendet
            {
                progessBar.Value = value;               // Verwenden in ProgressBar
                progessLbl.Content = value + "%";       // Verwenden in ProgressLabel
            });

            try
            {
                await Task.Run(() => LoopToFinished(progress, token));
                progessLbl.Content = "Verarbeitung fertiggestellt.";
            }
            catch (OperationCanceledException ex) { 
                progessLbl.Content = "Abgebrochen durch Benutzer!"; 
            }
            finally
            {
                cts.Dispose();
                startBtn.IsEnabled = true;
                cancelBtn.IsEnabled = false;
            }
        }
        void LoopToFinished(IProgress<int> progessBar, CancellationToken token)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                progessBar.Report(i);                   // Berichtet über eine Statusänderung

                token.ThrowIfCancellationRequested();   // Wirft eine Exception, wenn Abbruch ausgelöst wurde
            }
        }

        private void Cancel_btn(object sender, RoutedEventArgs e)
        {
            cts.Cancel();   // Übermittelt eine Abbruchanforderung
        }
    }
}