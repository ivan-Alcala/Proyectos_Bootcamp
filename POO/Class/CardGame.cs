using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class CardGame
    {
        private List<Player> players;
        private Deck deck;

        public CardGame(int numberOfPlayers)
        {
            if (numberOfPlayers < 2 || numberOfPlayers > 5)
            {
                throw new ArgumentException("El número de jugadores debe estar entre 2 y 5.");
            }

            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();

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
            // TODO
        }
    }
}
