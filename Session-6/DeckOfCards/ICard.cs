
using System;

namespace DeckOfCards
{
    public interface ICard
    {
        string Rank { get; set; }
        string Suit { get; set; }
        string GetCardName();
    }
}
