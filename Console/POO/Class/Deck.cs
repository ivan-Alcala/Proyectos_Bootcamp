using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class Deck
    {
        private List<Card> cards;
        private static Random random = new Random();

        public Deck(string gameType)
        {
            cards = new List<Card>();

            if (gameType == "Spanish")
                LoadSpanishDeck();
            else if (gameType == "Poker")
                LoadPokerDeck();
        }

        private void LoadSpanishDeck()
        {
            eSpanishSuit[] suits = (eSpanishSuit[])Enum.GetValues(typeof(eSpanishSuit));

            foreach (eSpanishSuit suit in suits)
            {
                for (int value = 1; value <= 7; value++)
                    cards.Add(new Card(suit, value));

                for (int value = 10; value <= 12; value++)
                    cards.Add(new Card(suit, value));
            }
        }

        private void LoadPokerDeck()
        {
            ePokerSuit[] suits = (ePokerSuit[])Enum.GetValues(typeof(ePokerSuit));

            foreach (ePokerSuit suit in suits)
            {
                // Añadir cartas del 2 al A
                for (int value = 2; value <= 14; value++)
                {
                    cards.Add(new Card(suit, value));  // Los valores 11, 12, 13 y 14 corresponden a J, Q, K y A
                }
            }
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(c => random.Next()).ToList();
        }

        // Robar la carta superior de la baraja
        public Card DrawCard()
        {
            if (cards.Count > 0)
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
            return null;
        }

        // Robar una carta al azar
        public Card DrawRandomCard()
        {
            if (cards.Count > 0)
            {
                int index = random.Next(cards.Count);
                Card card = cards[index];
                cards.RemoveAt(index);
                return card;
            }
            return null;
        }

        // Devolver el número de cartas restantes en la baraja
        public int RemainingCards()
        {
            return cards.Count;
        }
    }
}
