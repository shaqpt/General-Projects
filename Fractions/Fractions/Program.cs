//I, Shaqueir Tardif, worked in collaboration with Devaj Ramsamooj to complete the program.
// Program only works when implemented with mixed numbers (eg. 8 1|4,  2 1|8,  1 3|7, etc.)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction val1, val2;
            string operation;
            string[] validOps = { "ADDITION", "A", "SUBTRACTION", "S", "MULITPLICATION", "M", "DIVISION", "D" };
            string fmt = "     {0} {1} {2} = {3}\n";
            while (GetYesNo("Would you like to do another calculation? "))
            {
                val1 = GetFraction("Enter the first fraction: ", "?Invalid fraction - please reenter");
                val2 = GetFraction("Enter the second fraction: ", "?Invalid fraction - please reenter");
                operation = GetString("What operation?", validOps, "?Invalid operation, please reenter");
                switch (operation)
                {
                    case "A": case "ADDITION": Console.WriteLine(fmt, val1, "+", val2, val1 + val2); break;
                    case "S": case "SUBTRACTION": Console.WriteLine(fmt, val1, "-", val2, val1 - val2); break;
                    case "M": case "MULTIPLICATION": Console.WriteLine(fmt, val1, "*", val2, val1 * val2); break;
                    case "D": case "DIVISION": string q = (val1 / val2).ToString();
                        if (q.Contains("NaN") || q.Contains("Infinity"))
                            Console.WriteLine(fmt, val1, "/", val2, "Error (attempt to /0)");
                        else
                            Console.WriteLine(fmt, val1, "/", val2, val1 / val2);
                        break;
                }
            }
        }
        static string GetString(string prompt, string[] valid, string error)
        {
            string response;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine().ToUpper();
                foreach (string s in valid) if (response == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine(error);
            } while (!OK);
            return response;
        }
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");

        }
        static Fraction GetFraction(string prompt, string error)
        {
            Fraction result;
            string userInput;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                OK = Fraction.TryParse(userInput, out result);
                if (!OK) Console.WriteLine(error);
            } while (!OK);
            return result;
        }
    }
}
