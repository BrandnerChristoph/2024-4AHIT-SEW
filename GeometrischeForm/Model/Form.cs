using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeForm.Model
{
    public abstract class Form
    {
        public string Beschreibung { get; set; }

        public Form(string beschreibung) {
            this.Beschreibung = beschreibung;
        }
        public abstract double Oberflaeche(int nachkommastellen = 3);
        public abstract double Volumen(int nachkommastellen = 3);

        public override string ToString()
        {
            return $"{this.Beschreibung} (Volumen: {this.Volumen()} | Oberfläche: Volumen: {this.Oberflaeche()})";
        }
    }
}
