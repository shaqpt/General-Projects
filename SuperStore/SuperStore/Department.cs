using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore
{
    class Department
    {
        public string DepName { get; set; }
        public int NumItems { get; set; }
        public List<Item> Items { get; set; }

        public Department()
        {
            DepName = ""; // clears the Department list
            NumItems = 0;
            Items.Clear();
        }
        public Department(string dep, int num, List<Item> i) // gets the information from calling the main program, then inputs data into the set variables
        {
            DepName = dep;
            NumItems = num;
            Items = i;
        }

    }
}
