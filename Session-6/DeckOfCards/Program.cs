using System;


namespace DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating objects for 2 cards decks
            RummyCardsDeck rummyCardsDeck1 = new RummyCardsDeck();
            UnoCardsDeck unoCardsDeck1= new UnoCardsDeck();
            //creating decks of 2 types of cards
            unoCardsDeck1.CreateDeck();
            rummyCardsDeck1.CreateDeck();
            //shuffling the card decks
            unoCardsDeck1.ShuffleDeck();
            rummyCardsDeck1.ShuffleDeck();
            //sorting the card decks
            unoCardsDeck1.SortDeck();
            rummyCardsDeck1.SortDeck();
            //Getting the top element of the decks of cards
            Console.WriteLine(unoCardsDeck1.GetTopCard().GetCardName());
            Console.WriteLine(rummyCardsDeck1.GetTopCard().GetCardName());
            //Combining the decks of cards
            try
            {
                unoCardsDeck1.CombineDecks(rummyCardsDeck1.cardsDeck);
                foreach (RummyCard card in rummyCardsDeck1.cardsDeck)
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
