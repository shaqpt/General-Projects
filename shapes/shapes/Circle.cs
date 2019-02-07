using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    class Circle : Shape
    {
        private int r;
        public Circle(int xs, int ys, int radius)
        {
            xStart = xs; 
            yStart = ys; 
            r = radius;
        }
        public override void draw()
        {
            double PiOver180 = Math.PI / 180.0;
            double theta;
            double step = 2;
            for (theta=0; theta<=360; theta+=step)
            {
                double x = r * Math.Cos(theta * PiOver180) + xStart; // must convert to rad
                double y = r * Math.Sin(theta * PiOver180) + yStart;
                writeATXY(Convert.ToInt32(x), Convert.ToInt32(y), "*");
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
