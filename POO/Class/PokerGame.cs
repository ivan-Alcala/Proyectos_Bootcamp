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

            // Asignar ciegas
            smallBlindIndex = 0;
            bigBlindIndex = 1;

            // Crear jugadores
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                if (i == 1 && includeHumanPlayer)
                    players.Add(new Player($"Jugador Humano", isHuman: true));
                else
                    players.Add(new Player($"Jugador {i}", isHuman: false));
            }

            // Repartir cartas privadas a cada jugador
            foreach (var player in players)
            {
                player.ReceiveCard(deck.DrawCard());
                player.ReceiveCard(deck.DrawCard());
            }
        }

        public void PlayGame()
        {
            // Preflop (Small Blind, Big Blind)
            Console.ResetColor();
            Console.WriteLine("\nPreflop:");
            players[smallBlindIndex].Bet(10); // Small Blind apuesta 10
            pot += 10;
            players[bigBlindIndex].Bet(20); // Big Blind apuesta 20
            pot += 20;
            currentBet = 20; // La apuesta actual es igual a la Big Blind
            BetRound(); // Ronda de apuestas

            // Flop
            Console.ResetColor();
            Console.WriteLine("\nFlop:");
            communityCards.Add(deck.DrawCard());
            communityCards.Add(deck.DrawCard());
            communityCards.Add(deck.DrawCard());
            BetRound(); // Nueva ronda de apuestas

            // Turn
            Console.ResetColor();
            Console.WriteLine("\nTurn:");
            communityCards.Add(deck.DrawCard());
            BetRound(); // Nueva ronda de apuestas

            // River
            Console.ResetColor();
            Console.WriteLine("\nRiver:");
            communityCards.Add(deck.DrawCard());
            BetRound(); // Última ronda de apuestas

            // Revelación de cartas
            Console.ResetColor();
            RevealCards();
            DetermineWinner();
        }

        public void BetRound()
        {
            int playerIndex = 0;
            bool roundActive = true;

            while (roundActive)
            {
                Player player = players[playerIndex];
                player.SetPlayerColor(playerIndex); // Establecer el color según el jugador

                Console.WriteLine($"Turno del jugador {player.Name}:");

                // Mostrar las cartas del jugador
                player.ShowCardSummary();
                // Mostrar cartas comunitarias
                Console.WriteLine($"Cartas comunitarias: {string.Join(", ", communityCards)}");

                if (player.IsHuman) // Turno del jugador humano
                {
                    Console.WriteLine(@"
Opciones:
1. Pasar (Check)
2. Apostar (Bet)
3. Igualar (Call)
4. Subir (Raise)
5. Retirarse (Fold)");

                    int choice = GetIntInput("Elige una opción (1-5): ", 1, 5);
                    int betAmount = 0;
                    switch (choice)
                    {
                        case 1:
                            if (currentBet == 0)
                                Console.WriteLine("Has pasado.");
                            else
                                Console.WriteLine("No puedes pasar; necesitas igualar la apuesta.");
                            break;
                        case 2:
                            betAmount = GetIntInput("Introduce la cantidad de fichas a apostar: ", 1, player.Chips);
                            player.Bet(betAmount);
                            currentBet = betAmount;
                            pot += betAmount;
                            break;
                        case 3:
                            player.Bet(currentBet);
                            pot += currentBet;
                            break;
                        case 4:
                            betAmount = GetIntInput("Introduce la cantidad de fichas a subir: ", currentBet + 1, player.Chips);
                            player.Bet(betAmount);
                            currentBet = betAmount;
                            pot += betAmount;
                            break;
                        case 5:
                            player.Fold();
                            break;
                    }
                }
                else // Turno de la IA
                {
                    Random rand = new Random();
                    int aiChoice = rand.Next(1, 6); // Elige una opción aleatoria del menú
                    int aiBet = 0;
                    switch (aiChoice)
                    {
                        case 1:
                            if (currentBet == 0)
                                Console.WriteLine($"{player.Name} ha pasado (Check).");
                            else
                                Console.WriteLine($"{player.Name} no puede pasar, necesita igualar la apuesta.");
                            break;
                        case 2:
                            aiBet = (int)(player.Chips * 0.2); // La IA apuesta el 20% de sus fichas
                            Console.WriteLine($"{player.Name} ha apostado (Bet) {aiBet} fichas.");
                            player.Bet(aiBet);
                            currentBet = aiBet;
                            pot += aiBet;
                            break;
                        case 3:
                            Console.WriteLine($"{player.Name} ha igualado (Call) la apuesta de {currentBet} fichas.");
                            player.Bet(currentBet);
                            pot += currentBet;
                            break;
                        case 4:
                            aiBet = currentBet + (int)(player.Chips * 0.1); // Sube la apuesta en 10% de sus fichas
                            Console.WriteLine($"{player.Name} ha subido (Raise) la apuesta a {aiBet} fichas.");
                            player.Bet(aiBet);
                            currentBet = aiBet;
                            pot += aiBet;
                            break;
                        case 5:
                            Console.WriteLine($"{player.Name} se ha retirado (Fold).");
                            player.Fold();
                            break;
                    }
                }

                playerIndex = (playerIndex + 1) % players.Count;

                // Verificar si todos los jugadores han hecho su movimiento o se han retirado
                if (players.All(p => p.IsFolded || p.HasBetThisRound))
                    roundActive = false;

                // Reset color to default after the player's turn
                Console.ResetColor();
            }

            // Mostrar el pote después de la ronda de apuestas
            Console.ForegroundColor = ConsoleColor.Gray; // Texto por defecto (gris)
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
            // Obtener las manos de los jugadores que no se han retirado
            var hands = players.Where(p => !p.IsFolded).Select(p =>
            {
                var hand = p.Cards.Concat(communityCards).ToList();
                return new { Player = p, Hand = PokerHandEvaluator.EvaluateHand(hand) };
            }).ToList();

            // Verificar si hay al menos un jugador no retirado
            if (hands.Count == 0)
            {
                Console.WriteLine("Todos los jugadores se han retirado. No hay ganador.");
                return;
            }

            // Determinar la mejor mano
            var bestHand = hands.OrderByDescending(h => h.Hand).First();
            Console.WriteLine($"{bestHand.Player.Name} gana con {bestHand.Hand}!");
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