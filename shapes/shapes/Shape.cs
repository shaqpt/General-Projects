using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    
        public abstract class Shape
        {

            protected string ID;
            protected int xStart;
            protected int yStart;
            protected int Redge;
            protected int Tedge;
            protected int width;
            protected int x;
            protected int y;

        public abstract void draw();
            public virtual string Tostring()
            {
                return ID;
            }
            public void GoToXY(int x, int y)
            {
                Console.SetCursorPosition(x, y);
            }

            public void writeATXY(int x, int y, string s)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(s);
            }
        }
       
}

