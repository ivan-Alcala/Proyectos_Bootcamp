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

        // Método para dar de alta un médico
        static void AddDoctor()
        {
            Console.Write("Nombre del médico: ");
            string doctorName = Console.ReadLine();
            Console.Write("Especialidad: ");
            string specialty = Console.ReadLine();
            _hospital.AddPerson(new Doctor(doctorName, specialty));
        }

        // Método para dar de alta un paciente
        static void AddPatient()
        {
            Console.Write("Nombre del paciente: ");
            string patientName = Console.ReadLine();
            Console.Write("ID del médico asignado: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Doctor assignedDoctor = _hospital.GetDoctorById(doctorId);

                if (assignedDoctor != null)
                    _hospital.AddPerson(new Patient(patientName, assignedDoctor));
                else
                    Console.WriteLine("No se pudo asignar el médico. Intente nuevamente.");
            }
            else
                Console.WriteLine("ID inválido. Intente de nuevo.");
        }

        // Método para dar de alta personal administrativo
        static void AddAdminStaff()
        {
            Console.Write("Nombre del personal administrativo: ");
            string adminName = Console.ReadLine();
            Console.Write("Cargo: ");
            string position = Console.ReadLine();
            _hospital.AddPerson(new AdminStaff(adminName, position));
        }

        // Método para eliminar a una persona
        static void RemovePerson()
        {
            Console.Write("ID de la persona a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int idToRemove))
                _hospital.RemovePerson(idToRemove);
            else
                Console.WriteLine("ID inválido. Intente de nuevo.");
        }
    }
}