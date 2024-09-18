using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class CardGame
    {
        List<Player> players;
        Deck deck;
        int maxRounds;
        Player humanPlayer;

        public CardGame(int numberOfPlayers, int maxRounds, bool includeHumanPlayer)
        {
            int totalPlayers = includeHumanPlayer ? numberOfPlayers + 1 : numberOfPlayers;

            if ((includeHumanPlayer && (numberOfPlayers < 1 || numberOfPlayers > 4)) ||
                (!includeHumanPlayer && (numberOfPlayers < 2 || numberOfPlayers > 5)))
                throw new ArgumentException("Número de jugadores no válido.");

            if (maxRounds <= 0)
                throw new ArgumentException("El número máximo de rondas debe ser mayor que 0.");

            players = new List<Player>();
            deck = new Deck();
            deck.Shuffle();

            this.maxRounds = maxRounds;

            for (int i = 1; i <= numberOfPlayers; i++)
                players.Add(new Player($"Jugador {i}"));

            if (includeHumanPlayer)
            {
                humanPlayer = new Player("Jugador Humano");
                players.Add(humanPlayer);
            }

            DealCards();

            // Mostrar resumen de las cartas de cada jugador al principio
            Console.WriteLine("\nResumen de cartas de los jugadores al inicio del juego:");
            foreach (var player in players)
                player.ShowCardSummary();
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

            // Equilibrar el número de cartas entre los jugadores
            BalanceCards();
        }

        // Equilibrar el número de cartas entre los jugadores
        private void BalanceCards()
        {
            int minCards = players.Min(p => p.Cards.Count);

            foreach (var player in players)
            {
                while (player.Cards.Count > minCards)
                    player.RemoveExtraCard();
            }

            Console.WriteLine("Se han equilibrado las cartas entre los jugadores.");
        }

        // Lógica del juego
        public void PlayGame()
        {
            int roundsPlayed = 0;

            while (players.Count(p => !p.OutOfCards()) > 1 && roundsPlayed < maxRounds)
            {
                roundsPlayed++;
                Console.WriteLine($"\nRonda {roundsPlayed}:");

                PlayRound();
            }

            // Mostrar resumen de las cartas de cada jugador al final
            Console.WriteLine("\nResumen de cartas de los jugadores al final del juego:");
            foreach (var player in players)
                player.ShowCardSummary();

            // Anunciar el ganador final
            if (players.Count == 1)
                Console.WriteLine($"\n{players[0].Name} ha ganado el juego!");
            else if (roundsPlayed >= maxRounds)
                Console.WriteLine($"\nSe ha alcanzado el límite de rondas ({maxRounds}). El juego ha terminado.");
            else
                Console.WriteLine("\nNo hay más jugadores en juego.");
        }

        private void PlayRound()
        {
            List<Card> cardsInPlay = new List<Card>();
            Dictionary<Player, Card> playerCards = new Dictionary<Player, Card>();

            foreach (var player in players.Where(p => !p.OutOfCards()))
            {
                Card card = (player == humanPlayer) ? GetHumanPlayerAction() : player.PlayCard();
                if (card != null)
                {
                    cardsInPlay.Add(card);
                    playerCards[player] = card;
                    Console.WriteLine($"{player.Name} juega {card}");
                }
            }

            if (cardsInPlay.Count == 0) return;

            int highestValue = cardsInPlay.Max(c => c.Value);
            var winnersAndCards = playerCards.Where(pc => pc.Value.Value == highestValue).ToList();

            if (winnersAndCards.Count == 1)
            {
                // Un solo ganador
                var winner = winnersAndCards[0].Key;
                Console.WriteLine($"{winner.Name} gana la ronda");
                winner.WinHand(cardsInPlay);
            }
            else
            {
                // Empate, iniciar desempate
                ResolveWinner(winnersAndCards, cardsInPlay);
            }

            // Eliminar jugadores sin cartas
            players = players.Where(p => !p.OutOfCards()).ToList();
        }

        private void ResolveWinner(List<KeyValuePair<Player, Card>> tiedPlayers, List<Card> cardsInPlay)
        {
            Console.WriteLine("Empate detectado. Iniciando ronda de desempate.");
            List<Card> tiebreakCards = new List<Card>();

            while (true)
            {
                Dictionary<Player, Card> tiebreakPlayerCards = new Dictionary<Player, Card>();

                foreach (var playerCard in tiedPlayers)
                {
                    var player = playerCard.Key;
                    Card card = (player == humanPlayer) ? GetHumanPlayerAction() : player.PlayCard();
                    if (card != null)
                    {
                        tiebreakCards.Add(card);
                        tiebreakPlayerCards[player] = card;
                        Console.WriteLine($"{player.Name} juega {card} para el desempate");
                    }
                }

                if (tiebreakPlayerCards.Count == 0) break;

                int highestTiebreakValue = tiebreakPlayerCards.Values.Max(c => c.Value);
                var tiebreakWinnersAndCards = tiebreakPlayerCards.Where(pc => pc.Value.Value == highestTiebreakValue).ToList();

                if (tiebreakWinnersAndCards.Count == 1)
                {
                    // Ganador del desempate
                    var winner = tiebreakWinnersAndCards[0].Key;
                    Console.WriteLine($"{winner.Name} gana el desempate");
                    cardsInPlay.AddRange(tiebreakCards);
                    winner.WinHand(cardsInPlay);
                    return;
                }
                else
                {
                    Console.WriteLine("Continúa el desempate.");
                    tiedPlayers = tiebreakWinnersAndCards;
                }
            }
        }

        private Card GetHumanPlayerAction()
        {
            while (true)
            {
                Console.WriteLine(@"
Opciones:
1. Jugar una carta
2. Robar una carta aleatoria de la baraja
3. Robar la carta superior de la baraja
4. Robar una carta de una posición específica de la baraja
5. Mostrar tu baraja");

                int choice = GetIntInput("Elige una opción: ", 1, 5);

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
                }
            }
        }

        private Card PlayHumanCard()
        {
            humanPlayer.ShowCards();
            int cardIndex = GetIntInput("Elige el número de la carta que quieres jugar: ", 1, humanPlayer.Cards.Count) - 1;
            return humanPlayer.PlaySpecificCard(cardIndex);
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
                Console.WriteLine("No quedan cartas en la baraja.");

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
                Console.WriteLine("No quedan cartas en la baraja.");

            return null;
        }

        private Card DrawSpecificCard()
        {
            int position = GetIntInput("Elige la posición de la carta que quieres robar: ", 1, deck.RemainingCards());
            Card card = deck.DrawCardAtPosition(position - 1);

            if (card != null)
            {
                humanPlayer.ReceiveCard(card);
                Console.WriteLine($"Has robado: {card}");
            }
            else
                Console.WriteLine("No se pudo robar la carta de esa posición.");

            return null;
        }

        private int GetIntInput(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= min && result <= max)
                        return result;
                }

                Console.WriteLine($"Entrada no válida. Por favor, introduce un número entre {min} y {max}.");
            }
        }
    }
}