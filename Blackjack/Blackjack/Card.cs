using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        // fields are public and readonly
        public readonly Rank rank;
        public readonly Suit suit;

        private Card()
        {
            throw new System.NotImplementedException();
        }

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            string[] sSuit = { "\x03", "\x04", "\x05", "\x06","?" };
            string[] sRank = { "?","A","2","3","4","5","6","7","8",
                               "9","10","J","Q","K"};
            return sRank[(int)rank] + sSuit[(int)suit];
        }
    }
}
