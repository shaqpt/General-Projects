//I, Shaqueir Tardif, worked in collaboration with Egbunike Chamberlain to complete this program.
//Please note, the TA was able to help me make the program by giving me advice, tips, and strategies.
//*****No part of this program was written by the TA or any other personnel.*************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the ECE 264 Superstore!\n");
            Console.Write("You have a starting balance of $400. Spend Wisely.\n");
            Console.Write("Enter 'NONE' to leave the store.\n");
            List<Department> dep;
            List<Item> receipt = new List<Item>(); //creates a list of input data that will be used for the total receipt and other functions
            ReadStore(out dep); //inputs data from superstore.txt file into functions for the program
            Shopping(dep,receipt); //function to add items user is shopping for
            PrintReceipt(receipt); //function to print receipt to receipt.txt file
        }
        static void ReadStore(out List<Department> d)
        {
            string line;
            string[] tokens;
            string name;
            int i, item;

            d = new List<Department>();
            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\superstore.txt")) //try calling the superstore.txt file and read the data from the file
                {
                    while (sr.Peek() >= 0)
                    {
                        List<Item> tmpItems = new List<Item>();
                        line = sr.ReadLine();
                        tokens = line.Split(',');
                        name = tokens[0].Trim();
                        item = Convert.ToInt32(tokens[1].Trim());
                        for (i = 0; i < item; i++)
                        {
                            line = sr.ReadLine();
                            tokens = line.Split(',');
                            Item tmpItem = new Item(
                                tokens[0].Trim(),
                                Convert.ToInt32(tokens[1].Trim()),
                                Convert.ToDouble(tokens[2].Trim()));
                            tmpItems.Add(tmpItem);
                        }
                        d.Add(new Department(name, item, tmpItems));
                    }
                    sr.Close();
                }
            }
            catch (Exception e)//If unable to detect file, print out error message.
            {
                Console.WriteLine("Error occured: {0}", e.Message);
            }
        }
        static void Shopping(List<Department> dep, List<Item> receipt)
        {
            //List<Item> receipt = new List<Item>();
            Console.WriteLine("Which department would you like to go to?");
            Console.WriteLine("\tBooks");
            Console.WriteLine("\tFood");
            Console.WriteLine("\tVideo");
            Console.WriteLine("\tSports");
            Console.WriteLine("\tStationary");
            Console.WriteLine("\tTools");
            int f = 0;
            double balance = 400.00f;
            double credit = 0.00f;
            bool done = true;

            for (int i = 0; i < dep.Count(); i++)
            {
                string x;
                x = Console.ReadLine().ToUpper().Trim();

                while (balance > credit) //continues unless you
                {
                    while (done)
                    {
                        switch (x)
                        {
                            case "NONE": //ends program; prints reciept
                                {
                                    Console.WriteLine("Thank you for shopping. I will print out the reciept \n(Please refer to receipt.txt file for a detailed reciept).");
                                    return;
                                    //done = false;
                                    //break;
                                }

                                /* ****************** BOOKS Department ******************* */
                            case "BOOKS": //Goes to the Books Department
                                {
                                    Console.WriteLine("What would you like to buy?");
                                    Console.WriteLine("Enter 'leave' to switch to a different department");
                                    f = 0;
                                    int g = 0;


                                    for (g = 0; g < dep[f].NumItems; g++)
                                    {
                                        Console.WriteLine("\t{0} ({2} Available --- ${1} each)", dep[f].Items[g].Name, dep[f].Items[g].Price, dep[f].Items[g].Inven);
                                    }
                                    string h = Console.ReadLine().ToUpper().Trim();
                                    switch (h)
                                    {

                                            /*********************HOBBIT******************/
                                        case "HOBBIT":
                                            {
                                                if (dep[0].Items[0].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[0].Items[0].Price;
                                                    if (j <= dep[0].Items[0].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[0].Items[0].Inven = dep[0].Items[0].Inven - j;


                                                        //balance = balance - price;
                                                        if((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            //balance = balance + price;
                                                            dep[0].Items[0].Inven = dep[0].Items[0].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Hobbit", j, dep[0].Items[0].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /***************COOKING*******************/
                                        case "COOKING":
                                            {
                                                if (dep[0].Items[1].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[0].Items[1].Price;
                                                    if (j <= dep[0].Items[1].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[0].Items[1].Inven = dep[0].Items[1].Inven - j;

                                                        //balance = balance - price;
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[0].Items[1].Inven = dep[0].Items[1].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Cooking", j, dep[0].Items[1].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;

                                            }


                                            /******************************1984*************************/
                                        case "1984":
                                            {
                                                if (dep[0].Items[2].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[0].Items[2].Price;
                                                    if (j <= dep[0].Items[2].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[0].Items[2].Inven = dep[0].Items[2].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[0].Items[2].Inven = dep[0].Items[2].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("1984", j, dep[0].Items[2].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }


                                            /*********************WAR AND PEACE*********************/
                                        case "WAR AND PEACE":
                                            {
                                                if (dep[0].Items[3].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[0].Items[3].Price;
                                                    if (j <= dep[0].Items[3].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[0].Items[3].Inven = dep[0].Items[3].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //if user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[0].Items[3].Inven = dep[0].Items[3].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("War and Peace", j, dep[0].Items[3].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /*********************CHARLOTTE******************/
                                        case "CHARLOTTE":
                                            {
                                                if (dep[0].Items[4].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[0].Items[4].Price;
                                                    if (j <= dep[0].Items[4].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[0].Items[4].Inven = dep[0].Items[4].Inven - j;

                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[0].Items[4].Inven = dep[0].Items[4].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Charlotte", j, dep[0].Items[4].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }
                                        case "LEAVE":
                                            Console.WriteLine("Which department would you like to go to?");
                                            Console.WriteLine("Enter 'NONE' to leave the store.");
                                            Console.WriteLine("\tBooks");
                                            Console.WriteLine("\tFood");
                                            Console.WriteLine("\tVideo");
                                            Console.WriteLine("\tSports");
                                            Console.WriteLine("\tStationary");
                                            Console.WriteLine("\tTools");
                                            x = Console.ReadLine().ToUpper().Trim();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            break;

                                    }

                                    break;

                                }


                            /* ****************** FOOD Department ******************* */
                            case "FOOD":
                                {
                                    Console.WriteLine("What would you like to buy?");
                                    Console.WriteLine("Enter 'leave' to switch to a different department");
                                    f = 1;
                                    int g = 0;


                                    for (g = 0; g < dep[f].NumItems; g++)
                                    {
                                        Console.WriteLine("\t{0} ({2} Available --- ${1} each)", dep[f].Items[g].Name, dep[f].Items[g].Price, dep[f].Items[g].Inven);
                                    }
                                    string h = Console.ReadLine().ToUpper().Trim();

                                    switch (h)
                                    {

                                            /**********************APPLE******************/
                                        case "APPLE":
                                            if (dep[1].Items[0].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[0].Price;
                                                if (j <= dep[1].Items[0].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[0].Inven = dep[1].Items[0].Inven - j;

                                                   
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[0].Inven = dep[1].Items[0].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Apple", j, dep[1].Items[0].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }

                                            break;

                                            /****************BANANA****************/
                                        case "BANANA":
                                            if (dep[1].Items[1].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[1].Price;
                                                if (j <= dep[1].Items[1].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[1].Inven = dep[1].Items[1].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[1].Inven = dep[1].Items[1].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Banana", j, dep[1].Items[1].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /**********************ORANGE********************/
                                        case "ORANGE":
                                            if (dep[1].Items[2].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[2].Price;
                                                if (j <= dep[1].Items[2].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[2].Inven = dep[1].Items[2].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[2].Inven = dep[1].Items[2].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Orange", j, dep[1].Items[2].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /******************************CHICKEN*****************************/
                                        case "CHICKEN":
                                            if (dep[1].Items[3].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[3].Price;
                                                if (j <= dep[1].Items[3].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[3].Inven = dep[1].Items[3].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[3].Inven = dep[1].Items[3].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Chicken", j, dep[1].Items[3].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /*****************STEAK**************/
                                        case "STEAK":
                                            if (dep[1].Items[4].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[4].Price;
                                                if (j <= dep[1].Items[4].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[4].Inven = dep[1].Items[4].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[4].Inven = dep[1].Items[4].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Steak", j, dep[1].Items[4].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;


                                            /***********************FISH********************/
                                        case "FISH":
                                            if (dep[1].Items[5].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[5].Price;
                                                if (j <= dep[1].Items[5].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[5].Inven = dep[1].Items[5].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[5].Inven = dep[1].Items[5].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Fish", j, dep[1].Items[5].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;


                                            /******************ALMONDS*********************/
                                        case "ALMONDS":
                                            if (dep[1].Items[6].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[6].Price;
                                                if (j <= dep[1].Items[6].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[6].Inven = dep[1].Items[6].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[6].Inven = dep[1].Items[6].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Almonds", j, dep[1].Items[6].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /***************SPINACH****************/
                                        case "SPINACH":
                                            if (dep[1].Items[7].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[7].Price;
                                                if (j <= dep[1].Items[7].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[7].Inven = dep[1].Items[7].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[7].Inven = dep[1].Items[7].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Spinach", j, dep[1].Items[7].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;


                                            /********************PEPPERS***************/
                                        case "PEPPERS":
                                            if (dep[1].Items[8].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[8].Price;
                                                if (j <= dep[1].Items[8].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[8].Inven = dep[1].Items[8].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[8].Inven = dep[1].Items[8].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Peppers", j, dep[1].Items[8].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /********************BROCCOLI**************/
                                        case "BROCCOLI":
                                            if (dep[1].Items[9].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[9].Price;
                                                if (j <= dep[1].Items[9].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[1].Items[9].Inven = dep[1].Items[9].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[1].Items[9].Inven = dep[1].Items[9].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Broccoli", j, dep[1].Items[0].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;
                                        case "LEAVE":
                                            Console.Write("Which department would you like to go to?\n");
                                            Console.Write("Enter 'NONE' to leave the store.\n");
                                            Console.WriteLine("\tBooks");
                                            Console.WriteLine("\tFood");
                                            Console.WriteLine("\tVideo");
                                            Console.WriteLine("\tSports");
                                            Console.WriteLine("\tStationary");
                                            Console.WriteLine("\tTools");
                                            x = Console.ReadLine().ToUpper().Trim();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            break;
                                    }
                                }
                                break;

                            /* ****************** VIDEO Department ******************* */
                            case "VIDEO":
                                {
                                    Console.WriteLine("What would you like to buy?");
                                    Console.WriteLine("Enter 'leave' to switch to a different department");
                                    f = 2;
                                    int g = 0;


                                    for (g = 0; g < dep[f].NumItems; g++)
                                    {
                                        Console.WriteLine("\t{0} ({2} Available --- ${1} each)", dep[f].Items[g].Name, dep[f].Items[g].Price, dep[f].Items[g].Inven);
                                    }
                                    string h = Console.ReadLine().ToUpper().Trim();

                                    switch (h)
                                    {
                                        case "THE MARTIAN":
                                            if (dep[2].Items[0].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[1].Items[0].Price;
                                                if (j <= dep[2].Items[0].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[0].Inven = dep[2].Items[0].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[0].Inven = dep[2].Items[0].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("The Martian", j, dep[2].Items[0].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }

                                            break;

                                            /*************************AVENGERS*****************/
                                        case "AVENGERS":
                                            if (dep[2].Items[1].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[2].Items[1].Price;
                                                if (j <= dep[2].Items[1].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[1].Inven = dep[2].Items[1].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[1].Inven = dep[2].Items[1].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Avengers", j, dep[2].Items[1].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;


                                            /*****************JAWS***************/
                                        case "JAWS":
                                            if (dep[2].Items[2].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[2].Items[2].Price;
                                                if (j <= dep[2].Items[2].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[2].Inven = dep[2].Items[2].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[2].Inven = dep[2].Items[2].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Jaws", j, dep[2].Items[2].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /***************CATCH-22***************/
                                        case "CATCH-22":
                                            if (dep[2].Items[3].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[2].Items[3].Price;
                                                if (j <= dep[2].Items[3].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[3].Inven = dep[2].Items[3].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[3].Inven = dep[2].Items[3].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Catch-22", j, dep[2].Items[3].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /*****************TARZAN***********/
                                        case "TARZAN":
                                            if (dep[2].Items[4].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[2].Items[4].Price;
                                                if (j <= dep[2].Items[4].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[4].Inven = dep[2].Items[4].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[4].Inven = dep[2].Items[4].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Tarzan", j, dep[2].Items[4].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /***************OUTLANDER*************/
                                        case "OUTLANDER":
                                            if (dep[2].Items[5].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[2].Items[5].Price;
                                                if (j <= dep[2].Items[5].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[5].Inven = dep[2].Items[5].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[5].Inven = dep[2].Items[5].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Outlander", j, dep[2].Items[5].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /**************RED PLANET*************/
                                        case "RED PLANET":
                                            if (dep[2].Items[6].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[2].Items[6].Price;
                                                if (j <= dep[2].Items[6].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[2].Items[6].Inven = dep[2].Items[6].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[2].Items[6].Inven = dep[2].Items[6].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Red Planet", j, dep[2].Items[6].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;
                                        case "LEAVE":
                                            Console.Write("Which department would you like to go to?\n");
                                            Console.Write("Enter 'NONE' to leave the store.\n");
                                            Console.WriteLine("\tBooks");
                                            Console.WriteLine("\tFood");
                                            Console.WriteLine("\tVideo");
                                            Console.WriteLine("\tSports");
                                            Console.WriteLine("\tStationary");
                                            Console.WriteLine("\tTools");
                                            x = Console.ReadLine().ToUpper().Trim();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            break;

                                    }
                                    break;
                                }

                            /* ****************** SPORTS Department ******************* */
                            case "SPORTS":
                                {
                                    Console.WriteLine("What would you like to buy?");
                                    Console.WriteLine("Enter 'leave' to switch to a different department");
                                    f = 3;
                                    int g = 0;


                                    for (g = 0; g < dep[f].NumItems; g++)
                                    {
                                        Console.WriteLine("\t{0} ({2} Available -- ${1} each)", dep[f].Items[g].Name, dep[f].Items[g].Price, dep[f].Items[g].Inven);
                                    }
                                    string h = Console.ReadLine().ToUpper().Trim();

                                    switch (h)
                                    {
                                            /************DUMBELLS***********/
                                        case "DUMBELLS":
                                            if (dep[3].Items[0].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[3].Items[0].Price;
                                                if (j <= dep[3].Items[0].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[3].Items[0].Inven = dep[3].Items[0].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[3].Items[0].Inven = dep[3].Items[0].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("Dumbells", j, dep[3].Items[0].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /***********PULLUPBAR************/
                                        case "PULLUPBAR":
                                            if (dep[3].Items[1].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[3].Items[1].Price;
                                                if (j <= dep[3].Items[1].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[3].Items[1].Inven = dep[3].Items[1].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[3].Items[1].Inven = dep[3].Items[1].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("PullupBar", j, dep[3].Items[1].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /**********YOGAMAT*********/
                                        case "YOGAMAT":
                                            if (dep[3].Items[2].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[3].Items[2].Price;
                                                if (j <= dep[3].Items[2].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[3].Items[2].Inven = dep[3].Items[2].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //if user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[3].Items[2].Inven = dep[3].Items[2].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("YogaMat", j, dep[3].Items[2].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);
                                            }
                                            break;

                                            /*************STOPWATCH**************/
                                        case "STOPWATCH":
                                            if (dep[3].Items[3].Inven < 0)
                                            {
                                                Console.WriteLine("No more inventory");
                                            }
                                            else
                                            {
                                                Console.Write("How many? ");
                                                int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                double price = j * dep[3].Items[3].Price;
                                                if (j <= dep[3].Items[3].Inven)
                                                {
                                                    Console.WriteLine("That will be ${0}", price);
                                                    dep[3].Items[3].Inven = dep[3].Items[3].Inven - j;

                                                    
                                                    if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                    {
                                                        Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                        dep[3].Items[3].Inven = dep[3].Items[3].Inven + j; //replenish the inventory
                                                    }
                                                    else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                    {
                                                        balance = balance - price;
                                                        receipt.Add(new Item("StopWatch", j, dep[3].Items[3].Price));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough inventory");
                                                }
                                                
                                                Console.WriteLine("You have ${0} left.", balance);


                                            }
                                            break;
                                        case "LEAVE":
                                            Console.Write("Which department would you like to go to?\n");
                                            Console.Write("Enter 'NONE' to leave the store.\n");
                                            Console.WriteLine("\tBooks");
                                            Console.WriteLine("\tFood");
                                            Console.WriteLine("\tVideo");
                                            Console.WriteLine("\tSports");
                                            Console.WriteLine("\tStationary");
                                            Console.WriteLine("\tTools");
                                            x = Console.ReadLine().ToUpper().Trim();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            break;
                                    }
                                    break;
                                }


                            /* ****************** STATIONARY Department ******************* */
                            case "STATIONARY":
                                {
                                    Console.WriteLine("What would you like to buy?");
                                    Console.WriteLine("Enter 'leave' to switch to a different department");
                                    f = 4;
                                    int g = 0;


                                    for (g = 0; g < dep[f].NumItems; g++)
                                    {
                                        Console.WriteLine("\t{0} ({2} Available -- ${1} each)", dep[f].Items[g].Name, dep[f].Items[g].Price, dep[f].Items[g].Inven);
                                    }
                                    string h = Console.ReadLine().ToUpper().Trim();
                                    switch (h)
                                    {

                                            /***********NOTEBOOK**********/
                                        case "NOTEBOOK":
                                            {
                                                if (dep[4].Items[0].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[4].Items[0].Price;
                                                    if (j <= dep[4].Items[0].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[4].Items[0].Inven = dep[4].Items[0].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[4].Items[0].Inven = dep[4].Items[0].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Notebook", j, dep[4].Items[0].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /***********PENS********/
                                        case "PENS":
                                            {
                                                if (dep[4].Items[1].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[4].Items[1].Price;
                                                    if (j <= dep[4].Items[1].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[4].Items[1].Inven = dep[4].Items[1].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[4].Items[1].Inven = dep[4].Items[1].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Pens", j, dep[4].Items[1].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /**********PENCILS**********/
                                        case "PENCILS":
                                            {
                                                if (dep[4].Items[2].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[4].Items[2].Price;
                                                    if (j <= dep[4].Items[2].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[4].Items[2].Inven = dep[4].Items[2].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[4].Items[2].Inven = dep[4].Items[2].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Pencils", j, dep[4].Items[2].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /******************POST-IT NOTES************/
                                        case "POST IT NOTES":
                                            {
                                                if (dep[4].Items[3].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[4].Items[3].Price;
                                                    if (j <= dep[4].Items[3].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[4].Items[3].Inven = dep[4].Items[3].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[4].Items[3].Inven = dep[4].Items[3].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Pens", j, dep[4].Items[3].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                        case "LEAVE":
                                            Console.Write("Which department would you like to go to?\n");
                                            Console.Write("Enter 'NONE' to leave the store.\n");
                                            Console.WriteLine("\tBooks");
                                            Console.WriteLine("\tFood");
                                            Console.WriteLine("\tVideo");
                                            Console.WriteLine("\tSports");
                                            Console.WriteLine("\tStationary");
                                            Console.WriteLine("\tTools");
                                            x = Console.ReadLine().ToUpper().Trim();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            break;
                                    }

                                }
                                break;


                            /* ****************** TOOLS Department ******************* */
                            case "TOOLS":
                                {
                                    Console.WriteLine("What would you like to buy?");
                                    Console.WriteLine("Enter 'leave' to switch to a different department");
                                    f = 5;
                                    int g = 0;


                                    for (g = 0; g < dep[f].NumItems; g++)
                                    {
                                        Console.WriteLine("\t{0} ({2} Available -- ${1} each)", dep[f].Items[g].Name, dep[f].Items[g].Price, dep[f].Items[g].Inven);
                                    }
                                    string h = Console.ReadLine().ToUpper().Trim();
                                    switch (h)
                                    {
                                            /*************BAND SAW**********/
                                        case "BAND SAW":
                                            {
                                                if (dep[5].Items[0].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[5].Items[0].Price;
                                                    if (j <= dep[5].Items[0].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[5].Items[0].Inven = dep[5].Items[0].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[5].Items[0].Inven = dep[5].Items[0].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Band Saw", j, dep[5].Items[0].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /*************CRESENT WRENCH**************/
                                        case "CRESENT WRENCH":
                                            {
                                                if (dep[5].Items[1].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[5].Items[1].Price;
                                                    if (j <= dep[5].Items[1].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[5].Items[1].Inven = dep[5].Items[1].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[5].Items[1].Inven = dep[5].Items[1].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Cresent Wrench", j, dep[5].Items[1].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /***************CIRCULAR SAW*************/
                                        case "CIRCULAR SAW":
                                            {
                                                if (dep[5].Items[2].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[5].Items[2].Price;
                                                    if (j <= dep[5].Items[2].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[5].Items[2].Inven = dep[5].Items[2].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[5].Items[2].Inven = dep[5].Items[2].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Circular Saw", j, dep[5].Items[2].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /*********TILE CUTTER**********/
                                        case "TILE CUTTER":
                                            {
                                                if (dep[5].Items[3].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[5].Items[3].Price;
                                                    if (j <= dep[5].Items[3].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[5].Items[3].Inven = dep[5].Items[3].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[5].Items[3].Inven = dep[5].Items[3].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Tile Cutter", j, dep[5].Items[3].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /***********SCREWDRIVER*************/
                                        case "SCREWDRIVER":
                                            {
                                                if (dep[5].Items[4].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[5].Items[4].Price;
                                                    if (j <= dep[5].Items[4].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[5].Items[4].Inven = dep[5].Items[4].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[5].Items[4].Inven = dep[5].Items[4].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Screwdriver", j, dep[5].Items[4].Price));
                                                            
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }

                                            /*************MEASURING TAPE**********/
                                        case "MEASURING TAPE":
                                            {
                                                if (dep[5].Items[5].Inven < 0)
                                                {
                                                    Console.WriteLine("No more inventory");
                                                }
                                                else
                                                {
                                                    Console.Write("How many? ");
                                                    int j = Convert.ToInt32(Console.ReadLine().Trim());
                                                    double price = j * dep[5].Items[5].Price;
                                                    if (j <= dep[5].Items[5].Inven)
                                                    {
                                                        Console.WriteLine("That will be ${0}", price);
                                                        dep[5].Items[5].Inven = dep[5].Items[5].Inven - j;

                                                        
                                                        if ((balance - price) < 0) //in user has insufficient funds, tell them sorry
                                                        {
                                                            Console.WriteLine("You are unable to purchase this item due to insufficient funds. ");
                                                            dep[5].Items[5].Inven = dep[5].Items[5].Inven + j; //replenish the inventory
                                                        }
                                                        else // decrease the balance and add purchase to receipt only if user has sufficient funds
                                                        {
                                                            balance = balance - price;
                                                            receipt.Add(new Item("Measuring Tape", j, dep[5].Items[5].Price));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not enough inventory");
                                                    }
                                                    
                                                    Console.WriteLine("You have ${0} left.", balance);
                                                }
                                                break;
                                            }
                                        case "LEAVE":
                                            Console.Write("Which department would you like to go to?\n");
                                            Console.Write("Enter 'NONE' to leave the store.\n");
                                            Console.WriteLine("\tBooks");
                                            Console.WriteLine("\tFood");
                                            Console.WriteLine("\tVideo");
                                            Console.WriteLine("\tSports");
                                            Console.WriteLine("\tStationary");
                                            Console.WriteLine("\tTools");
                                            x = Console.ReadLine().ToUpper().Trim();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            break;
                                    }
                                }
                                break;

                            default:
                                bool ok = false;
                                while (!ok)
                                {
                                    Console.WriteLine("Invalid Entry");
                                    Console.Write("Which department would you like to go to?\n");
                                    Console.Write("Enter 'NONE' to leave the store.\n");
                                    Console.WriteLine("\tBooks");
                                    Console.WriteLine("\tFood");
                                    Console.WriteLine("\tVideo");
                                    Console.WriteLine("\tSports");
                                    Console.WriteLine("\tStationary");
                                    Console.WriteLine("\tTools");
                                    x = Console.ReadLine().ToUpper().Trim();
                                }

                                return;
                    }
                }
            }
        }
    }
        
        static void PrintReceipt(List<Item> receipt)//
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("..\\..\\receipt.txt"))
                {
                    List<double> balance = new List<double>();
                    double a = 0;
                     for (int j = 0; j < receipt.Count(); j++ )
                            {
                            sw.WriteLine("{0} {1}   ${2} each", receipt[j].Inven, receipt[j].Name, receipt[j].Price);
                            balance.Add( receipt[j].Inven * receipt[j].Price);
                             }
                    sw.WriteLine("----------------------------");
                     for (int i = 0; i < balance.Count(); i++ )
                     {

                         a = a + balance[i];
                     }
                     sw.WriteLine("Total:  {0}", a);
                }
            }
           catch (Exception e)
            {
                Console.WriteLine("Can't open file because {0}", e.Message);
            }
             
        }
    }
}