
using System;

namespace DeckOfCards
{
    enum UnoSuits
    {
        Red,
        Yellow,
        Green,
        Blue,
        Wildcards
    };
    enum UnoRanks
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Draw2,
        Reverse,
        Skip,
        WildChange,
        WildDraw4
    };
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
