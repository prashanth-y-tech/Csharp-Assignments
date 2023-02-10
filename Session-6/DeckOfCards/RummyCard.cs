using System;

namespace DeckOfCards
{
    enum RummySuits
    {
        Clubs,
        Spades,
        Hearts,
        Diamonds
    };
    enum RummyRanks
    {
        Ace,
        King,
        Queen,
        Jack,
        Ten,
        Nine,
        Eight,
        Seven,
        Six,
        Five,
        Four,
        Three,
        Two
    };
    public class RummyCard : ICard
    {
        public Enum Suit { get; set; }
        public Enum Rank { get; set; }

        public RummyCard(Enum suit, Enum rank)
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
