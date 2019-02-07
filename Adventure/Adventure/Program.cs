//I,Shaqueir Tardif, certify this work as the work of myself solely and not a product
//of collaboration with other personnel.

//Originated on 12/16/16
//Some edits made on 2/7/19

/*
 * Please note this code is still a work in progress. I haven't put in much time into fixing/completing it as
 * other priorities have arised. Feel free to use the code that is provided here to make your
 * own modifications to this Adventure game.
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In this text - based adventure game, you play as a Pilot named Connor. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Connor originates from London, England where he recently purchased a new taildagger(an airplane designed for 1). [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Connor has been invited to special holiday events in Germany and has decided to use his taildagger to get there. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("During the flight, Connor's taildagger undergoes a tragic mechanical failure and the engine gives way. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Fortunately, Connor had enough control of the airplane to safely land. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Unfortunately, he just landed on an unknown and unmapped island. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("It is now your job to find supplies from the island that Connor can use to repair the airplane. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("The required items you need can be found in the Supplies list in your inventory. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("After you have successfully gathered all of the needed materials, you may rebuild your airplane and leave the island. [Press Enter to continue]");
            Console.ReadLine();
            Console.Clear();

            List<Category> cat;
            List<Items> myInventory = new List<Items>(); //creates a list of input data that will be used for Connor's inventory
            ReadCat(out cat); //inputs data from inventory text file to 
            HomeArea(cat, myInventory); //function to add items to user inventory
            MyInventory(myInventory);
        }

        static void ReadCat(out List<Category> c)
        {
            string line;
            string[] tokens;
            string name;
            int i, item;

            c = new List<Category>();
            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\AreasInventory.txt")) //try calling the superstore.txt file and read the data from the file
                {
                    while (sr.Peek() >= 0)
                    {
                        List<Items> tmpItems = new List<Items>();
                        line = sr.ReadLine();
                        tokens = line.Split(',');
                        name = tokens[0].Trim();
                        item = Convert.ToInt32(tokens[1].Trim());
                        for (i = 0; i < item; i++)
                        {
                            line = sr.ReadLine();
                            tokens = line.Split(',');
                            Items tmpItem = new Items(
                                tokens[0].Trim(),
                                Convert.ToInt32(tokens[1].Trim()));
                            tmpItems.Add(tmpItem);
                        }
                        c.Add(new Category(name, item, tmpItems));
                    }
                    sr.Close();
                }
            }
            catch (Exception e)//If unable to detect file, print out error message.
            {
                Console.WriteLine("Error occured: {0}", e.Message);
            }
        }
        
        static void HomeArea(List<Category> cat, List<Items> myInventory)
        {
            int f = 0;
            bool ok = true;
            Console.WriteLine("Welcome to your Home Area.");
            Console.WriteLine("Here are the items within this area: ");
            Console.WriteLine("\tAirplane Crash Site");
            Console.WriteLine("\tStorage Area");
            Console.WriteLine("\tCrafting Area");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            for (int i = 0; i < cat[f].NumItems; i++)
            {
                Console.WriteLine("\t{0}  {1}(Quantity)\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
            }
            Console.WriteLine("-------------------------------------------------------------------------------");

        INVEN:
            Console.WriteLine("To view your current inventory, enter [i], press [Enter] to skip to next prompt");
            string inv = Console.ReadLine().ToUpper().Trim();
            if (inv == "I")
            {
                Console.WriteLine("Your current inventory includes the following items: ");
                var text = File.ReadAllText(@"..\\..\\MyInventory.txt"); //read list from current inventory
                System.Console.WriteLine("/t{0}", text);
            }

            while(ok)
            { 
            
            Console.Write("Would you like to take any of these items? [Enter YES or NO] ");
            string p = Console.ReadLine().ToUpper().Trim();
            switch (p)
            {
                case "Y": case "YES":
                    {
                        Console.Write("Which item would you like to take? ");
                        string h = Console.ReadLine().ToUpper().Trim();
                        switch (h)
                        {
                            case "WATER":
                                {
                                    if (cat[0].Items[0].Inven < 0)
                                        Console.WriteLine("There no more of this item available in this area.");
                                    else
                                    {
                                        Console.Write("How many? (Note: you can't pick up more than 10 of an item) ");
                                        int j = Convert.ToInt32(Console.ReadLine().Trim());
                                        if (j <= cat[0].Items[0].Inven && j < 11)
                                        {
                                            cat[0].Items[0].Inven -= j;
                                            myInventory.Add(new Items(cat[0].Items[0].Name, j));
                                            for (int i = 0; i < cat[f].NumItems; i++)
                                            {
                                                Console.WriteLine("\t{0}  {1}\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid response, not enough items");
                                        }

                                    }
                                    goto INVEN;
                                    break;
                                }
                            case "BANANAS":
                                {
                                    if (cat[0].Items[1].Inven < 0)
                                        Console.WriteLine("There no more of this item available in this area.");
                                    else
                                    {
                                        Console.Write("How many? (Note: you can't pick up more than 10 of an item) ");
                                        int j = Convert.ToInt32(Console.ReadLine().Trim());
                                        if (j <= cat[0].Items[1].Inven && j < 11)
                                        {
                                            cat[0].Items[1].Inven -= j;
                                            myInventory.Add(new Items(cat[0].Items[1].Name, j));
                                            for (int i = 0; i < cat[f].NumItems; i++)
                                            {
                                                Console.WriteLine("\t{0}  {1}\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid response, not enough items");
                                        }

                                    }
                                    goto INVEN;
                                    break;
                                }
                            case "GRAPES":
                                {
                                    if (cat[0].Items[2].Inven <= 0)
                                        Console.WriteLine("There no more of this item available in this area.");
                                    else
                                    {
                                        Console.Write("How many? (Note: you can't pick up more than 10 of an item) ");
                                        int j = Convert.ToInt32(Console.ReadLine().Trim());
                                        if (j <= cat[0].Items[2].Inven && j < 11)
                                        {
                                            cat[0].Items[2].Inven -= j;
                                            myInventory.Add(new Items(cat[0].Items[2].Name, j));
                                            for (int i = 0; i < cat[f].NumItems; i++)
                                            {
                                                Console.WriteLine("\t{0}  {1}\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid response, not enough items");
                                        }

                                    }
                                    goto INVEN;
                                    break;
                                }
                            case "WOOD":
                                {
                                    if (cat[0].Items[3].Inven <= 0)
                                        Console.WriteLine("There no more of this item available in this area.");
                                    else
                                    {
                                        Console.Write("How many? (Note: you can't pick up more than 10 of an item) ");
                                        int j = Convert.ToInt32(Console.ReadLine().Trim());
                                        if (j <= cat[0].Items[3].Inven && j < 11)
                                        {
                                            cat[0].Items[3].Inven -= j;
                                            myInventory.Add(new Items(cat[0].Items[3].Name, j));
                                            for (int i = 0; i < cat[f].NumItems; i++)
                                            {
                                                Console.WriteLine("\t{0}  {1}\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid response, not enough items");
                                        }

                                    }
                                    goto INVEN;
                                    break;
                                }
                            case "SCRAP METAL":
                                {
                                    if (cat[0].Items[4].Inven <= 0)
                                        Console.WriteLine("There no more of this item available in this area.");
                                    else
                                    {
                                        Console.Write("How many? (Note: you can't pick up more than 10 of an item) ");
                                        int j = Convert.ToInt32(Console.ReadLine().Trim());
                                        if (j <= cat[0].Items[4].Inven && j < 11)
                                        {
                                            cat[0].Items[4].Inven -= j;
                                            myInventory.Add(new Items(cat[0].Items[4].Name, j));
                                            for (int i = 0; i < cat[f].NumItems; i++)
                                            {
                                                Console.WriteLine("\t{0}  {1}\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid response, not enough items");
                                        }

                                    }
                                    goto INVEN;
                                    break;
                                }
                            case "STRING":
                                {
                                    if (cat[0].Items[5].Inven < 0)
                                        Console.WriteLine("There is no more of this item available in this area.");
                                    else
                                    {
                                        Console.Write("How many? (Note: you can't pick up more than 10 of an item) ");
                                        int j = Convert.ToInt32(Console.ReadLine().Trim());
                                        if (j <= cat[0].Items[5].Inven && j < 11)
                                        {
                                            cat[0].Items[5].Inven -= j;
                                            myInventory.Add(new Items(cat[0].Items[5].Name, j));
                                            for (int i = 0; i < cat[f].NumItems; i++)
                                            {
                                                Console.WriteLine("\t{0}  {1}\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid response, not enough items");
                                        }

                                    }
                                    goto INVEN;
                                    break;
                                }
                        }

                    }
                    break;

                case "N": case "NO":
                    {
                        Console.WriteLine("Enter [1] to go to Area 1");
                        Console.WriteLine("Enter [2] to go to Area 2");
                        Console.WriteLine("Enter [3] to go to Area 3");
                        Console.WriteLine("Enter [4] to go to Area 4");
                        Console.WriteLine("Enter [5] to go to Area 5");
                        Console.WriteLine();
                        //Console.WriteLine("Enter [c] to use the Crafting Area");
                        //Console.WriteLine("Enter [s] to open the storage Area");
                        Console.WriteLine("Enter [r] to attempt to repair the Airplane");
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Enter QUIT to end the game");
                        Console.Write("Your Response: ");
                        string x = Console.ReadLine().ToUpper().Trim();
                        switch (x)
                        {
                            case "1":
                                    Area1(cat, myInventory); return;
                            case "2":
                                Area2(cat, myInventory); break;
                            case "3":
                                Area3(cat, myInventory); return;
                            case "4":
                                Area4(cat, myInventory); return;
                            case "5":
                                Area5(cat, myInventory); return;
                            case "R":
                                { // Wouldn't work with &&, so used multiple if statements
                                    if (cat[1].Items[0].Inven < 1){
                                        if(cat[5].Items[0].Inven < 1)
                                            if (cat[10].Items[0].Inven < 1 )
                                                if (cat[8].Items[0].Inven < 1 )
                                                    if (cat[4].Items[0].Inven < 1)
                                                    { // if user has needed items
                                                        Console.WriteLine("YAY! You were able to fix the airplane! Congratulations!!! YOU WIN!!!");
                                                        return;
                                                    }
                                    }
                                    else
                                    {
                                        Console.WriteLine("It looks like you don't have all the items needed to repair the airplane.");
                                    }
                                    
                                }break;
                            case "QUIT":
                                {
                                    Console.WriteLine("Thanks for Playing our Adventure Game!!!");
                                    return;
                                }
                        }
                    }break;

                default:
                    Console.WriteLine("Invalid Entry");
                    Console.Write("Would you like to take any of these items? [Enter YES or NO] ");
                    p = Console.ReadLine().ToUpper().Trim();
                    break;

            }
            }

        }

        static void Area1(List<Category> cat, List<Items> myInventory)
        {
            int f = 1;
            bool ok = true;

            Console.WriteLine("You're currently in Area 1");
            Console.WriteLine("You look around and see these items in the sand: ");
            Console.WriteLine("-------------------------------------------------------------------------------");

            for (int i = 0; i < cat[f].NumItems; i++)
            {
                Console.WriteLine("\tSign\n");
                Console.WriteLine("\t{0}  {1}(Quantity)\n", cat[f].Items[i].Name, cat[f].Items[i].Inven);
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            while (ok)
            {
                
                Console.WriteLine("\tWhat do you want to do? ");
                Console.WriteLine("\tEnter [L] to look at sign");
                if (cat[1].Items[0].Inven > 0)
                {
                    Console.WriteLine("\tEnter [I] to grab Motor Piece 1 (you need to find the second motor piece" +
                        " \tin order to build the full motor piece needed to repair the airplane");
                }
                Console.WriteLine("\tEnter [Leave] to go to another area");
                Console.WriteLine("\tEnter QUIT to end the game");
                Console.Write("Your response: ");
                string x = Console.ReadLine().ToUpper().Trim();
                switch (x)
                {
                    case "L":
                        {
                            Console.WriteLine("The sign says: ");
                            Console.WriteLine("\tThere is a camp located at area 2");
                            Console.WriteLine("\tThis camp has several different characters you can talk to");
                            Console.WriteLine("\tGo there to try to gain more info about the whereabouts of the items on the island");
                            Console.WriteLine("\t Area 2 can be accessed from this area.");
                            Console.WriteLine("\n\n");
                        }break;
                    case "I":
                        {
                            if (cat[1].Items[0].Inven < 0)
                                Console.WriteLine("There is no more of this item available in this area.");
                            else
                            {
                                cat[1].Items[0].Inven -= 1;
                                myInventory.Add(new Items(cat[1].Items[0].Name, cat[1].Items[0].Inven + 1));
                            }
                                
                        }break;
                    case "LEAVE":
                        {
                            Console.WriteLine("Enter [0] to go to Area 0 -- Home Area");
                            Console.WriteLine("Enter [2] to go to Area 2");
                            Console.WriteLine("Enter [4] to go to Area 4");
                            Console.WriteLine();
                            string k = Console.ReadLine().ToUpper().Trim();
                            switch (k)
                            {
                                case "0":
                                    HomeArea(cat, myInventory); ok = false; break;
                                case "2":
                                    Area2(cat, myInventory); ok = false; break;
                                case "4":
                                        Area4(cat, myInventory); break;
                                case "QUIT":
                                    {
                                        Console.WriteLine("You're being returned to Area 1, to Quit game Enter [QUIT] again.");
                                        return;
                                    }
                            }
                        }break;
                    case "QUIT":
                        {
                            Console.WriteLine("Thanks for Playing our Adventure Game!!!");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Entry");
                            Console.WriteLine("\tWhat do you want to do? ");
                            Console.WriteLine("\tEnter [L] to look at sign");
                            if (cat[1].Items[0].Inven > 0)
                            {
                                Console.WriteLine("\tEnter [I] to grab Motor Piece 1 (you need to find the second motor piece" +
                                    " \tin order to build the full motor piece needed to repair the airplane");
                            }
                            Console.WriteLine("Enter [Leave] to go to another area");
                            Console.WriteLine("Enter QUIT to end the game");
                            Console.Write("Your response: ");
                            x = Console.ReadLine().ToUpper().Trim();
                        }break;
                }

            }
        }

        static void Area2(List<Category> cat, List<Items> myInventory)
        {
            Console.WriteLine("You're currently in the camp at Area 2");
            Console.WriteLine("The camp features several different characters you can communicate with.");
            Console.WriteLine("To Talk to a charcter, enter [t] followed by your selection.");
            Console.WriteLine("\n\n");
            Console.WriteLine("You look around the camp and notice people eating food by the benches.");
            Console.WriteLine("You see an older gentlemen by the corner reading a map of the what appears to be the island.");
            Console.WriteLine("You see a child holding a large golden key.");
            Console.WriteLine("\n\n");
       TALK:Console.WriteLine("What do you wish to do? ");
            Console.WriteLine("\tEnter [1] to talk to the older gentlemen.");
            Console.WriteLine("\tEnter [2] to talk to the child.");
            Console.WriteLine("\tEnter [f] to eat some of the food that the island natives are eating.");
            Console.WriteLine("\tEnter [LEAVE] to go to another area. ");
            Console.Write("Your response: ");
            string x = Console.ReadLine().ToUpper().Trim();
            switch (x)
            {
                case "1":
                    {
                        Console.Clear();
                        if (GetYesNo("Older Gentlemen: Why Hello there stranger. You look lost. Is there something I can help you with? [Enter YES or NO] "))
                        {
                            Console.WriteLine("\nYour response: Yes there is. I need help finding a few items. Do you happen to know the " +
                                "whereabouts of a few engine parts that I am looking for? It would be of great help.\n\n");
                            Console.WriteLine("Older Gentlemen: Why of course. You've come to the right spot. You may want to write this down. *Hint Hint* \n" +
                                "\tThe engine part is located in the Bear Cave (Area 11). \n" +
                                "\tThe button is located in Area 5 with Eve. \n" +
                                "\tThe spark plug is located in Area 9. \n" +
                                "\tThe Motor can be created at the crafting station in the home area if you have the 2 motor pieces. \n" +
                                "\tMotor Piece 1 can be found in Area 1.\n " +
                                "\tMotor Piece 2 can be found in Area 6. \n" +
                                "\tFuel can be purchased from the Island Mart in Area 4, use wood and fresh food as currency.\n " +
                                "\tThe Star Trek References and Toy Model of the Enterprise can be located at Area 3. \n" +
                                "\tA good grade from Professor Viall can be found in the Secret Room that needs a golden key to unlock. \n" +
                                "\tThe Secret Room can be accessed from Area 5");
                            Console.WriteLine("\n");
                            Console.WriteLine("Now if you excuse me, Star Trek is about to come on. Bye-bye.");
                            goto TALK;
                        }
                        else
                        {
                            Console.WriteLine("Well get lost then.");
                            goto TALK;
                        }
                        break;
                    }
                case "2":
                    {
                        if (cat[2].Items[1].Inven > 0)//if there's still a golden key left in the main game's inventory
                        {
                            Console.Clear();
                            Console.WriteLine("You walk up to the child's seat.");
                            Console.WriteLine("You notice that the child is performing tricks with the golden key to impress the nearby girls.");
                            Console.WriteLine("\n\n");
                            Console.WriteLine("You: Hey kid! I really need that key! It's literally the key to get off this island.");
                            Console.WriteLine("Kid: Beat it old-timer. I'm trying to pick up these lovely ladies over there. ");
                            Console.WriteLine();
                            Console.WriteLine("You become a bit aggitated and take a seat regardless. ");
                            Console.WriteLine("The girls who were originally giggling at the kid uncomfortably walked away once you came by. ");
                            Console.WriteLine();
                            Console.WriteLine("Kid: Way to go man. They went away. ");
                            Console.WriteLine("Kid: What was it that you wanted anyways? ");
                            Console.WriteLine("You: I've come to take the golden key from you, I need it to unlock a hidden door.");
                            Console.WriteLine("Kid: What's in it for me");
                            Console.WriteLine("You: I'm sure your wanting something a bit more tasty than what you ate here. I can get a pie for you. ");
                            Console.WriteLine("Kid: I guess I can help you. I'd like a pie.");
                            Console.WriteLine("Kid: You got a deal. You bring me a pie, and I'll give you this key. ");
                            Console.WriteLine("\n\n");
                            goto TALK;
                        }
                        else //if the user has successfully completed the previous arrangments
                        {
                            Console.Clear();
                            Console.WriteLine("You give the kid the pie. ");
                            Console.WriteLine("The kid takes away the pie in excitement and hands you the golden key");
                            cat[2].Items[1].Inven = 0;
                            myInventory.Add(new Items(cat[2].Items[1].Name, cat[2].Items[1].Inven + 1));
                            goto TALK;
                                    
                        }
                    }break;
                case "F":
                    {
                        Console.Clear();
                        Console.WriteLine("You go over to the serving table to gather food. ");
                        Console.WriteLine("You eat until your heart's content.");
                        Console.WriteLine("Nam-nam nam .... *burps* *rub tummy*");
                        goto TALK;
                    }break;
                case "LEAVE":
                    {
                        Console.WriteLine("Enter [0] to go to Area 0 -- Home Area");
                        Console.WriteLine("Enter [1] to go to Area 1");
                        Console.WriteLine("Enter [2] to go to Area 2");
                        Console.WriteLine("Enter [3] to go to Area 3");
                        Console.WriteLine("Enter QUIT to end the game");
                        Console.Write("Your response: ");
                        string k = Console.ReadLine().ToUpper().Trim();
                        switch (k)
                        {
                            case "0":
                                HomeArea(cat, myInventory);break;
                            case "1":
                                Area1(cat, myInventory); break;
                            case "2":
                                Area2(cat, myInventory); break;
                            case "3":
                                Area3(cat, myInventory); break;
                            case "4":
                                    Area4(cat, myInventory); break;
                            case "QUIT":
                                {
                                    Console.WriteLine("You're being returned to Area 1, to Quit game Enter [QUIT] again.");
                                    return;
                                }
                        }
                    }break;
                 }
        }

        static void Area3(List<Category> cat, List<Items> myInventory)
        {
            int f = 3;
            Console.WriteLine("You're currently in Area 3. ");
            if (cat[3].Items[1].Inven > 0) //only prompt user if they don't already have the items.
            {
                Console.WriteLine("\tYou notice strange looking items in the nearby bushes. " +
                    "\tYou decide to take a closer look. *slowly moves toward the bushes* " +
                    "\tAs you get closer, you can hear strange music coming from the bushes. " +
                    "\tYou finally arrive at the bush and move away some of the vegetation " +
                    "\tYou come to a discovery that the music playing is actually the Theme Music to the original Star Trek series. " +
                    "\tThe items you see are Star Trek references and a Toy Model of the Enterprise. ");
                if (GetYesNo("Would you like to pick up these items? [Enter YES or NO]  "))
                {
                    Console.WriteLine();
                    Console.WriteLine("You've picked up the Star Trek references and a Toy Model of the Enterprise!!!");
                    for (int i = 0; i < cat[f].NumItems; i++)
                    {
                        cat[f].Items[i].Inven -= 1;
                        myInventory.Add(new Items(cat[f].Items[i].Name, cat[f].Items[i].Inven + 1));
                    }
                }
            }
            else
            {
                Console.WriteLine("What do you wish to do? ");
                Console.WriteLine("\tEnter [0] to go to Area 0 -- Home Area");
                Console.WriteLine("\tEnter [2] to go to Area 2.");
                Console.WriteLine("\tEnter [5] to go to Area 5 ");
                Console.WriteLine("\tEnter QUIT to end the game");
                Console.Write("Your response: ");
                string x = Console.ReadLine().ToUpper().Trim();
                switch (x)
                {
                    case "0":
                        HomeArea(cat, myInventory); break;
                    case "2":
                        Area2(cat, myInventory); break;
                    case "5":
                         Area5(cat, myInventory); break;
                    case "QUIT":
                        {
                            Console.WriteLine("You're being returned to Area 1, to Quit game Enter [QUIT] again.");
                            return;
                        }
                }
            }
        }

        static void Area4(List<Category> cat, List<Items> myInventory)
        {

        }

        static void Area5(List<Category> cat, List<Items> myInventory)
        {
            if (cat[5].Items[0].Inven > 0)
            {
                Console.Clear();
                Console.WriteLine("\tYou're currently in Area 5 in front of Eve's house. "+
                    "\tYou notice Eve planting flowers in her garden. "+
                    "\t\n"+
                    "Eve: Well Hiya stranger! What brings you over here to my next of the woods?\n "+
                    "You: Hello! I'm not from here. I'm trying to get home. I need to find some engine parts in order to fix my plane.\n "+
                    "You: Do you know where I can find any of these items *reads list of needed items to Eve* \n"+
                    "Eve: Oh NO! We have to get you back. I think I might be able to help you out. \n "+
                    "Eve: *walks to a nearby shed and starts searching* *clunk clunk clunk(sounds of moving metal and other items)* \n"+
                    "Eve: I found this button thingy that I have no use for. It's yours if you can bring me 2 apples\n" +
                    "You: You got it! \n");
                if (cat[10].Items[4].Inven > 5)//apple inven count needs to be 4 or less since there is original 6 apples in original inventory
                {
                    Console.WriteLine("\tI actually happen to have two apples on me right now. ");
                    Console.WriteLine("\tHere are your apples!");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Eve: Hope you found everything else you needed! Safe Travels home! ");

     ASK:   Console.WriteLine("What do you wish to do? ");
            Console.WriteLine("\tEnter [0] to go back to Area 0 -- Home Area");
            Console.WriteLine("\tEnter [3] to go to Area 3");
            Console.WriteLine("\tEnter [7] to go to Area 7 -- The Bakery.");
            Console.WriteLine("\tEnter [8] to go to Area 8 -- The Special Room ");
            Console.WriteLine("\tEnter QUIT to end the game");
            Console.Write("Your response: ");
            string x = Console.ReadLine().ToUpper().Trim();
            switch (x)
            {
                case "0":
                    HomeArea(cat, myInventory); break;
                case "3":
                    Area3(cat, myInventory); break;
                case "7":
                    Area7(cat, myInventory); break;
                case "8":
                    {
                        if (cat[2].Items[1].Inven == 0) //if the user already has the golden key
                        {
                            Console.WriteLine("You use the Golden Key to unlock the Door *Door unlocks* \n");
                            Area8(cat, myInventory);
                        }
                        else
                        {
                            Console.WriteLine("This door appears to be locked ");
                            goto ASK;
                        }
                    }break;
                case "QUIT":
                    {
                        Console.WriteLine("You're being returned to Area 1, to Quit game Enter [QUIT] again.");
                        return;
                    }
            }
        }

        static void Area6(List<Category> cat, List<Items> myInventory)
        {

        }

        static void Area7(List<Category> cat, List<Items> myInventory)
        {

        }

        static void Area8(List<Category> cat, List<Items> myInventory)
        {
            Console.WriteLine("Prof Viall: Welcome to 264. I am Professor Viall. I hope you had a great time in my class. "+ 
            "Right now you currently have an F. In order to get a good grade, bring me items I love");
            if(GetYesNo("Do you have the items that I love? "))
            {
                Console.WriteLine("Hmm, Let me see. \n");
                if (cat[3].Items[0].Inven < 1 )//if Start Trek References is gone from main inventory
                {
                    Console.WriteLine("Prof Viall: YES THATS IT! You now have an A in the course! Congratulations! Here's your good grade. ");
                    cat[8].Items[0].Inven = 0;
                }

            }
        }

        static void Area9(List<Category> cat, List<Items> myInventory)
        {

        }

        static void Area10(List<Category> cat, List<Items> myInventory)
        {

        }

        // UNIVERSAL GET STRING WITH PROMPT, VALID VALUES, AND ERROR MESSAGE
        static string GetString(string prompt, string[] valid, string error)
        {
            // prompt=user prompt, valid=array responses, error=msg to display on invalid entry
            //ALL STRINGS RETURNED UPPER CASE. ALL valid[] ENTRIES MUST BE IN UPPER CASE
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

        static void MyInventory(List<Items> myInventory) //write to inventory list
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("..\\..\\MyInventory.txt"))
                {
                    //List<int> inven = new List<int>();
                    //int a = 0;
                    for (int j = 0; j < myInventory.Count(); j++)
                    {
                        sw.WriteLine("{0} {1}", myInventory[j].Name, myInventory[j].Inven);
                        //inven.Add()
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't open file because {0}", e.Message);
            }
        }

        static void ReadMyInven(out List<Category> mi)
        {
            string line;
            string[] tokens;
            string name;
            int i, item;

            mi = new List<Category>();
            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\MyInventory.txt")) //try calling the superstore.txt file and read the data from the file
                {
                    while (sr.Peek() >= 0)
                    {
                        List<Items> tmpItems = new List<Items>();
                        line = sr.ReadLine();
                        tokens = line.Split(',');
                        name = tokens[0].Trim();
                        item = Convert.ToInt32(tokens[1].Trim());
                        for (i = 0; i < item; i++)
                        {
                            line = sr.ReadLine();
                            tokens = line.Split(',');
                            Items tmpItem = new Items(
                                tokens[0].Trim(),
                                Convert.ToInt32(tokens[1].Trim()));
                            tmpItems.Add(tmpItem);
                        }
                        mi.Add(new Category(name, item, tmpItems));
                    }
                    sr.Close();
                }
            }
            catch (Exception e)//If unable to detect file, print out error message.
            {
                Console.WriteLine("Error occured: {0}", e.Message);
            }
        }
    }
}
