using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMUserManagementMultiView.Model;

namespace WpfMVVMUserManagementMultiView.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Contacts { get; set; } = new ObservableCollection<Person>();
        public int GetContatsNum { get { return ((Contacts != null) ? Contacts.Count : 0); } }

        public BaseViewModel() {

            
        }

        // Implementierung der INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
