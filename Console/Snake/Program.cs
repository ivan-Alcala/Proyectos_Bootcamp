namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    class Program
    {
        static int gridSize = 20; // Tamaño de la cuadrícula NxN
        static int snakeX, snakeY; // Coordenadas de la cabeza de la serpiente
        static char[,] grid;       // Representación de la cuadrícula
        static bool isGameOver = false;
        static Queue<(int, int)> snakeBody = new Queue<(int, int)>(); // Cuerpo de la serpiente
        static int snakeLength = 3; // Longitud inicial de la serpiente
        static (int, int) direction = (0, 1); // Dirección inicial (derecha)
        static Random rand = new Random();
        static int score = 0; // Puntuación inicial

        // Puntos de energía (true: letal, false: crecimiento)
        static List<(int, int, bool)> energyPoints = new List<(int, int, bool)>();

        static void Main()
        {
            grid = new char[gridSize, gridSize];
            snakeX = gridSize / 2;
            snakeY = gridSize / 2;

            // Inicializa el cuerpo de la serpiente
            for (int i = 0; i < snakeLength; i++)
                snakeBody.Enqueue((snakeX, snakeY - i));

            // Genera 5 puntos de energía, algunos letales
            for (int i = 0; i < 5; i++)
                GenerateSingleEnergyPoint(true);

            // Movimiento automático de la serpiente
            Timer timer = new Timer(MoveSnake, null, 0, 200); // Mueve cada 200ms

            while (!isGameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ChangeDirection(keyInfo.Key);
                }

                Thread.Sleep(100); // Espera entre actualizaciones
            }

            Console.WriteLine($"¡Juego Terminado! Puntuación final: {score}");
            Console.ReadLine();
        }

        static void GenerateSingleEnergyPoint(bool allowLethal = false)
        {
            int x, y;
            bool isLethal = allowLethal && rand.Next(0, 5) == 0; // 20% probabilidad de ser letal si se permite

            do
            {
                x = rand.Next(0, gridSize);
                y = rand.Next(0, gridSize);
            } while (snakeBody.Contains((x, y)) || energyPoints.Any(ep => ep.Item1 == x && ep.Item2 == y));

            energyPoints.Add((x, y, isLethal));
        }

        static void InitGrid()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                    grid[i, j] = ' ';
            }

            // Dibuja la serpiente
            foreach (var (x, y) in snakeBody)
                grid[x, y] = 'O';

            // Dibuja los puntos de energía
            foreach (var (x, y, isLethal) in energyPoints)
                grid[x, y] = isLethal ? 'X' : '*'; // Letal: 'X', Crecimiento: '*'
        }

        static void DrawGrid()
        {
            Console.Clear();
            Console.WriteLine($"Puntuación: {score}"); // Muestra la puntuación

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                    Console.Write($"|{grid[i, j]}");

                Console.WriteLine("|");
            }
        }

        static void MoveSnake(object state)
        {
            int newX = snakeX + direction.Item1;
            int newY = snakeY + direction.Item2;

            // Verifica si la nueva posición está dentro de los límites
            if (newX < 0 || newX >= gridSize || newY < 0 || newY >= gridSize || snakeBody.Contains((newX, newY)))
            {
                isGameOver = true;
                return;
            }

            // Verifica si la serpiente pasa por encima de un punto de energía
            for (int i = 0; i < energyPoints.Count; i++)
            {
                var (ex, ey, isLethal) = energyPoints[i];
                if (newX == ex && newY == ey)
                {
                    if (isLethal)
                    {
                        isGameOver = true;
                        return; // Punto letal, termina el juego
                    }
                    else
                    {
                        snakeLength++; // Incrementa la longitud
                        score++; // Aumenta la puntuación
                        energyPoints.RemoveAt(i); // Elimina el punto de energía

                        // Genera un nuevo punto de energía si no hay puntos de crecimiento
                        if (!energyPoints.Any(ep => !ep.Item3))
                            GenerateSingleEnergyPoint(false); // Genera un punto benigno

                        break;
                    }
                }
            }

            // Mueve la serpiente
            snakeBody.Enqueue((newX, newY));
            snakeX = newX;
            snakeY = newY;

            // Si la longitud de la serpiente es mayor, elimina la parte trasera
            while (snakeBody.Count > snakeLength)
                snakeBody.Dequeue();

            // Actualiza la cuadrícula y la dibuja
            InitGrid();
            DrawGrid();
        }

        static void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (direction != (1, 0))
                        direction = (-1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != (-1, 0))
                        direction = (1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != (0, 1))
                        direction = (0, -1);
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != (0, -1))
                        direction = (0, 1);
                    break;
            }
        }
    }
}