using POO.Class;
using System;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de cartas!");

            bool includeHumanPlayer = GetYesNoInput("¿Quieres jugar? (S/N): ");
            int numberOfPlayers;

            if (includeHumanPlayer)
                numberOfPlayers = GetIntInput("Ingresa el número de jugadores IA (1-4): ", 1, 4);
            else
                numberOfPlayers = GetIntInput("Ingresa el número de jugadores (2-5): ", 2, 5);

            int maxRounds = GetIntInput("Ingresa el número máximo de rondas: ", 1, int.MaxValue);

            try
            {
                CardGame game = new CardGame(numberOfPlayers, maxRounds, includeHumanPlayer);
                game.PlayGame();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error al crear el juego: {e.Message}");
            }

            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }

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