using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Fraction
    {
        //Feilds
        private int w; //Whole Number
        private int n; //Numerator
        private int d; //Denominator

        //Properties; Apply get, set syntax for whole, numerator and denominator
        public int W { get { return w; } set { w = value; } } 
        public int N { get { return n; } set { n = value; } }
        public int D { get { return d; } set { d = value; } }

        public Fraction() // initialize the values
        {
            W = 0; 
            N = 0;
            D = 0;
        }

        public Fraction(int w, int n, int d) //For answer with a whole number, denominator, and whole number
        {
            W = w;
            N = n;
            D = d;
        }
        public Fraction(int n, int d) //for answer with only a numerator and denominator included, set whole number to zero
        {
            W = 0;
            N = n;
            D = d;
        }

        public Fraction(Fraction f)
        {
            this.W = f.W;
            this.N = f.N;
            this.D = f.D;
        }
        public Fraction(int a, Fraction b)
        {
            this.W = a;
            this.N = b.N;
            this.D = b.D;
        }
        public static bool TryParse(string s, out Fraction p)
        {
            string[] z;
            string[] y;
            bool w, n, d;
            int wi, ni, di;
            p = new Fraction();
            if (s == "") return false;
            s = s.Trim();
            { // correctly formats the UserInput into an appropiate format the code can use to run operations
                while (s.IndexOf("  ") >= 0)
                    s = s.Replace("  ", " ");
                while (s.IndexOf(" |") >= 0)
                    s = s.Replace(" |", "|");
                while (s.IndexOf("| ") >= 0)
                    s = s.Replace("| ", "|");
            }
            z = s.Split(' ');
            y = z[1].Split('|');
            w = Int32.TryParse(z[0], out wi);
            n = Int32.TryParse(y[0], out ni);
            d = Int32.TryParse(y[1], out di);
            if (w && n && d == true)
            {
                p = new Fraction(wi, ni, di);
                return true;
            }
            else
                return false;
        }
        public override string ToString()
        {
            string ts;
            ts = W.ToString() + " " + N.ToString() + "|" + D.ToString();
            return ts;
        }
        private Fraction Normalize()
        {
            int improper = this.W * this.D + this.N;
            int gcf = GCF(improper, this.D);
            int n = improper / gcf;
            int d = this.D / gcf;
            int w = n / d;
            n = n % d;
            return new Fraction(w, n, d);
        }
        private static int GCF(int a, int b) //returns the Greatest Common Factor
        {
            int i;
            int gcf = 1;
            for (i = 2; i <= Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0)
                    gcf = i;
            }
            return gcf;
        }
        private static int LCF(int a, int b) // returns the Least Common Factor
        {
            int l; //result of LCF
            l = (a * b) / GCF(a, b); // LCF = val1 * val2 over GCF of the two values
            return l;
        }
        public Fraction Denominator(int x)
        {
            Fraction a = this;
            int f; //factor
            if (x < this.D)
                return a;
            if (x % this.D != 0)
                return a;
            if (this.D != x)
            {
                f = x / this.D;
                a.D = x;
                a.N *= f;
            }
            return a;
        }
        public Fraction Reduce() //Reduces a Large Mixed Number into a Simplified Fraction/ simplified mixed number
        {
            Fraction a = this;
            while (a.N >= a.D)
            {
                a.N -= a.D;
                if (a.W < 0)
                    a.W--;
                else
                    a.W++;
            }
            return a;
        }
        public static Fraction operator +(Fraction x, Fraction y) //Addition operator
        {
            int ix, iy, lcd, z;
            if (x.D == 0)
                return y;
            else if (y.D == 0)
                return x;
            ix = x.W * x.D + x.N;
            iy = y.W * y.D + y.N;
            x = new Fraction(ix, x.D);
            y = new Fraction(iy, y.D);
            lcd = LCF(x.D, y.D);
            x = x.Denominator(lcd);
            y = y.Denominator(lcd);
            z = x.W + y.W;
            return new Fraction(x.N + y.N, lcd).Normalize();
        }
        public static Fraction operator -(Fraction x, Fraction y) //Subtraction operation
        {
            int ix, iy, lcd, z;
            if (x.D == 0)
                return y;
            else if (y.D == 0)
                return x;
            ix = x.W * x.D + x.N;
            iy = y.W * y.D + y.N;
            x = new Fraction(ix, x.D);
            y = new Fraction(iy, y.D);
            lcd = LCF(x.D, y.D);
            x = x.Denominator(lcd);
            y = y.Denominator(lcd);
            z = x.W + y.W;
            return new Fraction(x.N - y.N, lcd).Normalize();
        }

        public static Fraction operator *(Fraction x, Fraction y) //Multiplication operator
        {
            Fraction a = new Fraction();
            if (x.D == 0)
                return a;
            else if (y.D == 0)
                return a;
            return new Fraction(x.W * y.W, x.N * y.N, x.D * y.D).Normalize();
        }
        public static Fraction operator /(Fraction x, Fraction y) // Division operator
        {
            int ix, iy; //improper x and improper y
            ix = x.W * x.D + x.N;
             iy = y.W * y.D + y.N;
            x = new Fraction(ix, x.D);
            y = new Fraction(iy, y.D);
            return new Fraction(x.N * y.D, x.D * y.N).Normalize();
        }
    }
}
