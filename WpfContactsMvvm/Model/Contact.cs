using System.ComponentModel;

namespace WpfContactsMvvm.Model
{
    class Contact : INotifyPropertyChanged
    {
        private string _name;
        private string _email;
        private string _phone;
        public string Name
        {
            get => _name;
            set { _name = value; 
                    OnPropertyChanged(nameof(Name)); 
            }
        }

        public string Email
        {
            get => _email;
            set { _email = value; 
                    OnPropertyChanged(nameof(Email)); 
            }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; 
                    OnPropertyChanged(nameof(Phone)); 
            }
        }

        // Interface Methode implementieren
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
