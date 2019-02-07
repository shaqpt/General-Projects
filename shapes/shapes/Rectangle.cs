using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    class Rectangle: Shape
    {
        private int  unitT, unitW;
        public Rectangle()
        {
            unitT = unitW = 0;
            Redge = Tedge = 0;
        }
        public Rectangle(int tall,int wide,int redge, int tedge)
        {
            unitT = tall; 
            unitW = wide; 
            Redge = redge; 
            Tedge = tedge;
        }
        public override void draw()
        {
            int x=Redge, y=Tedge;
             for (int i = 0; i <=1; i++) //Prints x lines
            {
                writeATXY(Redge, y, "*");//used to draw * horizontally
                for (int j = 1; j <unitW; j++)
                {
                    x++;
                    writeATXY(x, y, "*");
                }
                y += unitT-1;
                x = Redge;
            }
             x = Redge; y = Tedge;

            for (int j = 0; j <= 1; j++) //Prints y lines 
            {
                writeATXY(x, Tedge, "*");//used to draw * vertically
                for (int i = 1; i <= unitT; i++) 
                {
                    writeATXY(x, y, "*");
                    y++;
                }
                x += unitW-1;
                y = Tedge;
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
