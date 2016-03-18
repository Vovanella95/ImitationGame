using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationGame.Lab1.Models
{
    public class Ellipse
    {

        public Ellipse(double m0, double x0, double y0, double v0, double al0, double q0)
        {
            M = m0;
            X = x0;
            Y = y0;
            Vx = v0 * Math.Cos(al0);
            Vy = v0 * Math.Sign(al0);
            Q = q0;
        }


        public double X { get; set; }
        public double Y { get; set; }
        public double M { get; set; }
        public double Q { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }
        public double Alpha
        {
            get
            {
                return Math.Acos(Vx / V);
            }
        }
        public double V
        {
            get
            {
                return Math.Sqrt(Math.Pow(Vx, 2) + Math.Pow(Vy, 2));
            }
        }
        public string Color { get; set; }
        public string Margin
        {
            get
            {
                return string.Format("{0},{1},0,0", X, Y);
            }
        }
    }
}
