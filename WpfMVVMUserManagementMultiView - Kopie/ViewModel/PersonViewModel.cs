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
using WpfMVVMUserManagementMultiView.Command;
using WpfMVVMUserManagementMultiView.Model;
using WpfMVVMUserManagementMultiView.Data;

namespace WpfMVVMUserManagementMultiView.ViewModel
{
    /// <summary>
    /// Die Verwaltung der Kontakt wird hier vorgenommen
    /// Weiters werden Befehle (Commands) für das UserInterface bereitgestellt
    /// </summary>
    class PersonViewModel : BaseViewModel
    {
        public Person SelectedContact { get; set; }
        //public Contact NewContact { get; set; } = new Contact();
        ///////////////////////////////////
        // Erweiterung um Eingabe zu leeren und Standardmäßig zu befüllen
        private Person _newContact;

        public Person NewContact
        {
            get => _newContact;
            set { 
                _newContact = value; 
                OnPropertyChanged(nameof(NewContact)); 
            }
        }        

        public ICommand AddContactCommand { get; }
        public ICommand DeleteContactCommand { get; }

        public PersonViewModel()
        {
            NewContact = new Person();
            AddContactCommand = new RelayCommand(AddContact);
            DeleteContactCommand = new RelayCommand(DeleteContact, CanDelete);
            LoadData();
        }

        private void AddContact(object obj)
        {
            if (NewContact is null) { 
                MessageBox.Show("keine Daten zum speichern", "No Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (NewContact.Errors.Count > 0) {
                string msg = "";
                foreach (var errMsg in NewContact.Errors.Values)
                    msg += "\n- " + errMsg.ToString();

                MessageBox.Show(NewContact.Errors.Count.ToString() + " Fehler bei der Eingabe!\n" + msg, 
                                    "Eingabefehler",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                return;
            }

            using var db = new MyAppContext();
            db.Persons.Add(new Person
                {
                    Name = NewContact.Name,
                    Firstname = NewContact.Firstname,
                    Birthday = NewContact.Birthday
                }
            );
            db.SaveChanges();
            db.Dispose();

            LoadData(); 
            
            NewContact = new Person();

            MessageBox.Show("Daten hinzugefügt", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanDelete(object obj) => SelectedContact != null;

        private void DeleteContact(object obj)
        {
            if (SelectedContact != null)
            {
                using var db = new MyAppContext();
                db.Persons.Remove(SelectedContact);
                db.SaveChanges();

                Contacts.Remove(SelectedContact);
                db.Dispose();

                SelectedContact = null;
            }
            
        }

        /// <summary>
        /// clear current list
        /// and load all Person-Objects from database and add to Contacts list
        /// </summary>
        private void LoadData()
        {
            Contacts.Clear();

            using var db = new MyAppContext();
            foreach (var p in db.Persons)
                Contacts.Add(p);
            db.Dispose();
        }
    }    
}
