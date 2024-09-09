using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeForm.Model
{
    public class Kugel : Form
    {
        public double Radius { get; set; }

        public Kugel(string beschreibung, double radius) : base(beschreibung) {
            this.Radius = radius;
        }
        public override double Oberflaeche(int nachkommastellen = 3)
        {
            return Math.Round(4 * Math.PI * Math.Pow(this.Radius, 2), nachkommastellen);
        }

        public override double Volumen(int nachkommastellen = 3)
        {
            return Math.Round((4 / 3) * Math.PI * Math.Pow(this.Radius, 3), nachkommastellen);
        }
    }
}
