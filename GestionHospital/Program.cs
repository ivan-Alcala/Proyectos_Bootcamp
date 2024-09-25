using GestionHospital.Class;
using System;

namespace GestionHospital
{
    internal class Program
    {
        static Hospital _hospital = new Hospital();

        static void Main(string[] args)
        {
            // Agregar datos de prueba al inicio
            _hospital.AddTestData();

            bool exit = false;
            while (!exit)
            {
                ShowMenu();

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            AddDoctor();
                            break;
                        case 2:
                            AddPatient();
                            break;
                        case 3:
                            AddAdminStaff();
                            break;
                        case 4:
                            RemovePerson();
                            break;
                        case 5:
                            _hospital.ListPeople();
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                    Console.WriteLine("Por favor, ingrese un número válido.");
            }
        }

        // Método para mostrar el menú
        static void ShowMenu()
        {
            Console.Write(@"
Menu:
1. Dar de alta un médico
2. Dar de alta un paciente
3. Dar de alta personal administrativo
4. Eliminar a una persona
5. Listar personas
0. Salir
Seleccione una opción: ");
        }

        // Método genérico para preguntar y obtener un string válido
        static string AskString(string question)
        {
            string input;
            do
            {
                Console.Write(question);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        // Método genérico para preguntar y obtener un int válido
        static int AskInt(string question)
        {
            int result;
            do
            {
                Console.Write(question);
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result;
        }

        // Método genérico para preguntar y obtener un double válido
        static double AskDouble(string question)
        {
            double result;
            do
            {
                Console.Write(question);
            } while (!double.TryParse(Console.ReadLine(), out result));

            return result;
        }

        // Método genérico para preguntar y obtener una fecha válida
        static DateTime AskDate(string question)
        {
            DateTime result;
            do
            {
                Console.Write(question);
            } while (!DateTime.TryParse(Console.ReadLine(), out result));

            return result;
        }

        // Método para dar de alta un médico
        static void AddDoctor()
        {
            string doctorName = AskString("Nombre del médico: ");
            DateTime dateOfBirth = AskDate("Fecha de nacimiento (dd/MM/yyyy): ");
            double height = AskDouble("Altura (en metros): ");
            double weight = AskDouble("Peso (en kg): ");
            string specialty = AskString("Especialidad: ");
            int yearsOfExperience = AskInt("Años de experiencia: ");
            string consultationHours = AskString("Horario de consultas: ");

            _hospital.AddPerson(new Doctor(doctorName, specialty, dateOfBirth, height, weight, yearsOfExperience, consultationHours));
        }

        // Método para dar de alta un paciente
        static void AddPatient()
        {
            string patientName = AskString("Nombre del paciente: ");
            DateTime dateOfBirth = AskDate("Fecha de nacimiento (dd/MM/yyyy): ");
            double height = AskDouble("Altura (en metros): ");
            double weight = AskDouble("Peso (en kg): ");

            int doctorId = AskInt("ID del médico asignado: ");
            Doctor assignedDoctor = _hospital.GetDoctorById(doctorId);

            if (assignedDoctor != null)
            {
                string condition = AskString("Condición del paciente: ");
                DateTime admissionDate = AskDate("Fecha de admisión (dd/MM/yyyy): ");

                _hospital.AddPerson(new Patient(patientName, assignedDoctor, dateOfBirth, height, weight, condition, admissionDate));
            }
            else
            {
                Console.WriteLine("No se pudo asignar el médico. Intente nuevamente.");
            }
        }

        // Método para dar de alta personal administrativo
        static void AddAdminStaff()
        {
            string adminName = AskString("Nombre del personal administrativo: ");
            DateTime dateOfBirth = DateTime.Parse(AskString("Fecha de nacimiento (dd/MM/yyyy): "));
            double height = AskDouble("Altura (en metros): ");
            double weight = AskDouble("Peso (en kg): ");
            string position = AskString("Cargo: ");
            int yearsInService = AskInt("Años de servicio: ");
            string department = AskString("Departamento: ");

            _hospital.AddPerson(new AdminStaff(adminName, position, dateOfBirth, height, weight, yearsInService, department));
        }

        // Método para eliminar a una persona
        static void RemovePerson()
        {
            int idToRemove = AskInt("ID de la persona a eliminar: ");
            _hospital.RemovePerson(idToRemove);
        }
    }
}
