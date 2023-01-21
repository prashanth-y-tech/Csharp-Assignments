using System;
using System.Linq;

namespace DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string RUMMYCARD = "Rummy Card";
            const string UNOCARD = "Uno Card";

            //Creating objects for 2 cards decks

            CardsDeck rummyDeck = CardDeckManufacturer.GetDeck(RUMMYCARD);
            CardsDeck unoDeck = CardDeckManufacturer.GetDeck(UNOCARD);

            //shuffling the card decks

            unoDeck.Shuffle();
            rummyDeck.Shuffle();

            //sorting the card decks

            unoDeck.Sort();
            rummyDeck.Sort();

            //Getting the top element of the decks of cards

            Console.WriteLine(unoDeck.GetTopCard().GetCardName());
            Console.WriteLine(rummyDeck.GetTopCard().GetCardName());

            //Combining the decks of cards

            try
            {
                var x = rummyDeck + unoDeck;
                foreach (RummyCard card in x.DisplayDeck())
                {
                    Console.WriteLine(card.GetCardName());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
