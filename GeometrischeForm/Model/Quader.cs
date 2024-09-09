using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeForm.Model
{
    public class Quader : Form
    {
        public double Hoehe { get; set; }
        public double Breite { get; set; }
        public double Tiefe { get; set; }

        public Quader(string beschreibung, double h, double b, double t): base(beschreibung)
        {
            this.Hoehe = h;
            this.Breite = b;
            this.Tiefe = t;
        }
        public override double Oberflaeche(int nachkommastellen = 3)
        {
            return Math.Round((2 * this.Hoehe * this.Breite) + (2 * this.Hoehe * this.Tiefe) + (2 * this.Breite * this.Tiefe), nachkommastellen);
        }

        public override double Volumen(int nachkommastellen = 3)
        {
            return Math.Round(this.Hoehe * this.Breite * this.Tiefe, nachkommastellen);
        }
    }
}
