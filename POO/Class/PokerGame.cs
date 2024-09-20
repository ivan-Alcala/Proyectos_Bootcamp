using System;
using System.Collections.Generic;
using System.Linq;

namespace POO.Class
{
    public class PokerGame
    {
        private List<Player> players;
        private Deck deck;
        private List<Card> communityCards;
        private int currentBet;
        private int pot;
        private int currentPlayerIndex;
        private int smallBlindIndex;
        private int bigBlindIndex;

        public PokerGame(int numberOfPlayers, bool includeHumanPlayer)
        {
            players = new List<Player>();
            deck = new Deck("Poker");
            deck.Shuffle();
            communityCards = new List<Card>();
            currentBet = 0;
            pot = 0;
            currentPlayerIndex = 0;
            smallBlindIndex = 0;
            bigBlindIndex = 1;

            // Crear jugadores
            for (int i = 1; i <= numberOfPlayers; i++)
                players.Add(i == 1 && includeHumanPlayer ? new Player($"Jugador Humano", true) : new Player($"Jugador {i}", false));

            RepartirCartas();
        }

        private void RepartirCartas()
        {
            foreach (var player in players)
            {
                player.ReceiveCard(deck.DrawCard());
                player.ReceiveCard(deck.DrawCard());
            }
        }

        public void PlayGame()
        {
            Console.ResetColor();
            RealizarPreflop();
            RealizarFlop();
            RealizarTurn();
            RealizarRiver();
            Console.ResetColor();
            RevealCards();
            DetermineWinner();
        }

        private void RealizarPreflop()
        {
            Console.WriteLine("\nPreflop:");
            RealizarApuesta(smallBlindIndex, 10);
            RealizarApuesta(bigBlindIndex, 20);
            currentBet = 20;
            BetRound();
        }

        private void RealizarFlop()
        {
            Console.WriteLine("\nFlop:");
            communityCards.AddRange(new[] { deck.DrawCard(), deck.DrawCard(), deck.DrawCard() });
            BetRound();
        }

        private void RealizarTurn()
        {
            Console.WriteLine("\nTurn:");
            communityCards.Add(deck.DrawCard());
            BetRound();
        }

        private void RealizarRiver()
        {
            Console.WriteLine("\nRiver:");
            communityCards.Add(deck.DrawCard());
            BetRound();
        }

        private void RealizarApuesta(int playerIndex, int amount)
        {
            players[playerIndex].Bet(amount);
            pot += amount;
        }

        public void BetRound()
        {
            int playerIndex = 0;
            bool roundActive = true;

            // Restablecer la bandera de apuesta para todos los jugadores al comienzo de cada ronda
            foreach (var player in players)
                player.ResetBetFlag();

            while (roundActive)
            {
                Player player = players[playerIndex];

                // Permitir que participen únicamente jugadores que no se hayan retirado
                if (!player.IsFolded)
                {
                    player.SetPlayerColor(playerIndex);
                    Console.WriteLine($"Turno del jugador {player.Name}:");

                    player.ShowCardSummary();
                    Console.WriteLine($"Cartas comunitarias: {string.Join(", ", communityCards)}");

                    if (player.IsHuman)
                        ProcesarApuestaHumano(player);
                    else
                        ProcesarApuestaIA(player);
                }

                playerIndex = (playerIndex + 1) % players.Count;

                // Comprueba si todos los jugadores activos han completado su turno
                roundActive = players.Any(p => !p.IsFolded && !p.HasBetThisRound);  // Mantener la ronda activa si queda algún jugador para apostar
            }

            ShowPot();
        }

        private void ProcesarApuestaHumano(Player player)
        {
            Console.WriteLine(@"
Opciones:
1. Pasar (Check)
2. Apostar (Bet)
3. Igualar (Call)
4. Subir (Raise)
5. Retirarse (Fold)");

            int choice = GetIntInput("Elige una opción (1-5): ", 1, 5);
            switch (choice)
            {
                case 1:
                    if (currentBet == 0) Console.WriteLine("Has pasado.");
                    else Console.WriteLine("No puedes pasar; necesitas igualar la apuesta.");
                    break;
                case 2:
                    Bet(player);
                    break;
                case 3:
                    Match(player);
                    break;
                case 4:
                    Raise(player);
                    break;
                case 5:
                    player.Fold();
                    break;
            }
        }

        private void ProcesarApuestaIA(Player player)
        {
            Random rand = new Random();
            int aiChoice = rand.Next(1, 6);
            switch (aiChoice)
            {
                case 1:
                    if (currentBet == 0) Console.WriteLine($"{player.Name} ha pasado (Check).");
                    else Console.WriteLine($"{player.Name} no puede pasar, necesita igualar la apuesta.");
                    break;
                case 2:
                    Bet(player, (int)(player.Chips * 0.2));
                    break;
                case 3:
                    Match(player);
                    break;
                case 4:
                    Raise(player, currentBet + (int)(player.Chips * 0.1));
                    break;
                case 5:
                    Console.WriteLine($"{player.Name} se ha retirado (Fold).");
                    player.Fold();
                    break;
            }
        }

        private void Bet(Player player, int? amount = null)
        {
            int betAmount = amount ?? GetIntInput("Introduce la cantidad de fichas a apostar: ", 1, player.Chips);
            player.Bet(betAmount);
            currentBet = betAmount;
            pot += betAmount;
        }

        private void Match(Player player)
        {
            Console.WriteLine($"{player.Name} ha igualado (Call) la apuesta de {currentBet} fichas.");
            player.Bet(currentBet);
            pot += currentBet;
        }

        private void Raise(Player player, int? amount = null)
        {
            int raiseAmount = amount ?? GetIntInput("Introduce la cantidad de fichas a subir: ", currentBet + 1, player.Chips);
            player.Bet(raiseAmount);
            currentBet = raiseAmount;
            pot += raiseAmount;
        }

        private void ShowPot()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"El pote actual es de {pot} fichas.");
            Console.ResetColor();
        }

        private void RevealCards()
        {
            Console.WriteLine("Cartas comunitarias:");
            foreach (var card in communityCards)
                Console.WriteLine(card);

            foreach (var player in players)
                player.ShowCardSummary();
        }

        private void DetermineWinner()
        {
            var hands = players.Where(p => !p.IsFolded).Select(p =>
            {
                var hand = p.Cards.Concat(communityCards).ToList();
                return new { Player = p, Hand = PokerHandEvaluator.EvaluateHand(hand) };
            }).ToList();

            if (!hands.Any())
            {
                Console.WriteLine("Todos los jugadores se han retirado. No hay ganador.");
                return;
            }

            var bestHand = hands.OrderByDescending(h => h.Hand).First();
            Console.WriteLine($"{bestHand.Player.Name} gana con {bestHand.Hand}!");
        }

        private int GetIntInput(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Entrada no válida. Por favor, introduce un número entre {min} y {max}.");
            }
        }
    }
}