using POO.Class;
using System;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de cartas!");

            // Selección del juego
            Console.WriteLine("Selecciona el juego:");
            Console.WriteLine("1. Cartas Españolas");
            Console.WriteLine("2. Póker");
            int gameChoice = GetIntInput("Opción: ", 1, 2);

            if (gameChoice == 1)
                PlaySpanishCardsGame();
            else if (gameChoice == 2)
                PlayPokerGame();

            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }

        // Función para jugar cartas españolas
        static void PlaySpanishCardsGame()
        {
            bool includeHumanPlayer = GetYesNoInput("¿Quieres jugar? (S/N): ");
            int numberOfPlayers = includeHumanPlayer ? GetIntInput("Ingresa el número de jugadores IA (1-4): ", 1, 4)
                                                     : GetIntInput("Ingresa el número de jugadores (2-5): ", 2, 5);

            int maxRounds = GetIntInput("Ingresa el número máximo de rondas: ", 1, int.MaxValue);

            try
            {
                CardGame game = new CardGame(numberOfPlayers, maxRounds, includeHumanPlayer, "Spanish");
                game.PlayGame();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error al crear el juego: {e.Message}");
            }
        }

        // Función para jugar póker
        static void PlayPokerGame()
        {
            bool includeHumanPlayer = GetYesNoInput("¿Quieres jugar? (S/N): ");
            int numberOfPlayers = includeHumanPlayer ? GetIntInput("Ingresa el número de jugadores IA (1-4): ", 1, 4)
                                                     : GetIntInput("Ingresa el número de jugadores (2-5): ", 2, 5);

            try
            {
                PokerGame game = new PokerGame(numberOfPlayers, includeHumanPlayer);
                game.PlayGame();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error al crear el juego: {e.Message}");
            }
        }

        // Función de entrada boolean
        static bool GetYesNoInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "S")
                    return true;
                if (input == "N")
                    return false;

                Console.WriteLine("Entrada no válida. Por favor, introduce S o N.");
            }
        }

        // Función de entrada numérica
        static int GetIntInput(string prompt, int min, int max)
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
