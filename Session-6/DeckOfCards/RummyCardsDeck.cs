using System;
using System.Collections.Generic;
using System.Linq;


namespace DeckOfCards
{
    public class RummyCardsDeck: CardsDeck<RummyCard>
    {
        private enum Suits 
        { 
            clubs,
            spades,
            hearts,
            diamonds
        };
        private enum Ranks
        { 
            Ace,
            King,
            Queen,
            Jack,
            ten,
            nine,
            eight,
            seven,
            six,
            five,
            four,
            three,
            two
        };
       
        public override void CreateDeck()
        {
            
            foreach(string suit in Enum.GetNames(typeof(Suits)))
            {
                foreach(string rank in Enum.GetNames(typeof(Ranks)))
                {
                    cardsDeck.Add(new RummyCard(suit,rank));
                }
            }
        }

        public override void SortDeck()
        {
            cardsDeck = cardsDeck.OrderBy(x => (int)Enum.Parse(typeof(Suits),x.Suit)).ThenBy(y => (int)Enum.Parse(typeof(Ranks), y.Rank)).ToList();
        }

        public override void CombineDecks(IEnumerable<dynamic> combineDeck)
        {
            Type combineDeckType = combineDeck.GetType().GetGenericArguments().Single();
            Type cardsDeckType = cardsDeck.GetType().GetGenericArguments().Single();
            if (combineDeckType.Equals(cardsDeckType))
            {
                cardsDeck.AddRange((IEnumerable<RummyCard>)combineDeck);
                return;
            }
            InvalidMergeException invalidMergeException = new InvalidMergeException($"invalid merge between types {combineDeckType} and {cardsDeckType}", combineDeckType, cardsDeckType);
            throw invalidMergeException;
        }
    }
}
