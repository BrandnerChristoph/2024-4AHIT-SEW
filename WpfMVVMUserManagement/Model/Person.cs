using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMUserManagement.Model
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name;
        private string _firstname;
        private DateTime? _birthday;
        private int _age;

        
        public int Id { get; set; }
        
        public string Name { 
            get => _name;
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }            
        }

        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        public DateTime? Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
                OnPropertyChanged(nameof(Age));
            }
        }
        public int? Age {
            get {
                return Birthday.HasValue ? (int)DateTime.Now.Subtract(Birthday.Value).TotalDays / 364 : default(int?);
            }
        }

        // IDataErrorInfo START
            public string Error
            {
                get { throw new NotImplementedException(); }
            }
            public string this[string columnName]
            {
                get 
                {
                    CollectErrors();
                    return Errors.ContainsKey(columnName) ? Errors[columnName] : string.Empty;
                }
            }
        // IDataErrorInfo ENDE

        // Error Collection START
            public Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();

            public void CollectErrors()
            {
                Errors.Clear();
                if (string.IsNullOrEmpty(Firstname))
                    Errors.Add(nameof(Firstname), "Vorname darf nicht leer sein!");

                if (string.IsNullOrEmpty(Name))
                    Errors.Add(nameof(Name), "Name darf nicht leer sein!");

                if (Age.HasValue)
                {
                    if (Age < 18)
                        Errors.Add(nameof(Age), "Alterslimit unterschritten!");
                } else
                {
                Errors.Add(nameof(Age), "Alter darf nicht leer sein. Geben Sie ein Geburtsdatum an!");
                }
                    // weitere checks kommen hier
            }
        // Error Collection Ende


        // INotifyPropertyChanged START
            public event PropertyChangedEventHandler? PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        // INotifyPropertyChanged ENDE

    }
}
