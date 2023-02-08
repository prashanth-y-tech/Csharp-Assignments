
using System;

namespace DeckOfCards
{
    public interface ICard
    {
        Enum Rank { get; set; }
        Enum Suit { get; set; }
        string GetCardName();
    }
}
