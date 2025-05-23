using OstereiVerwaltungMVVM.Data;
using OstereiVerwaltungMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OstereiVerwaltungMVVM.ViewModel
{
    class OstereiViewModel
    {
        private Osterei _selectedOsterei;
        public ObservableCollection<Osterei> Ostereier { get; set; }

        public Osterei SelectedOsterei
        {
            get => _selectedOsterei;
            set { _selectedOsterei = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public OstereiViewModel()
        {
            Ostereier = new ObservableCollection<Osterei>();
            LoadData();

            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void LoadData()
        {
            using var db = new OstereiContext();
            foreach (var ei in db.Ostereier)
                Ostereier.Add(ei);
        }

        private void Add()
        {
            var neuesEi = new Osterei { VerstecktAm = DateTime.Now };
            Ostereier.Add(neuesEi);
            SelectedOsterei = neuesEi;
        }

        private void Save()
        {
            if (SelectedOsterei == null) return;

            using var db = new OstereiContext();
            if (SelectedOsterei.Id == 0)
                db.Ostereier.Add(SelectedOsterei);
            else
                db.Ostereier.Update(SelectedOsterei);
            db.SaveChanges();
        }

        private void Delete()
        {
            if (SelectedOsterei == null) return;

            using var db = new OstereiContext();
            db.Ostereier.Remove(SelectedOsterei);
            db.SaveChanges();

            Ostereier.Remove(SelectedOsterei);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
