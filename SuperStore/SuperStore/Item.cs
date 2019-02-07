using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore
{
    class Item
    {
        public string Name { get; set; }
        public int Inven { get; set; }
        public double Price { get; set; }

        public Item() //clears item list
        {
            Name = "";
            Inven = 0;
            Price = 0.0;
        }
        public Item(string name, int inven, double price) //calls main program and inputs data into item variables
        {
            Name = name;
            Inven = inven;
            Price = price;
        }
        public override string ToString() // 
        {
            string listing = "";
            listing = Name + " " + Inven + ", " + Price;
            return listing;
        }
    }
}
