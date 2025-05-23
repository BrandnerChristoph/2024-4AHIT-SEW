using System.Windows.Controls;
using System.Windows.Navigation;
using WpfContactsMvvm.ViewModel;

namespace WpfContactsMvvm.View
{
    /// <summary>
    /// Interaktionslogik für ContactsView.xaml
    /// </summary>
    public partial class ContactsView : Page
    {
        public ContactsView()
        {
            InitializeComponent();
            DataContext = new ContactViewModel();
        }
    }
}
