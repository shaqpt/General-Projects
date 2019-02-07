//I, Shaqueir Tardif, worked in collaboration with Chamberlain Egbunike.
//However, the code submitted is that of my own and not a copy of anyone else's.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool OK = true;
            string shape;
            OK = GetYesNo("Would you like to draw another shape: ", "?Invalid - Please reenter");
            do
            {
                Console.Clear();                            //Clear Console after drawing previous shape
                Console.SetCursorPosition(0, 0);            //Reset Cursor to top of window
                shape = GetShapeRequest("What shape would you like to draw (enter either Line, " +
                "Triangle, Rectangle, Parallelogram, or Circle: ", "Please enter either Line, Triangle, Rectangle, Parallelogram, Circle");
                GetShape(shape); //draw the shape
                OK = GetYesNo("Would you like to draw another shape: ", "?Invalid - Please reenter"); //ask user if they wish to continue or end program
            } while (OK);
        }

        static void GetShape(string shape)
        {
            int xs, ys, xe, ye, r;
            switch (shape)
            { 
                    case "L": case "LINE": //Draw Line
                    {
                        xs= GetInteger("Please Enter X starting Point: ", "?Please enter a valid integer");
                        ys = GetInteger("Please Enter Y starting Point: ", "?Please enter a valid integer");
                        xe = GetXleftedge("Please Enter X ending Point: ", "?Please enter a valid integer",ys);
                        ye = GetInteger("Please Enter Y ending Point: ", "?Please enter a valid integer");
                        Line myLine = new Line(xs, ys, xe, ye);
                        Console.Clear();
                        myLine.draw();
                        Console.SetCursorPosition(0, 0);
                        break;
                    }
                    
                case "T": case "TRIANGLE": //Draw Triangle
                    {
                        xs = GetInteger("How many units tall?: ", "?Please enter a valid integer");
                        ys = GetInteger("How many units wide?: ", "?Please enter a valid integer");
                        xe = GetXleftedge("How many units from left edge?: ", "?Please enter a valid integer",ys);
                        ye = GetInteger("How many units from top edge?: ", "?Please enter a valid integer");
                        Rtriangle myRtriangle = new Rtriangle(xs, ys, xe, ye);
                        Console.Clear();
                        myRtriangle.draw();
                        Console.SetCursorPosition(0, 0);
                        break;
                    }

                case "R": case"RECTANGLE": // Draw Rectangle
                    {
                        xs = GetInteger("How many units tall?: ", "?Please enter a valid integer");
                        ys = GetInteger("How many units wide?: ", "?Please enter a valid integer");
                        xe = GetXleftedge("How many units from left edge?: ", "?Please enter a valid integer", ys);
                        ye = GetInteger("How many units from top edge?: ", "?Please enter a valid integer");
                        Rectangle myRectangle = new Rectangle(xs, ys, xe, ye);
                        Console.Clear();
                        myRectangle.draw();
                        Console.SetCursorPosition(0, 0);
                        break;
                    }

                case "C": case"CIRCLE": //Draw Circle
                    {
                        xs = GetInteger("Please Enter X scale: ", "?Please enter a valid integer");
                        ys = GetInteger("Please Enter Y scale: ", "?Please enter a valid integer");
                         r = GetInteger("Please Enter radius: ", "?Please enter a valid integer");                       
                        Circle myCircle = new Circle(xs, ys, r);
                        Console.Clear();
                        myCircle.draw();
                        Console.SetCursorPosition(0, 0);
                        break;
                    }

                case "P": case"PARALLELOGRAM": //Draw Parallelogram
                    {
                        xs = GetInteger("How many units tall?: ", "?Please enter a valid integer");
                        ys = GetInteger("How many units wide?: ", "?Please enter a valid integer");
                        xe = GetXleftedge("How many units from left edge?: ", "?Please enter a valid integer", ys);
                        ye = GetInteger("How many units from top edge?: ", "?Please enter a valid integer");
                        Parallelogram myParallelogram = new Parallelogram(xs, ys, xe, ye);
                        Console.Clear();
                        myParallelogram.draw();
                        Console.SetCursorPosition(0, 0);
                        break;
                    }
                        default: 
                    {
                        Console.WriteLine("?Invalid command. Please reenter. ");
                        break;
                    }
                            
                }
            }
        static bool GetYesNo(string prompt, string error)
        {
            string[] YN = { "YES", "Y", "NO", "N" };
            string ans = GetString(prompt, YN, error);
            return ans == "YES" || ans == "Y";
        }
        static string GetString(string prompt, string[] valid, string error)
        {
            string OKonse;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                OKonse = Console.ReadLine().ToUpper();
                foreach (string s in valid)
                {
                    if (OKonse == s.ToUpper())
                    {
                        OK = true;
                    }
                }
                if (!OK)
                {
                    Console.WriteLine(error);
                }
            } while (!OK);
            return OKonse;
        }
        static string GetShapeRequest(string prompt ,string error)
        {
            string[] ID = { "LINE", "L", "TRIANGLE", "T", "RECTANGLE","R", "PARALLELOGRAM","P", "CIRCLE", "C" };
            string ans = GetString(prompt, ID, error);
            return ans;
        }
        static int GetInteger(string prompt, string error)
        {
            int result;
            string userInput;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                OK =Int32.TryParse(userInput, out result);
                if (result > 80 || result < 1)
                {
                    Console.WriteLine("Please enter a valid integer between 1 and 79");
                    OK = false;
                }
                else
                    if (!OK) Console.WriteLine(error);
            } while (!OK);
            return result;
        }
        static int GetXleftedge(string prompt, string error, int wide) //
        {
            int result;
            string userInput;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                OK = Int32.TryParse(userInput, out result);
                if (result > 80 || result < 1)
                {
                    Console.WriteLine("Please enter a valid integer between 1 and 79");
                    OK = false;
                }
                else
                    if (!OK) Console.WriteLine(error);
                if(result+wide>Console.WindowWidth-1)
                { 
                    Console.WriteLine("Please enter a valid integer less than {0}", ((Console.WindowWidth-1)-wide));
                    OK = false;
                }
                     else
                    if (!OK) Console.WriteLine(error);
            } while (!OK);
            return result;
        }
    }


}

