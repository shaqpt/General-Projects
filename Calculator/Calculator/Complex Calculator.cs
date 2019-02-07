using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Complex_Calculator : Form
    {
        public double num1 = 0, num2 = 0, res = 0, c = 0/*Count*/, temp = 0/*result immediately after calculation; clears our when user hits C*/;
        public Complex_Calculator()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double Real, Imag;
            Real = Convert.ToInt16(textBox1.Text.ToString());
            Imag = Convert.ToInt16(textBox2.Text.ToString());
        }

        /*class Complex
        {
            public bool add = false, sub = false, div = false, mul = false, mod = false, dec = false, i = true, hasdec = false;

            public Complex() // initializing real and imaginary if no parameters
            {
                real = 0.0;
                imag = 0.0;
            }
            public Complex(double RE, double IM) // initializing real and imaginary
            {
                real = RE;
                imag = IM;
            }
            public Complex(Complex C) // initializes based on a complex
            {
                real = C.Real;
                imag = C.Imag;
            }

            private double imag;
            private double real;

            public static Complex operator +(Complex x, Complex y) // does the math of addition
            {
                add = true;
                return new Complex(x.Real + y.Real, x.Imag + y.Imag);
            }
            public static Complex operator -(Complex x, Complex y)// does the math of subtraction
            {
                return new Complex(x.Real - y.Real, x.Imag - y.Imag);
            }
            public static Complex operator /(Complex x, Complex y)// does the math of division
            {
                return new Complex((((x.Real * y.Real) + (x.Imag * y.Imag)) / ((y.Real * y.Real) + (y.Imag * y.Imag))), (((-x.Real * y.Imag) + (x.Imag * y.Real)) / ((y.Real * y.Real) + (y.Imag * y.Imag))));
            }
            public static Complex operator *(Complex x, Complex y)// does the math of multiplication
            {
                return new Complex(x.Real * y.Real + (-x.Imag * y.Imag), (x.Imag * y.Real) + (x.Real * y.Imag));
            }
        }
        private void equalbutton_Click(object sender, EventArgs e) // Code for Equal button
        {
            Complex result = new Complex();

            if (add) // for adding complex numbers
            {
                result = first + second;
                string STR = "";
                double firstpart = result.Real;
                double secondpart = result.Imag;
                if ((firstpart == 0))
                { STR = secondpart.ToString() + "i"; }
                if (secondpart == 0)
                { STR = firstpart.ToString(); }
                if ((secondpart < 0) && (firstpart != 0))
                { STR = firstpart.ToString() + secondpart.ToString() + "i"; }
                if ((secondpart > 0) && (firstpart != 0))
                { STR = firstpart.ToString() + secondpart.ToString("+#.######") + "i"; }

                Console.WriteLine("{0}", STR);
            }


            if (sub) // for subtracting complex numbers
            {
                result = first - second;
                string STR = "";
                double firstpart = result.Real;
                double secondpart = result.Imag;
                if ((firstpart == 0))
                { STR = secondpart.ToString() + "i"; }
                if (secondpart == 0)
                { STR = firstpart.ToString(); }
                if ((secondpart < 0) && (firstpart != 0))
                { STR = firstpart.ToString() + secondpart.ToString() + "i"; }
                if ((secondpart > 0) && (firstpart != 0))
                { STR = firstpart.ToString() + secondpart.ToString("+#.######") + "i"; }
                Console.WriteLine("{0}", STR);
            }

            if (div) // for dividing complex numbers
            {
                result = first / second;

                string STR = "";
                double check = result.Real + result.Imag;
                double firstpart = result.Real;
                double secondpart = result.Imag;
                    if ((secondpart > 0) && (firstpart != 0))
                        STR = firstpart.ToString() + secondpart.ToString("+#.#####") + "i";

                    if ((secondpart < 0) && (firstpart != 0))
                        STR = firstpart.ToString() + secondpart.ToString() + "i";

                    if ((firstpart == 0))
                        STR = secondpart.ToString() + "i";
                    Console.WriteLine("{0}", STR);

                    if (secondpart == 0)
                        STR = firstpart.ToString();
                }
            }

            if (mul)// for multipling complex numbers
            {
                result = first * second;
                string STR = "";
                double firstpart = result.Real;
                double secondpart = result.Imag;

                if ((firstpart == 0))
                { STR = secondpart.ToString() + "i"; }
                if (secondpart == 0)
                { STR = firstpart.ToString(); }
                if ((secondpart < 0) && (firstpart != 0))
                { STR = firstpart.ToString() + secondpart.ToString() + "i"; }
                if ((secondpart > 0) && (firstpart != 0))
                { STR = firstpart.ToString() + secondpart.ToString("+#.#####") + "i"; }
                Console.WriteLine("{0}", STR);
            }*/
        }
    }
