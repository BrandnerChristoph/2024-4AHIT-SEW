using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstereiVerwaltungMVVM.Model
{
    public class Osterei
    {
        public int Id { get; set; }
        public string Farbe { get; set; }
        public string Muster { get; set; }
        public DateTime VerstecktAm { get; set; }
        public string VerstecktOrt { get; set; }
    }
}
