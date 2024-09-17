using POO.Class;
using System;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de cartas!");
            Console.Write("¿Quieres jugar? (S/N): ");
            bool includeHumanPlayer = Console.ReadLine().Trim().ToUpper() == "S";

            int numberOfPlayers;
            if (includeHumanPlayer)
            {
                Console.Write("Ingresa el número de jugadores AI (1-4): ");
                numberOfPlayers = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Ingresa el número de jugadores (2-5): ");
                numberOfPlayers = int.Parse(Console.ReadLine());
            }

            Console.Write("Ingresa el número máximo de rondas: ");
            int maxRounds = int.Parse(Console.ReadLine());

            CardGame game = new CardGame(numberOfPlayers, maxRounds, includeHumanPlayer);
            game.PlayGame();
            Console.ReadLine();
        }

    }
}
