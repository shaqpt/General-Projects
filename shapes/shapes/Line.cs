using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    
        class Line : Shape
        {
            private int xEnd, yEnd;
            public Line()
            {
                xStart = 0; 
                yStart = 0;
                xEnd = 0; 
                yEnd = 0;
            }
            public Line(int xs, int ys, int xe, int ye)
            {
                xStart = xs; yStart = ys; xEnd = xe; yEnd = ye;
            }
            public override void draw()
            {
                if (xStart == xEnd) 
                {					
                    int ymin = yStart < yEnd ? yStart : yEnd;	// determine min y of line
                    int ymax = yStart < yEnd ? yEnd : yStart;	// determine max y of line
                    for (int yy = ymin; yy <= ymax; yy++)	// setp through each y point
                        writeATXY(xStart, yy, "*");			// and draw a *
                    return;
                }
                // if here, determine slope (m) and y-intercept b

                double m = Convert.ToDouble(yEnd - yStart) / Convert.ToDouble(xEnd - xStart);
                double b = Convert.ToDouble(yStart) - m * Convert.ToDouble(xStart);
                double x1, y1, x2, y2, x, y;

                if (Math.Abs(m) < 1.0)
                {                           // We'll be stepping x and calculating y.  Insure x1 < x2
                    if (xStart < xEnd)
                    { x1 = xStart; y1 = yStart; x2 = xEnd; y2 = yEnd; }
                    else
                    { x1 = xEnd; y1 = yEnd; x2 = xStart; y2 = yStart; }

                    for (x = x1; x <= x2; x++)
                    {
                        y = m * x + b;
                        writeATXY(Convert.ToInt32(x), Convert.ToInt32(y), "*");
                    }
                }
                else
                {                           // We'll be stepping y and calculating x.  Insure y1 < y2
                    if (yStart < yEnd)
                    { x1 = xStart; y1 = yStart; x2 = xEnd; y2 = yEnd; }
                    else
                    { x1 = xEnd; y1 = yEnd; x2 = xStart; y2 = yStart; }

                    for (y = y1; y <= y2; y++)
                    {
                        x = (y - b) / m;
                        writeATXY(Convert.ToInt32(x), Convert.ToInt32(y), "*");
                    }
                }
                Console.SetCursorPosition(0, 0);
            }
        }
}
    

