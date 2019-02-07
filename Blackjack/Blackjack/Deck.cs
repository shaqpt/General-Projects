using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        //private Card[] cards = new Card[52];
        private List<Card> Cards = new List<Card>(52);

        public Deck()
        {
            for (int suitVal=0; suitVal<4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                    Cards.Add(new Card((Suit)suitVal,(Rank)rankVal));
            }
        }

        public Card GetCard(int cardNum)
        {
            return Cards[cardNum];
        }

        public void Shuffle()
        {
            List<Card> newDeck = new List<Card>();
            Deck ChkDck = new Deck();
            List<bool> assigned = new List<bool>();  // keep track of what locs used in newDeck
            for (int i = 0; i < ChkDck.Cards.Count(); i++) assigned.Add(false);

            int seed = 0;
            Console.Write("Enter seed: ");
            seed = Convert.ToInt32(Console.ReadLine()); //user can break if they don't submit a valid integer
            Random rGen = new Random(seed);
            int shufIndex = 0;
            shufIndex = rGen.Next(52);
            for (int i = 0; i < ChkDck.Cards.Count(); i++)
            {
                while (assigned[shufIndex])
                    shufIndex = rGen.Next(ChkDck.Cards.Count());
                newDeck.Add(ChkDck.GetCard(shufIndex));
                assigned[shufIndex] = true;
            }
            Cards = newDeck;
        }
    }
}
