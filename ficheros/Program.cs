namespace Ficheros
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        // Clase para almacenar los detalles del equipo
        class Team
        {
            public int Score { get; set; }
            public List<string> Players { get; set; } = new List<string>();
        }

        // Diccionario para almacenar los equipos
        static Dictionary<string, Team> _teams = new Dictionary<string, Team>();
        static string file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\equipos.txt";

        static void Main()
        {
            // Cargar datos de archivo al inicio
            LoadData();

            int option = -1; // Iniciar con un valor que no es válido

            while (option != 0)
            {
                Console.Write(@"
--- Sistema de Gestión de Equipos ---
1. Dar de alta equipo
2. Dar de baja equipo
3. Modificar puntuación de equipo
4. Mostrar equipos
0. Salir
Seleccione una opción: ");

                string input = Console.ReadLine();
                Console.Clear();

                // Validar si el input es un número
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            AddOrModifyTeam(false); // Dar de alta (false = add | true = modify)
                            break;
                        case 2:
                            RemoveTeam(); // Dar de baja
                            break;
                        case 3:
                            AddOrModifyTeam(true); // Añadir|Modificar equipo (false = add | true = modify)
                            break;
                        case 4:
                            ShowTeams(); // Mostrar equipos
                            break;
                        case 0:
                            SaveData(); // Guardar al salir
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Introduzca un número.");
                    option = -1; // Volver a solicitar una opción sin salir del bucle
                }
            }
        }

        // Método unificado para agregar o modificar un equipo
        static void AddOrModifyTeam(bool isModifying)
        {
            while (true)
            {
                if (isModifying)
                    Console.Write("Ingrese el nombre del equipo a modificar: ");
                else
                    Console.Write("Ingrese el nombre del equipo a agregar: ");

                string name = Console.ReadLine();

                if (isModifying && !_teams.ContainsKey(name))
                    Console.WriteLine("El equipo no existe. Intente con otro nombre.");
                else if (!isModifying && _teams.ContainsKey(name))
                    Console.WriteLine("El equipo ya existe. Intente con otro nombre.");
                else
                {
                    Console.Write("Ingrese la puntuación: ");

                    if (int.TryParse(Console.ReadLine(), out int score))
                    {
                        if (!_teams.ContainsKey(name))
                            _teams[name] = new Team(); // Crear nuevo equipo si no existe

                        _teams[name].Score = score;
                        UpdateTeamMembers(name); // Actualiza los jugadores

                        Console.WriteLine(isModifying ? "Puntuación modificada exitosamente." : "Equipo agregado exitosamente.");
                        SaveData();
                        break; // Salir del bucle una vez que se haya agregado/modificado exitosamente
                    }
                    else
                        Console.WriteLine("Puntuación no válida.");
                }
            }
        }

        private static void UpdateTeamMembers(string nameTeam)
        {
            string playersInput = ReadConsoleWord("Ingrese los nombres de los jugadores, separados por comas (si el jugador ya existe será eliminado del equipo):");
            List<string> players = new List<string>(playersInput.Split(','));

            foreach (string player in players)
            {
                if (_teams[nameTeam].Players.Contains(player))
                    _teams[nameTeam].Players.Remove(player); // Si el jugador ya está, lo eliminamos
                else
                    _teams[nameTeam].Players.Add(player); // Si no está, lo añadimos
            }
        }

        static void RemoveTeam()
        {
            while (true)
            {
                Console.Write("Ingrese el nombre del equipo a eliminar: ");
                string name = Console.ReadLine();

                if (_teams.ContainsKey(name))
                {
                    _teams.Remove(name);
                    Console.WriteLine($"Equipo '{name}' eliminado exitosamente.");
                    SaveData();
                    break;
                }
                else
                    Console.WriteLine("El equipo no existe. Intente con otro nombre.");
            }
        }

        static void ShowTeams()
        {
            Console.WriteLine("--- Lista de Equipos ---");

            if (_teams.Count > 0)
            {
                foreach (var team in _teams)
                {
                    Console.WriteLine($"Equipo: {team.Key}, Puntuación: {team.Value.Score}");
                    Console.WriteLine("Jugadores:");

                    foreach (var player in team.Value.Players)
                        Console.WriteLine($"- {player.Trim()}");

                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("No hay equipos registrados.");
        }

        static void LoadData()
        {
            try
            {
                if (!File.Exists(file))
                    return;

                using (StreamReader sr = new StreamReader(file))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(';'); // Cambiado para manejar jugadores

                        if (data.Length >= 2 && int.TryParse(data[1], out int score))
                        {
                            string name = data[0];
                            List<string> players = data.Length > 2 ? new List<string>(data[2].Split(',')) : new List<string>(); // Validar si hay jugadores

                            _teams[name] = new Team
                            {
                                Score = score,
                                Players = players
                            };
                        }
                        else
                            Console.WriteLine("Línea con formato incorrecto en el archivo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
        }

        static void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (var team in _teams)
                    {
                        string players = string.Join(",", team.Value.Players); // Guardar los jugadores
                        sw.WriteLine($"{team.Key};{team.Value.Score};{players}");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No tiene permiso para escribir en el archivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
            }
        }

        private static string ReadConsoleWord(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
    }
}
