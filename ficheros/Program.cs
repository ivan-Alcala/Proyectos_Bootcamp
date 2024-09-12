namespace Ficheros
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        // Diccionario para almacenar los equipos
        static Dictionary<string, int> teams = new Dictionary<string, int>();
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

        static void AddOrModifyTeam(bool isModifying)
        {
            while (true)
            {
                if (isModifying)
                    Console.Write("Ingrese el nombre del equipo a modificar: ");
                else
                    Console.Write("Ingrese el nombre del equipo a agregar: ");

                string name = Console.ReadLine();

                if (isModifying && !teams.ContainsKey(name))
                    Console.WriteLine("El equipo no existe. Intente con otro nombre.");
                else if (!isModifying && teams.ContainsKey(name))
                    Console.WriteLine("El equipo ya existe. Intente con otro nombre.");
                else
                {
                    Console.Write("Ingrese la puntuación: ");

                    if (int.TryParse(Console.ReadLine(), out int score))
                    {
                        teams[name] = score;

                        if (isModifying)
                            Console.WriteLine("Puntuación modificada exitosamente.");
                        else
                            Console.WriteLine("Equipo agregado exitosamente.");

                        SaveData();
                        break; // Salir del bucle una vez que se haya agregado/modificado exitosamente
                    }
                    else
                        Console.WriteLine("Puntuación no válida.");
                }
            }
        }

        static void RemoveTeam()
        {
            while (true)
            {
                Console.Write("Ingrese el nombre del equipo a eliminar: ");
                string name = Console.ReadLine();

                if (teams.ContainsKey(name))
                {
                    teams.Remove(name);
                    Console.WriteLine("Equipo eliminado exitosamente.");
                    SaveData();
                    break; // Salir del bucle una vez que se haya eliminado exitosamente
                }
                else
                    Console.WriteLine("El equipo no existe. Intente con otro nombre.");
            }
        }

        static void ShowTeams()
        {
            Console.WriteLine("--- Lista de Equipos ---");

            if (teams.Count > 0)
            {
                foreach (var team in teams)
                    Console.WriteLine($"Equipo: {team.Key}, Puntuación: {team.Value}");
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
                        string[] data = line.Split(',');
                        if (data.Length == 2 && int.TryParse(data[1], out int score))
                        {
                            string name = data[0];
                            teams[name] = score;
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
                    foreach (var team in teams)
                        sw.WriteLine($"{team.Key},{team.Value}");
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
    }
}
