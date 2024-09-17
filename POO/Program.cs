using POO.Class;
using System;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de cartas!");
            Console.Write("Ingresa el número de jugadores (2-5): ");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            Console.Write("Ingresa el número máximo de rondas: ");
            int maxRounds = int.Parse(Console.ReadLine());

            CardGame game = new CardGame(numberOfPlayers, maxRounds);
            game.PlayGame();
            Console.ReadLine();
        }
    }
}
