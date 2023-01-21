

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
        public string Suit { get; set; }
        public string Rank { get; set; }

        public RummyCard(string suit, string rank)
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
