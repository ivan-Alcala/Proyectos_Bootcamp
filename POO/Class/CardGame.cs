using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class CardGame
    {
        private List<Player> players;
        private Deck deck;
        private int maxRounds;
        private Player humanPlayer;

        public CardGame(int numberOfPlayers, int maxRounds, bool includeHumanPlayer)
        {
            if (numberOfPlayers < 1 || numberOfPlayers > 5)
            {
                throw new ArgumentException("El número de jugadores debe estar entre 1 y 5.");
            }

            if (maxRounds <= 0)
            {
                throw new ArgumentException("El número máximo de rondas debe ser mayor que 0.");
            }

            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();

            this.maxRounds = maxRounds;

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                players.Add(new Player($"Jugador {i}"));
            }

            if (includeHumanPlayer)
            {
                humanPlayer = new Player("Jugador Humano");
                players.Add(humanPlayer);
            }

            DealCards();

            // Mostrar resumen de las cartas de cada jugador al principio
            Console.WriteLine("\nResumen de cartas de los jugadores al inicio del juego:");
            foreach (var player in players)
            {
                player.ShowCardSummary();
            }
        }

        // Repartir las cartas entre los jugadores
        private void DealCards()
        {
            int currentPlayer = 0;
            while (deck.RemainingCards() > 0)
            {
                players[currentPlayer].ReceiveCard(deck.DrawCard());
                currentPlayer = (currentPlayer + 1) % players.Count;
            }
        }

        // Lógica del juego
        public void PlayGame()
        {
            int roundsPlayed = 0;

            while (players.Count(p => !p.OutOfCards()) > 1 && roundsPlayed < maxRounds)
            {
                roundsPlayed++;
                List<Card> cardsInPlay = new List<Card>();
                Player roundWinner = null;
                Card winningCard = null;

                Console.WriteLine($"\nRonda {roundsPlayed}:");
                foreach (var player in players)
                {
                    if (!player.OutOfCards())
                    {
                        Card card;
                        if (player == humanPlayer)
                        {
                            card = GetHumanPlayerAction();
                        }
                        else
                        {
                            card = player.PlayCard();
                        }

                        if (card != null)
                        {
                            cardsInPlay.Add(card);
                            Console.WriteLine($"{player.Name} juega {card}");

                            if (winningCard == null || card.Value > winningCard.Value)
                            {
                                roundWinner = player;
                                winningCard = card;
                            }
                        }
                    }
                }

                // El ganador de la ronda se lleva todas las cartas jugadas
                if (roundWinner != null)
                {
                    Console.WriteLine($"{roundWinner.Name} gana la ronda");
                    roundWinner.WinHand(cardsInPlay);
                }

                // Eliminar jugadores sin cartas
                players = players.Where(p => !p.OutOfCards()).ToList();
            }

            // Mostrar resumen de las cartas de cada jugador al final
            Console.WriteLine("\nResumen de cartas de los jugadores al final del juego:");
            foreach (var player in players)
            {
                player.ShowCardSummary();
            }

            // Anunciar el ganador final
            if (players.Count == 1)
            {
                Console.WriteLine($"\n{players[0].Name} ha ganado el juego!");
            }
            else if (roundsPlayed >= maxRounds)
            {
                Console.WriteLine($"\nSe ha alcanzado el límite de rondas ({maxRounds}). El juego ha terminado.");
            }
            else
            {
                Console.WriteLine("\nNo hay más jugadores en juego.");
            }
        }

        private Card GetHumanPlayerAction()
        {
            while (true)
            {
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Jugar una carta");
                Console.WriteLine("2. Robar una carta aleatoria de la baraja");
                Console.WriteLine("3. Robar la carta superior de la baraja");
                Console.WriteLine("4. Robar una carta de una posición específica de la baraja");
                Console.WriteLine("5. Mostrar tu baraja");
                Console.Write("Elige una opción: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return PlayHumanCard();
                        case 2:
                            return DrawRandomCard();
                        case 3:
                            return DrawTopCard();
                        case 4:
                            return DrawSpecificCard();
                        case 5:
                            humanPlayer.ShowCards();
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intenta de nuevo.");
                }
            }
        }

        private Card PlayHumanCard()
        {
            humanPlayer.ShowCards();
            Console.Write("Elige el número de la carta que quieres jugar: ");
            if (int.TryParse(Console.ReadLine(), out int cardIndex) && cardIndex > 0 && cardIndex <= humanPlayer.Cards.Count)
            {
                return humanPlayer.PlaySpecificCard(cardIndex - 1);
            }
            Console.WriteLine("Selección no válida. Jugando la primera carta.");
            return humanPlayer.PlayCard();
        }

        private Card DrawRandomCard()
        {
            Card card = deck.DrawRandomCard();
            if (card != null)
            {
                humanPlayer.ReceiveCard(card);
                Console.WriteLine($"Has robado: {card}");
            }
            else
            {
                Console.WriteLine("No quedan cartas en la baraja.");
            }
            return null;
        }

        private Card DrawTopCard()
        {
            Card card = deck.DrawCard();
            if (card != null)
            {
                humanPlayer.ReceiveCard(card);
                Console.WriteLine($"Has robado: {card}");
            }
            else
            {
                Console.WriteLine("No quedan cartas en la baraja.");
            }
            return null;
        }

        private Card DrawSpecificCard()
        {
            Console.Write("Elige la posición de la carta que quieres robar: ");
            if (int.TryParse(Console.ReadLine(), out int position))
            {
                Card card = deck.DrawCardAtPosition(position - 1);
                if (card != null)
                {
                    humanPlayer.ReceiveCard(card);
                    Console.WriteLine($"Has robado: {card}");
                }
                else
                {
                    Console.WriteLine("Posición no válida o no quedan cartas en la baraja.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
            return null;
        }
    }
}