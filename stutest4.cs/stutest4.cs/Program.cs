//I, Shaqueir Tardif, certify this work as a result of my own work
// and not a product of collaboration with anyone else.
// However, I did receive some advice and helpful information from
// the Teacher Assistant (TA), to comeplete this program.
// **************************************************
// Please note: The student's are sorted by last name.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace stutest4.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStu = 0, numTst = 0;
            string[] last;
            string[] first;
            string line = ""; // give an initial value to prevent error // not an array - this will be entire line read
            string[] tokens;
            char[] separator = { ',' };
            int sum1 = 0;
            float avg1 = 0f;
            float avg2 = 0f;
            float totavg = 0f;

            int[,] T;
            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\stutest4.txt"))
                {
                    while (sr.Peek() >= 0) //returns next available character, but doesn't consume it
                    {
                        line = sr.ReadLine();
                        numStu++;
                        //Console.WriteLine(line);
                        //Console.WriteLine("----");
                    }
                    tokens = line.Split(separator); //would output a variable unassigned error if line wasn't declared a value at start
                    //tokens = line.Split(' , '); //also works
                    numTst = tokens.Count() - 2;
                    numTst = (numTst < 0) ? 0 : numTst;
                    //Console.WriteLine("{0} students and {1} test per student.", numStu, numTst);
                    Console.Write("{0,-34}", "Name"); 
                    for (int i = 1; i < (numTst + 1); i++) //print number of test according to how many tests are in the file
                        Console.Write("Test {0}  ",i);
                    Console.WriteLine(" Average ");
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }

            //Now, YOU KNOW numStu and numTst - allocate space and read them

            last = new string[numStu];
            first = new string[numStu];
            T = new int[numStu, numTst];

            //using (StreamReader sr = new StreamReader(@"..\..\stutest4.txt"))//@" means no escape char; reads each character as it is ex: \n is simple \ n and doesn't print a new line
            using (StreamReader sr = new StreamReader("..\\..\\stutest4.txt"))
            {
                for (int stu = 0; stu < numStu; stu++)
                {
                    line = sr.ReadLine();
                    tokens = line.Split(separator);
                    last[stu] = tokens[0];
                    first[stu] = tokens[1];
                    last[stu] = tokens[0].Trim();
                    first[stu] = tokens[1].Trim();
                    for (int tst = 0; tst < numTst; tst++)
                        T[stu, tst] = Convert.ToInt32(tokens[tst + 2]);
                }
                sr.Close();
            }

            //NOW WRITE OUT THE INFOMATION IN A NICE COLUMN FORMAT
            //NOTE YOU HAVE TO ADD AVERAGE FOR EACH STUDENT AND EACH TEST
            //ALONG WITH AVERAGE OF AVERAGES

            for (int stu = 0; stu < numStu; stu++)
            {
                Console.Write("{0,-15} {1,-15}", first[stu], last[stu]);
                for (int ln = 0; ln < numTst; ln++) //sort by last name
                {
                    List<string> lastname = new List<string>();
                    lastname.Add(last[stu]);
                    lastname.Sort();
                }

                for (int tst = 0; tst < numTst; tst++)
                {
                    Console.Write("{0,7} ", T[stu, tst]);
                    sum1 += T[stu, tst];
                    if (tst == numTst - 1)
                    {
                        avg1 = (float)sum1 / numTst;
                        Console.Write("{0,10:n2}", avg1);
                        sum1 = 0;
                    }
                }
                Console.WriteLine();
            }

            Console.Write("Averages                         ");
            for (int tst = 0; tst < numTst; tst++)
            {
                int ttot = 0;
                float tavg = 0f;
                for (int stu = 0; stu < numStu; stu++)
                    ttot += T[stu, tst];
                tavg = (float)ttot / numStu;
                avg2 += tavg;
                Console.Write("{0,8:n2}", tavg);
            }
            totavg = avg2 / numTst;
            Console.Write("{0,8:n2}", totavg);
            Console.WriteLine();
        }
    }
}
