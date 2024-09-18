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
                Cards.Enqueue(card);
        }

        // Verificar si el jugador se quedó sin cartas
        public bool OutOfCards()
        {
            return Cards.Count == 0;
        }

        // Mostrar todas las cartas del jugador de forma más legible y visualmente atractiva, incluyendo la posición de cada carta
        public void ShowCards()
        {
            var cardList = Cards.ToList(); // Convertimos la Queue a List para acceder por índice
            var groupedCards = cardList.Select((card, index) => new { Card = card, Index = index })
                                       .GroupBy(item => item.Card.eSuit)
                                       .OrderBy(group => group.Key)
                                       .ToList();

            Console.WriteLine($"\n{Name}'s cartas:");

            const int maxCardsPerColumn = 10;
            const int columnWidth = 25;

            // Imprimir encabezados de columnas
            foreach (var group in groupedCards)
                Console.Write($"| {group.Key,-15} ".PadRight(columnWidth));
            Console.WriteLine("|");

            string horizontalLine = new string('-', columnWidth * groupedCards.Count + 1);
            Console.WriteLine(horizontalLine);

            for (int i = 0; i < maxCardsPerColumn; i++)
            {
                bool printedAnyCard = false;
                foreach (var group in groupedCards)
                {
                    if (i < group.Count())
                    {
                        var item = group.ElementAt(i);
                        Console.Write($"| [{item.Index + 1,2}] {item.Card.Value,2} de {item.Card.eSuit,-7} ".PadRight(columnWidth));
                        printedAnyCard = true;
                    }
                    else
                        Console.Write("| ".PadRight(columnWidth));
                }
                if (printedAnyCard)
                    Console.WriteLine("|");
            }

            Console.WriteLine(horizontalLine);
            Console.WriteLine($"Total de cartas: {Cards.Count}");
        }

        // Mostrar el resumen de las cartas del jugador
        public void ShowCardSummary()
        {
            var groupedCards = Cards.GroupBy(card => card.eSuit);
            Console.WriteLine($"{Name} tiene {Cards.Count} cartas:");

            foreach (var group in groupedCards.OrderBy(g => g.Key))
                Console.WriteLine($"  {group.Key}: {group.Count()} cartas");

            Console.WriteLine(); // Espacio en blanco para separar la visualización
        }

        // Jugar una carta específica
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

        // Remover una carta extra
        public void RemoveExtraCard()
        {
            if (Cards.Count > 0)
                Cards.Dequeue();
        }
    }
}
