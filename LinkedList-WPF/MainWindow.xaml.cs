using LinkedList_WPF.Models;
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
using LinkedList_WPF.Models;
using System.Xml.Serialization;

namespace LinkedList_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyLinkedList<BankTransaction> BankTransactions { get; set; } = new MyLinkedList<BankTransaction>();
        public MainWindow()
        {
            InitializeComponent();
            this.BankTransactions = new MyLinkedList<BankTransaction>();
            /*
            this.BankTransactions.AddFirst(new BankTransaction(100, "Startguthaben"));
            this.BankTransactions.AddLast(new BankTransaction(1500, "Einzahlung"));
            this.BankTransactions.AddLast(new BankTransaction(350));
            this.BankTransactions.AddLast(new BankTransaction(-500, "Abhebung"));
            */

        }

        private void ShowViewer(BankTransaction highlightItem = null)
        {
            LinkedListViewer.Children.Clear();
            int itemCounter = 0;
            
            Node<BankTransaction> current = this.BankTransactions.Head;
            while (current != null)
            {
                Button btn = new Button();
                btn.Name = "node_" + itemCounter;
                btn.Content = $"Id: {current.Data.Id}\nDate: {current.Data.CreatedAt}\nAmount: {current.Data.Amount}\nInfo: {current.Data.Name}";
                if (current.Next != null)
                {
                    btn.Content += $"\nNext-Id: {current.Next.Data.Id}";
                    
                    Line newLine = new Line();

                    newLine.X1 = 160;
                    newLine.X2 = 160;
                    newLine.Y1 = (150 * itemCounter) + 20;
                    newLine.Y2 = (150 * (itemCounter+1)) + 20;

                    newLine.StrokeThickness = 1;
                    newLine.Stroke = Brushes.Black;

                    LinkedListViewer.Children.Add(newLine);

                    //canvas_scrollVwr.Height += 150 + 200;
                }
                else btn.Content += $"\nNext-Id: NULL";

                if (current.Data.Amount < 0) btn.Foreground = new SolidColorBrush(Colors.Red);
                
                btn.Margin = new Thickness(5, 5, 5, 5);
                btn.Width = 300;
                btn.Height = 100;

                Canvas.SetLeft(btn, 10);
                Canvas.SetTop(btn, (150 * itemCounter) + 10);

                if (highlightItem != null)
                {
                    if (highlightItem.Equals(current.Data))
                    {
                        btn.Background = new SolidColorBrush(Colors.Green);
                    }
                }

                LinkedListViewer.Children.Add(btn);
                itemCounter++;
                current = current.Next;  // Gehe zum nächsten Knoten
            }
        }
        /// <summary>
        /// gibt die grafische Darstellung der LinkedList in der GUI wieder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showLinkedList_Btn(object sender, RoutedEventArgs e)
        {
            ShowViewer();
        }

        /// <summary>
        /// sucht einen Knoten basierend auf der Bezeichnung (Name) oder dem Betrag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            BankTransaction searchItem = null;
            Node<BankTransaction> current = this.BankTransactions.Head;
            if (!string.IsNullOrEmpty(this.searchInput_Name.Text))
            {
                while (current != null)
                {
                    if (current.Data.Name.Contains(this.searchInput_Name.Text))
                    {
                        ShowViewer(current.Data);
                        break;
                    }
                    current = current.Next;  // Gehe zum nächsten Knoten
                }
            }
            else if (!string.IsNullOrEmpty(this.searchInput_Amount.Text))
            {
                while (current != null)
                {
                    if (current.Data.Amount.ToString() == this.searchInput_Amount.Text)
                    {
                        ShowViewer(current.Data);
                        break;
                    }
                    current = current.Next;  // Gehe zum nächsten Knoten
                }
            }
            else
            {
                MessageBox.Show("kein Suchparameter wurde eingegeben", 
                                    "fehlende Suchkriterien", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Error);
            }
            ClearTextBoxes();
        }

        /// <summary>
        /// fügt einen Knoten am Beginn der LinkedList hinzu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addStart_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.BankTransactions.AddFirst(new BankTransaction(double.Parse(amountInput_txtB.Text), 
                                                                nameInput_txtB.Text));

            ClearTextBoxes();
            ShowViewer();
            MessageBox.Show("Knoten wurde am Beginn hinzugefügt.");
        }

        /// <summary>
        /// fügt einen Knoten am Ende der LinkedList hinzu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addEnd_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.BankTransactions.AddLast(new BankTransaction(double.Parse(amountInput_txtB.Text),
                                                                nameInput_txtB.Text));

            ClearTextBoxes();
            ShowViewer();
            MessageBox.Show("Knoten wurde am Ende hinzugefügt.");
        }
        /// <summary>
        /// entfernt eine Knoten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void delItem_Btn_Click(object sender, RoutedEventArgs e)
        {
            Node<BankTransaction> current = this.BankTransactions.Head;
            if (!string.IsNullOrEmpty(this.delItem_txtB.Text))
            {
                while (current != null)
                {
                    if (current.Data.Id == this.delItem_txtB.Text)
                    {
                        this.BankTransactions.Remove(current.Data);
                        ShowViewer(current.Data);
                        return;
                    }
                    current = current.Next;  // Gehe zum nächsten Knoten
                }
                ClearTextBoxes();
                MessageBox.Show($"Der Knoten mit der ID {this.delItem_txtB.Text} konnte nicht gefunden werden!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                throw new Exception("keine Eingabe");
            }
        }


        /// <summary>
        /// leert alle Inhalte der Textboxen
        /// </summary>
        private void ClearTextBoxes()
        {
            nameInput_txtB.Text = string.Empty;
            amountInput_txtB.Text = string.Empty;
            delItem_txtB.Text = string.Empty;
            searchInput_Amount.Text = string.Empty;
            searchInput_Name.Text = string.Empty;
        }
    }
}