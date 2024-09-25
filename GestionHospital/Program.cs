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
                        case 6:
                            ModifyPerson();
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
6. Modificar persona
0. Salir
Seleccione una opción: ");
        }

        // Método para dar de alta un médico
        static void AddDoctor()
        {
            string doctorName = Tools.AskString("Nombre del médico: ");
            DateTime dateOfBirth = Tools.AskDate("Fecha de nacimiento (dd/MM/yyyy): ");
            double height = Tools.AskDouble("Altura (en metros): ");
            double weight = Tools.AskDouble("Peso (en kg): ");
            string specialty = Tools.AskString("Especialidad: ");
            int yearsOfExperience = Tools.AskInt("Años de experiencia: ");
            string consultationHours = Tools.AskString("Horario de consultas: ");

            _hospital.AddPerson(new Doctor(doctorName, specialty, dateOfBirth, height, weight, yearsOfExperience, consultationHours));
        }

        // Método para dar de alta un paciente
        static void AddPatient()
        {
            string patientName = Tools.AskString("Nombre del paciente: ");
            DateTime dateOfBirth = Tools.AskDate("Fecha de nacimiento (dd/MM/yyyy): ");
            double height = Tools.AskDouble("Altura (en metros): ");
            double weight = Tools.AskDouble("Peso (en kg): ");

            int doctorId = Tools.AskInt("ID del médico asignado: ");
            Doctor assignedDoctor = _hospital.GetDoctorById(doctorId);

            if (assignedDoctor != null)
            {
                string condition = Tools.AskString("Condición del paciente: ");
                DateTime admissionDate = Tools.AskDate("Fecha de admisión (dd/MM/yyyy): ");

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
            string adminName = Tools.AskString("Nombre del personal administrativo: ");
            DateTime dateOfBirth = DateTime.Parse(Tools.AskString("Fecha de nacimiento (dd/MM/yyyy): "));
            double height = Tools.AskDouble("Altura (en metros): ");
            double weight = Tools.AskDouble("Peso (en kg): ");
            string position = Tools.AskString("Cargo: ");
            int yearsInService = Tools.AskInt("Años de servicio: ");
            string department = Tools.AskString("Departamento: ");

            _hospital.AddPerson(new AdminStaff(adminName, position, dateOfBirth, height, weight, yearsInService, department));
        }

        // Método para eliminar a una persona
        static void RemovePerson()
        {
            int idToRemove = Tools.AskInt("ID de la persona a eliminar: ");
            _hospital.RemovePerson(idToRemove);
        }

        // Método para modificar una persona
        static void ModifyPerson()
        {
            int personId = Tools.AskInt("ID de la persona a modificar: ");
            _hospital.ModifyPerson(personId);
        }
    }
}
