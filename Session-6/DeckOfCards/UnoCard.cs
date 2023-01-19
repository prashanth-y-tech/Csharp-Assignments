using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class UnoCard : ICard
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public UnoCard(string suit, string rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public string GetCardName()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
