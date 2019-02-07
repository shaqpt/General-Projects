using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to BLACKJACK\n");
            Console.Write("You are initially given $500 to play with\n");
            Console.Write("Table limit is $250 per hand (enter 0 to quit)\n");
            Console.Write("");
            string name = GetName();
            GetGame(name); // basically the whole game
        }
        static string GetName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            return name;
        }
        static void GetGame(string name) //initialize the cards and determine w 
        {
            double w = 500;
            Deck d = new Deck();
            d.Shuffle();
            Card[] PlaHand = new Card[6];
            Card[] DelHand = new Card[10];
            int PlayerCounter = 0;
            int DealerCounter = 0;
            int TableCounter = 0;
            bool Ok = false;

            while (!Ok) //basically loops forever unless loop is chnaged
            {
                //greeting statment based on w
                if (w >= 0) Console.WriteLine("Hello {0}, you are ${1} Ahead\n", name, w);
                else if (w < 0) Console.WriteLine("Hello {0}, you are ${1} behind\n", name, Math.Abs(w));
                double wager = GetWager(w);

                //Deals the initial cards
                GetDeal(d, PlaHand, ref PlayerCounter, ref TableCounter);
                GetDeal(d, DelHand, ref DealerCounter, ref TableCounter);
                GetDeal(d, PlaHand, ref PlayerCounter, ref TableCounter);
                GetDeal(d, DelHand, ref DealerCounter, ref TableCounter);

                //shows the hand to the player
                GetHands(PlaHand, DelHand);

                bool go = true;
                int Phand = 0;
                int Dhand = 0;
                while (go == true && Phand < 21)
                {
                    string HorS = HitorStay(); //HitorStay function to ask to hit or stay and check entered values
                    if (HorS == "H" || HorS == "HIT")
                    {
                        GetDeal(d, PlaHand, ref PlayerCounter, ref TableCounter);
                        GetHands(PlaHand, DelHand);
                        if (PlayerCounter >= 5) { go = false; }// 5 card charlie check if it triggers set go to false exit the while and go to 
                    }
                    else if (HorS == "S" || HorS == "STAY")
                    {
                        go = false;
                    }
                    Phand = GetMath(PlaHand, ref PlayerCounter);
                    Dhand = GetMath(DelHand, ref DealerCounter);
                }
                //Checks if theres a 5 card charlie
                if (Phand <= 21 && PlayerCounter >= 5)
                {
                    Console.WriteLine("{0}! You win with a Five Card Charlie!\n", name);
                    w = w + wager;
                    go = false;
                }
                else if (Phand > 21)
                {
                    Console.WriteLine("{0}, you BUSTED\n", name);
                    w = w - wager;
                }
                else if (Phand <= 21 && Dhand > 21)
                {
                    Console.WriteLine("The Dealer BUSTED\n");
                    w = w + wager;
                }
                else if (Phand <= 21 && Dhand <= 21)
                {
                    Console.Write("Dealers Cards: ");
                    int k = 0;
                    while (k < DealerCounter)
                    {
                        Console.Write(" {0},", DelHand[k]);
                        k++;
                    }
                    Console.WriteLine();
                    while (Dhand < 18)
                    {
                        GetDeal(d, DelHand, ref DealerCounter, ref TableCounter);
                        Console.WriteLine("Dealer draws: {0}", DelHand[k]);
                        Dhand = GetMath(DelHand, ref DealerCounter);
                        k++;
                    }
                    if (Phand < 22 && Dhand > 21)
                    {
                        Console.WriteLine("Dealer BUSTED\n");
                        w = w + wager;
                    }
                    else if (Phand < Dhand)
                    {
                        Console.WriteLine("Dealer WINS\n");
                        w = w - wager;

                    }
                    else if (Phand <= 21)
                    {
                        Console.WriteLine("{0} WINS", name);
                        w = w + wager;
                    }
                    else { /* do nothing */ }
                }
                else { /* do nothing */ }
                PlaHand = new Card[6];
                DelHand = new Card[10];
                PlayerCounter = 0;
                DealerCounter = 0;
            }
        }

        static void GetHands(Card[] PlaHand, Card[] DelHand)
        {
            Console.Write("Your cards: ");
            for (int i = 0; PlaHand[i] != null; i++)
            {
                Console.Write(" {0},", PlaHand[i]);
            }
            Console.Write(" (Dealers show card: {1})\n\n", DelHand);
        }
        static double GetWager(double w)
        {
            bool trywager = false;
            int j = 0;
            while (trywager == false)
            {
                Console.Write("What is your wager: ");
                string wager = Console.ReadLine();
                trywager = int.TryParse(wager, out j);
                if (trywager == false) Console.WriteLine("Reread the rules BONEHEAD - that is not a wager.");
                else if (j > 250)
                {
                    Console.WriteLine("Reread the rules BONEHEAD - table limit is $250.");
                    trywager = false;
                }
                else if (j < 0)
                {
                    Console.Write("Reread the rules BONEHEAD - your wager is too small; you can't wager a negative number.\n");
                    trywager = false;
                }
                else if (j == 0)
                {
                    if (w > 0) Console.WriteLine("Thank you for playing, come back soon!");
                    else if (w < 0) Console.WriteLine("'Billy the Bone Breaker' (the accounts receivable clerk) is responsible for collections, and will be in touch soon");
                    Environment.Exit(0);
                }
            }
            return j;
        }
        static string HitorStay()
        {
            bool ok = false;
            string HorS = "";
            while (ok == false)
            {
                Console.Write("Do you want a (H)it or to (S)tay: ");
                HorS = Console.ReadLine().ToUpper();
                if (HorS == "H" || HorS == "HIT" || HorS == "S" || HorS == "STAY") ok = true;
                else { Console.WriteLine("Reread the rules BONEHEAD - Enter (H)it or (S)tay"); }
            }
            return HorS;
        }
        static int GetMath(Card[] Hand, ref int Counter)
        {
            int i = 0;
            int sum = 0;
            bool ace = false;
            while (sum <= 21 && i <= Counter && Hand[i] != null)
            {
                int card = (int)Hand[i].rank;
                if (Hand[i].rank == Rank.Ace)
                {
                    sum = sum + 11;
                    ace = true;
                }
                else if (card >= 10) sum = sum + 10;
                else if (card <= 10) sum = sum + (int)Hand[i].rank;
                else {/* do nothing */ }
                if (sum > 21 && ace == true) // Count ace as either 1 or 11
                {
                    sum = sum - 10;
                    ace = false;
                }
                i++;
            }
            return sum;
        }
        static Card[] GetDeal(Deck d, Card[] Hand, ref int HandCounter, ref int TableCounter) //gives a deal of a card to either the dealer or the player and reshuffles the deck
        {
            bool x = true;
            if (x)
            {
                if (TableCounter >= 51) //Checks current hand
                {
                    d.Shuffle();
                    TableCounter = 0;
                }
                Hand[HandCounter++] = d.GetCard(TableCounter++);
            }
            return Hand;
        }
    }
}