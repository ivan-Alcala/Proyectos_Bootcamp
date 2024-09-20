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

            // Selecciona el juego basado en la elección del usuario
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
            // Pregunta si el jugador humano desea participar
            bool includeHumanPlayer = GetYesNoInput("¿Quieres jugar? (S/N): ");

            // Determina el número de jugadores con o sin el jugador humano
            int numberOfPlayers = includeHumanPlayer ? GetIntInput("Ingresa el número de jugadores IA (1-4): ", 1, 4)
                                                     : GetIntInput("Ingresa el número de jugadores (2-5): ", 2, 5);

            // Define el número máximo de rondas
            int maxRounds = GetIntInput("Ingresa el número máximo de rondas: ", 1, int.MaxValue);

            try
            {
                // Inicializa el juego de cartas españolas
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
            // Pregunta si el jugador humano desea participar
            bool includeHumanPlayer = GetYesNoInput("¿Quieres jugar? (S/N): ");

            // Determina el número de jugadores con o sin el jugador humano
            int numberOfPlayers = includeHumanPlayer ? GetIntInput("Ingresa el número de jugadores IA (1-4): ", 1, 4)
                                                     : GetIntInput("Ingresa el número de jugadores (2-5): ", 2, 5);

            try
            {
                // Inicializa el juego de póker
                PokerGame game = new PokerGame(numberOfPlayers, includeHumanPlayer);
                game.PlayGame();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error al crear el juego: {e.Message}");
            }
        }

        // Función para recibir un input de sí/no por parte del usuario
        static bool GetYesNoInput(string prompt)
        {
            // Solicita repetidamente al usuario una respuesta válida de sí o no
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

        // Función para obtener un input numérico del usuario
        static int GetIntInput(string prompt, int min, int max)
        {
            // Solicita un número dentro de un rango específico
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