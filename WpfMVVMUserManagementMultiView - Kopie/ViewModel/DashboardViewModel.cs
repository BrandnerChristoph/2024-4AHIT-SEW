using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMUserManagementMultiView.Data;
using WpfMVVMUserManagementMultiView.Model;

namespace WpfMVVMUserManagementMultiView.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        private int _contactCount;
        private int _oldestContactName;
        public int ContactCount
        {
            get {
                using var db = new MyAppContext();
                return db.Persons.Count();                
            }
        }
        public string OldestContactName
        {
            get
            {
                using var db = new MyAppContext();
                Person p = db.Persons.OrderBy(p => p.Birthday).FirstOrDefault();
                return $"{p.Firstname} {p.Name}";
            }
        }
        
    }
}
