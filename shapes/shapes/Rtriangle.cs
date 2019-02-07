using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    class Rtriangle : Shape
    {
        private int unitT, unitW;

        public Rtriangle()
        {
            unitT = unitW = 0;
            Redge = Tedge = 0;
        }
        public Rtriangle(int tall, int wide, int redge, int tedge)
        {
            unitT = tall; 
            unitW = wide; 
            Redge = redge; 
            Tedge = tedge;
        }
        public override void draw()
        {
            int horiz = Redge, vert = Tedge;//Prints y movements 
            
            for (int i = 1; i <=unitT-1; i++)
            {
                writeATXY(horiz, vert, "*");
                vert++;
            }

            for (int j = 1; j <= unitW; j++) //prints x movement
            {
                writeATXY(horiz, vert, "*");
                horiz++;
            }
             double m = Convert.ToDouble(vert - Tedge) / Convert.ToDouble(horiz - Redge);
                double b = Convert.ToDouble(Tedge) - m * Convert.ToDouble(Redge);
                double x1, y1, x2, y2, x, y;
            if (Math.Abs(m) < 1.0)                                          // We need to step x, calculate y. Make sure x1 < x2
                {                           
                    if (Redge < horiz)
                    { 
                        x1 = Redge; 
                        y1 = Tedge; 
                        x2 = horiz; 
                        y2 = vert; 
                    }
                    else
                    { 
                        x1 = horiz; 
                        y1 = vert; 
                        x2 = Redge; 
                        y2 = Tedge; 
                    }
                    for (x = x1; x < x2; x++)
                    {
                        y = m * x + b;
                        writeATXY(Convert.ToInt32(x), Convert.ToInt32(y), "*");
                    }
                }
            else                                                            // We need to step y, calculate x. Make sure y1 < y2
            {
                if (Tedge < vert)
                {
                    x1 = Redge;
                    y1 = Tedge;
                    x2 = horiz;
                    y2 = vert;
                }
                else
                {
                    x1 = horiz;
                    y1 = vert;
                    x2 = Redge;
                    y2 = Tedge;
                }

                for (y = y1; y <= y2; y++)
                {
                    x = (y - b) / m;
                    writeATXY(Convert.ToInt32(x), Convert.ToInt32(y), "*");
                }
            }
            Console.SetCursorPosition(0, 0); // return the cursor back to the regular position
            }
        }
    }

    

