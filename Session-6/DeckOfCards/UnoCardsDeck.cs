using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public class UnoCardsDeck : CardsDeck<UnoCard>
    {
        private enum Suits
        {
            red,
            yellow,
            green,
            blue,
            wildcards
        };
        private enum Ranks
        {
            one,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            draw2,
            reverse,
            skip,
            wildChange,
            wildDraw4
        };


        public override void CreateDeck()
        {

            foreach (string suit in Enum.GetNames(typeof(Suits)))
            {
                if (!suit.Equals("wildcards"))
                {
                    foreach (string rank in Enum.GetNames(typeof(Ranks)))
                    {
                        if(rank.Equals("wildChange") || rank.Equals("wildDraw4"))
                        {
                            break;
                        }
                        cardsDeck.Add(new UnoCard(suit, rank));
                        if (!rank.Equals("one"))
                        {
                            cardsDeck.Add(new UnoCard(suit, rank));
                        }
                    }
                }
                else
                {
                    foreach(string wildRank in Enum.GetNames(typeof(Ranks)))
                    {
                    if(wildRank.Equals("wildChange") || wildRank.Equals("wildDraw4"))
                        {
                            break;
                        }
                        cardsDeck.Add(new UnoCard(suit, wildRank));
                        cardsDeck.Add(new UnoCard(suit, wildRank));
                        cardsDeck.Add(new UnoCard(suit, wildRank));
                        cardsDeck.Add(new UnoCard(suit, wildRank));
                    }
                }
            }
        }

        public override void SortDeck()
        {
            cardsDeck = cardsDeck.OrderBy(x => (int)Enum.Parse(typeof(Suits), x.Suit)).ThenBy(y => (int)Enum.Parse(typeof(Ranks), y.Rank)).ToList();
        }

        public override void CombineDecks(IEnumerable<dynamic> combineDeck)
        {
            Type combineDeckType = combineDeck.GetType().GetGenericArguments().Single();
            Type cardsDeckType = cardsDeck.GetType().GetGenericArguments().Single();
            if (combineDeckType.Equals(cardsDeckType))
            {
                cardsDeck.AddRange((IEnumerable<UnoCard>)combineDeck);
            }
            InvalidMergeException invalidMergeException = new InvalidMergeException($"invalid merge between types {combineDeckType} and {cardsDeckType}", combineDeckType, cardsDeckType);
            throw invalidMergeException;
        }
    }
}
