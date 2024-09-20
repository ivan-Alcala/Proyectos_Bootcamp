using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class Player
    {
        public string Name { get; private set; }
        public Queue<Card> Cards { get; private set; }
        public bool IsFolded { get; private set; }
        public bool IsHuman { get; private set; }
        private int chips;
        public bool HasBetThisRound { get; private set; } // Nueva propiedad

        public int Chips // Propiedad para acceder a las fichas del jugador
        {
            get { return chips; }
        }

        public Player(string name, bool isHuman = false)
        {
            Name = name;
            IsHuman = isHuman;
            Cards = new Queue<Card>();
            IsFolded = false;
            chips = 1000; // Fichas iniciales
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
                                       .GroupBy(item => item.Card.Suit)
                                       .OrderBy(group => group.Key)
                                       .ToList();

            Console.WriteLine($"{Name}'s cartas:");

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
                        Console.Write($"| [{item.Index + 1,2}] {item.Card.Value,2} de {item.Card.Suit,-7} ".PadRight(columnWidth));
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
            Console.WriteLine($"{Name} tiene {Cards.Count} cartas:");

            foreach (var card in Cards)
                Console.WriteLine(@"    "+card.ToString());
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

        // Métodos de apuesta
        public void Bet(int amount)
        {
            if (amount <= chips)
            {
                chips -= amount;
                HasBetThisRound = true; // Marcar que ha apostado
            }
            else
                Console.WriteLine("No tienes suficientes fichas.");
        }

        public void ResetBetFlag()
        {
            HasBetThisRound = false;
        }

        public void Fold()
        {
            IsFolded = true;
        }

        public void SetPlayerColor(int playerIndex)
        {
            switch (playerIndex)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green; // Jugador humano
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow; // Jugador 1
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan; // Jugador 2
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta; // Jugador 3
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red; // Jugador 4
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White; // Colores por defecto para otros jugadores
                    break;
            }
        }
    }
}
