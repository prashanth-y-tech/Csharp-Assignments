using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public abstract class CardsDeck<T>
    {
        public List<T> cardsDeck;
        public CardsDeck()
        {
            cardsDeck = new List<T>();
        }
        public abstract void CreateDeck();

        public void ShuffleDeck()
        {
            Random random = new Random();
            for(int i = 0; i < cardsDeck.Count(); i++)
            {
                int r = random.Next(0, cardsDeck.Count());
                T temp = cardsDeck[i];
                cardsDeck[i] = cardsDeck[r];
                cardsDeck[r] = temp;
            }
        }

        public abstract void SortDeck();

        public T GetTopCard()
        {
            return cardsDeck[0];
        }
        public abstract void CombineDecks(IEnumerable<dynamic> combineDeck);
    }
}
