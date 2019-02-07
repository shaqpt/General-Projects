//I, Shaqueir Tardif, certify this work as a product of my own and
//I have not collaborated with anyone else throughout the making of this program.
//I attempted to create the complex calculator but simply could not figure it out.


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
    public partial class Form1 : Form
    {
        public double num1 = 0, num2 = 0, res = 0, c = 0/*Count*/, temp = 0/*result immediately after calculation; clears our when user hits C*/;
        public bool add = false, sub = false, div = false, mul = false, mod = false, dec = false, i = true, hasdec = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//1
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 1; 
                    num1 = Convert.ToDouble(num1 + "." + temp); // add number to right side of decimal place; convert entire string to a double
                    Answerbox.Text = num1.ToString(); // display result
                    
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 1;
                    Answerbox.Text = num1.ToString();
                }
            }
            else // num2 becomes 1 if theres already a value for num1
            {
                if (dec == true)
                {
                    temp = 1;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 1;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//2
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 2;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 2;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 2;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 2;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//3
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 3;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 3;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 3;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 3;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//4
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 4;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 4;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 4;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 4;
                    Answerbox.Text = num2.ToString();
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)//5
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 5;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 5;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 5;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 5;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)//6
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 6;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 6;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 6;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 6;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)//7
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 7;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 7;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 7;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 7;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)//8
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 8;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 8;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 8;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 8;
                    Answerbox.Text = num2.ToString();
                }
            }
    }

        private void button9_Click(object sender, EventArgs e)//9
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 9;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10 + 9;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 9;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10 + 9;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void button0_Click(object sender, EventArgs e)//0
        {
            if (!add && !sub && !div && !mul && !mod)
            {
                if (dec == true)
                {
                    temp = 0;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num1 = num1 * 10;
                    Answerbox.Text = num1.ToString();
                }
            }
            else
            {
                if (dec == true)
                {
                    temp = 0;
                    num1 = Convert.ToDouble(num1 + "." + temp);
                    Answerbox.Text = num1.ToString();
                    c = c * 10;
                }
                else
                {
                    num2 = num2 * 10;
                    //num2 =+ 10;
                    Answerbox.Text = num2.ToString();
                }
            }
        }

        private void Answerbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)//decimal
        {
            dec = true; // will result in a decimal value
            if (!hasdec)
            {
                if (Answerbox.Text.Length != 0)
                {
                    if (Answerbox.Text != "0")
                    {
                        Answerbox.Text = Answerbox.Text + ".";
                        hasdec = true;
                    }
                    else
                    {
                        Answerbox.Text = "0.";
                    }
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Equalbutton_Click(object sender, EventArgs e)//equal
        {
            if (add == true)
            {
                res = num1 + num2;
                Answerbox.Text = res.ToString();
                add = false;
                num1 = res;
                num2 = 0;
                res = 0;
            }

            if (sub == true)
            {
                res = num1 - num2;
                Answerbox.Text = res.ToString();
                sub = false;
                num1 = res;
                num2 = 0;
                res = 0;

            }
            if (div == true)
            {
                if (num2 == 0)
                { num2 = 1; }
                res = num1 / num2;
                Answerbox.Text = res.ToString();
                div = false;
                num1 = res;
                num2 = 0;
                res = 0;

            }

            if (mod == true)
            {
                mod = false;

                res = num1 % num2;
                Answerbox.Text = res.ToString();
                num1 = res;
                num2 = 0;
                res = 0;

            }

            if (mul == true)
            {


                mul = false;
                res = num1 * num2;
                Answerbox.Text = res.ToString();
                num1 = res;
                num2 = 0;
                res = 0;


            }

            dec = false;
        }
        private void button12_Click(object sender, EventArgs e)//mod
        {
            mod = true;
            res = num1 % num2;
            Answerbox.Text = res.ToString();
            num1 = res;
            num2 = 0;
            res = 0;
            dec = false;
            c = 10;
        }

        private void Divisionbutton_Click(object sender, EventArgs e)//div
        {
            div = true;
            num2 = 1;
            res = num1 / num2;
            Answerbox.Text = res.ToString();
            num1 = res;
            num2 = 0;
            res = 0;
            dec = false;
            c = 10;
        }

        private void Multiplicationbutton_Click(object sender, EventArgs e)//mul
        {
          mul = true;
          num2 = 1;
          res = num1 * num2;
          Answerbox.Text = res.ToString();
          num1 = res;
          num2 = 0;
          res = 0;
          dec = false;
          c = 10;
        }

        private void minusbutton_Click(object sender, EventArgs e)//sub
        {
            sub = true;
            res = num1 - num2;
            Answerbox.Text = res.ToString();
            num1 = res;
            num2 = 0;
            res = 0;
            dec = false;
            c = 10;
        }

        private void additionbutton_Click(object sender, EventArgs e)//plus
        {
            add = true;
            res = num1 + num2;
            Answerbox.Text = res.ToString();
            num1 = res;
            num2 = 0;
            res = 0;
            dec = false;
            c = 10;
        }
        private void button16_Click(object sender, EventArgs e)//complex
        {

        }

        private void clearentrybutton_Click(object sender, EventArgs e)//CE
        {
            num2 = 0.0;
            temp = 0.0;
            c = 10;
            dec = false;
            Answerbox.Text = num1.ToString();
        }

        private void clearbutton_Click(object sender, EventArgs e)//C
        {
            num1 = 0.0;
            Answerbox.Text = num1.ToString(); // clear everything, keeps temp value the same
            num2 = 0.0;
            //temp = temp; // temp isn't being changed here
            c = 10;
            i = true;
            dec = false;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void complexformbutton_Click(object sender, EventArgs e)
        {
            Complex_Calculator frm = new Complex_Calculator();
            frm.Show();
        }
    }
}
