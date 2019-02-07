using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Items
    {
        public string Name { get; set; }
        public int Inven { get; set; }
        public Items() //clears item list
        {
            Name = "";
            Inven = 0;
        }
        public Items(string name, int inven) //calls main program and inputs data into item variables
        {
            Name = name;
            Inven = inven;
        }
        public override string ToString() // 
        {
            string listing = "";
            listing = Name + " " + Inven;
            return listing;
        }
    }
}
