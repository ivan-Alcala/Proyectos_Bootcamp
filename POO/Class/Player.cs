using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class Player
    {
        public string Name { get; private set; }
        public Queue<Card> Cards { get; private set; }

        public Player(string name)
        {
            Name = name;
            Cards = new Queue<Card>();
        }

        // Recibir una carta
        public void ReceiveCard(Card card)
        {
            Cards.Enqueue(card);
        }

        // Jugar la carta superior del paquete
        public Card PlayCard()
        {
            return Cards.Count > 0 ? Cards.Dequeue() : null;
        }

        // Ganar una mano y añadir las cartas ganadas al final del paquete
        public void WinHand(List<Card> wonCards)
        {
            foreach (var card in wonCards)
            {
                Cards.Enqueue(card);
            }
        }

        // Verificar si el jugador se quedó sin cartas
        public bool OutOfCards()
        {
            return Cards.Count == 0;
        }

        // Mostrar todas las cartas del jugador de forma más legible
        public void ShowCards()
        {
            var groupedCards = Cards.GroupBy(card => card.Suit);

            Console.WriteLine($"{Name}'s cartas:");

            foreach (var group in groupedCards)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var card in group)
                {
                    Console.WriteLine($"  {card.Value}");
                }
            }

            Console.WriteLine(); // Espacio en blanco para separar la visualización
        }

        // Mostrar el resumen de las cartas del jugador
        public void ShowCardSummary()
        {
            var groupedCards = Cards.GroupBy(card => card.Suit);

            Console.WriteLine($"{Name} tiene {Cards.Count} cartas:");
            foreach (var group in groupedCards)
            {
                Console.WriteLine($"  {group.Key}: {group.Count()} cartas");
            }

            Console.WriteLine(); // Espacio en blanco para separar la visualización
        }

        public Card PlaySpecificCard(int index)
        {
            if (index >= 0 && index < Cards.Count)
            {
                Card card = Cards.ElementAt(index);
                Cards = new Queue<Card>(Cards.Where((c, i) => i != index));
                return card;
            }
            return null;
        }
    }
}
