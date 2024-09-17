using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class Deck
    {
        private List<Card> cards;
        private static Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));

            // Crear una baraja española de 40 cartas (sin 8 y 9)
            foreach (Suit suit in suits)
            {
                for (int value = 1; value <= 7; value++)
                {
                    cards.Add(new Card(suit, value));
                }
                for (int value = 10; value <= 12; value++)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        // Barajar las cartas
        public void Shuffle()
        {
            cards = cards.OrderBy(c => random.Next()).ToList();
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
    }
}
