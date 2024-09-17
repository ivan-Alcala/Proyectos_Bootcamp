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

        public CardGame(int numberOfPlayers, int maxRounds)
        {
            if (numberOfPlayers < 2 || numberOfPlayers > 5)
            {
                throw new ArgumentException("El número de jugadores debe estar entre 2 y 5.");
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

            DealCards();
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
                        Card card = player.PlayCard();
                        cardsInPlay.Add(card);
                        Console.WriteLine($"{player.Name} juega {card}");

                        if (winningCard == null || card.Value > winningCard.Value)
                        {
                            roundWinner = player;
                            winningCard = card;
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
    }
}
