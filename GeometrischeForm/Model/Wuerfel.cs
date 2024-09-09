using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeForm.Model
{
    public class Wuerfel : Form
    {
        public double Laenge { get; set; } 
        public Wuerfel(string beschreibung, double laenge) : base(beschreibung)
        {
            this.Laenge = laenge;
        }
        public override double Oberflaeche(int nachkommastellen = 3)
        {
            return Math.Round(6 * this.Laenge * this.Laenge, nachkommastellen);
        }

        public override double Volumen(int nachkommastellen = 3)
        {
            return Math.Round(this.Laenge * this.Laenge * this.Laenge, nachkommastellen);
        }
    }
}
