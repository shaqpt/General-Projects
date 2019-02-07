using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Category
    {
        public string CatName { get; set; }
        public int NumItems { get; set; }
        public List<Items> Items { get; set; }

        public Category()
        {
            CatName = ""; // clears the Department list
            NumItems = 0;
            Items.Clear();
        }
        public Category(string cat, int num, List<Items> i) // gets the information from calling the main program, then inputs data into the set variables
        {
            CatName = cat;
            NumItems = num;
            Items = i;
        }
    }
}
