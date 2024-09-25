using System;

namespace GestionHospital.Class
{
    public static class Tools
    {
        // Método genérico para preguntar y obtener una cadena válida
        public static string AskString(string question)
        {
            string result;
            do
            {
                Console.Write(question);
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));

            return result;
        }

        // Método genérico para preguntar y obtener un entero válido
        public static int AskInt(string question)
        {
            int result;
            do
            {
                Console.Write(question);
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result;
        }

        // Método genérico para preguntar y obtener un valor decimal válido
        public static double AskDouble(string question)
        {
            double result;
            do
            {
                Console.Write(question);
            } while (!double.TryParse(Console.ReadLine(), out result));

            return result;
        }

        // Método genérico para preguntar y obtener una fecha válida
        public static DateTime AskDate(string question)
        {
            DateTime result;
            do
            {
                Console.Write(question);
            } while (!DateTime.TryParse(Console.ReadLine(), out result));

            return result;
        }
    }
}
