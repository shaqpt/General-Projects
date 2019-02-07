using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    class Parallelogram : Shape
    {
        private int height, Width, left, edge;

        public Parallelogram(int tall, int wide, int redge, int tedge)
        {
            height = tall; 
            Width = wide; 
            left = redge; 
            edge = tedge;
        }

        public override void draw()
        {
            string s = "*";
            int i;
            for (i = 0; i < Width; i++) writeATXY(x + i, y, s); //top

            for (i = 0; i < Width; i++) writeATXY(x + i + height, y + height, s); // bottom

            for (i = 0; i < height + 1; i++)
            {
                writeATXY(x + i, y + i, s); //left
                writeATXY(x + i + Width, y + i, s); //right
            }
            Console.SetCursorPosition(0, 0);

        }
    }
}
