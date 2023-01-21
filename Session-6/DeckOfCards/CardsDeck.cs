using DeckOfCards.Extension;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public delegate void SortDeck();
    public class CardsDeck
    {
        private List<ICard> cardsDeck;
        public CardsDeck(List<ICard> cardsDeck1)
        {
            this.cardsDeck = cardsDeck1;
        }
        
        public void Sort()
        {
            switch (cardsDeck[0]) 
            {
                case  RummyCard _:
                    cardsDeck.SortRummyDeck();
                    break;
                case UnoCard _:
                    cardsDeck.SortUnoDeck();
                    break;
                default:
                    Console.WriteLine("Deck doesn't have a sorting function defined");
                    break;
            }
        }

        private List<int> prevRandoms = new List<int>();
        private int GenerateRandom(int length)
        {
            Random random= new Random();
            int randomNumber = random.Next(length);
            while(prevRandoms.Contains(randomNumber))
            {
                randomNumber =  random.Next(length);
            }
            prevRandoms.Add(randomNumber);
            return randomNumber;
        }

        public void Shuffle()
        {
            for(int i = 0; i < cardsDeck.Count(); i++)
            {
                int randomNumber = GenerateRandom(cardsDeck.Count());
                ICard temp = cardsDeck[randomNumber];
                cardsDeck[randomNumber] = cardsDeck[i];
                cardsDeck[i] = temp;
            }
        }

        public ICard GetTopCard()
        {
            ICard card = cardsDeck[0];
            cardsDeck.RemoveAt(0);
            return card;
        }

        public List<ICard> DisplayDeck()
        {
            return cardsDeck;
        }

        public  static CardsDeck operator +(CardsDeck deck1 , CardsDeck deck2)
        {
            Type deck1Type = deck1.DisplayDeck()[0].GetType();
            Type deck2Type = deck2.DisplayDeck()[0].GetType();
            if (deck1Type.Equals(deck2Type))
            {
                List<ICard> combinedDeck = deck1.cardsDeck.Concat(deck2.cardsDeck).ToList<ICard>();
                return new CardsDeck(combinedDeck);
            }
            InvalidMergeException invalidMergeException = new InvalidMergeException($"invalid merge between types {deck1Type} and {deck2Type}", deck1Type, deck2Type);
            throw invalidMergeException;
        }
    }
}
