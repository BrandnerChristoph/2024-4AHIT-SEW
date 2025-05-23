using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfContactsMvvm.Model;

namespace WpfContactsMvvm.ViewModel
{
    /// <summary>
    /// Die Verwaltung der Kontakt wird hier vorgenommen
    /// Weiters werden Befehle (Commands) für das UserInterface bereitgestellt
    /// </summary>
    class ContactViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public Contact SelectedContact { get; set; }
        //public Contact NewContact { get; set; } = new Contact();
        ///////////////////////////////////
        // Erweiterung um Eingabe zu leeren und Standardmäßig zu befüllen
        private Contact _newContact;

        public Contact NewContact
        {
            get => _newContact;
            set { _newContact = value; OnPropertyChanged(nameof(NewContact)); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        ///////////////////////////////////
        

        public ICommand AddContactCommand { get; }
        public ICommand DeleteContactCommand { get; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            NewContact = new Contact(); // Erweiterung um Eingabe zu leeren und Standardmäßig zu befüllen
            AddContactCommand = new RelayCommand(AddContact);
            DeleteContactCommand = new RelayCommand(DeleteContact, CanDelete);
        }

        private void AddContact(object obj)
        {
            if (NewContact is null) { 
                MessageBox.Show("keine Daten zum speichern", "No Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Contacts.Add(new Contact
            {
                Name = NewContact.Name,
                Email = NewContact.Email,
                Phone = NewContact.Phone
            });
            NewContact = new Contact();

            MessageBox.Show("Daten hinzugefügt", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanDelete(object obj) => SelectedContact != null;

        private void DeleteContact(object obj)
        {
            if (SelectedContact != null)
            {
                Contacts.Remove(SelectedContact);
                SelectedContact = null;
            }
        }
    }

    /// <summary>
    /// Bereitstellung von Befehlsverarbeitung
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
