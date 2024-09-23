using Hospital.Class;
using System;
using System.Collections.Generic;

namespace Hospital
{
    internal class Program
    {
        // Listas para almacenar las personas del hospital
        static List<Doctor> doctors = new List<Doctor>();
        static List<Patient> patients = new List<Patient>();
        static List<AdminStaff> adminStaffs = new List<AdminStaff>();

        static void Main(string[] args)
        {
            // Inicializar datos de ejemplo
            InitializeSampleData();

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                Console.Write("Seleccione una opción: ");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        AddDoctor();
                        break;
                    case "2":
                        AddPatient();
                        break;
                    case "3":
                        AddAdminStaff();
                        break;
                    case "4":
                        ListDoctors();
                        break;
                    case "5":
                        ListPatientsOfDoctor();
                        break;
                    case "6":
                        RemovePatient();
                        break;
                    case "7":
                        ViewPeopleList();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Saliendo de la aplicación. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // Método para inicializar datos de ejemplo
        static void InitializeSampleData()
        {
            // Crear médicos de ejemplo
            Doctor doctor1 = new Doctor("Dr. Juan Pérez", "Cardiología");
            Doctor doctor2 = new Doctor("Dra. María López", "Neurología");
            Doctor doctor3 = new Doctor("Dr. Carlos García", "Pediatría");

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);

            // Crear pacientes de ejemplo y asignarlos a médicos
            Patient patient1 = new Patient("Ana Torres", doctor1.Id);
            Patient patient2 = new Patient("Luis Fernández", doctor2.Id);
            Patient patient3 = new Patient("Sofía Martínez", doctor1.Id);
            Patient patient4 = new Patient("Pedro Sánchez", doctor3.Id);

            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);
            patients.Add(patient4);

            // Asignar pacientes a los médicos correspondientes
            doctor1.Patients.Add(patient1);
            doctor1.Patients.Add(patient3);
            doctor2.Patients.Add(patient2);
            doctor3.Patients.Add(patient4);

            // Crear personal administrativo de ejemplo
            AdminStaff admin1 = new AdminStaff("Laura Gómez", "Administración");
            AdminStaff admin2 = new AdminStaff("Miguel Rodríguez", "Recursos Humanos");
            AdminStaff admin3 = new AdminStaff("Elena Díaz", "Finanzas");

            adminStaffs.Add(admin1);
            adminStaffs.Add(admin2);
            adminStaffs.Add(admin3);
        }

        // Método para mostrar el menú de opciones
        static void ShowMenu()
        {
            Console.WriteLine("=== Gestión de un Hospital ===");
            Console.WriteLine("1. Dar de alta un médico");
            Console.WriteLine("2. Dar de alta un paciente");
            Console.WriteLine("3. Dar de alta personal administrativo");
            Console.WriteLine("4. Listar los médicos");
            Console.WriteLine("5. Listar los pacientes de un médico");
            Console.WriteLine("6. Eliminar a un paciente");
            Console.WriteLine("7. Ver la lista de personas del hospital");
            Console.WriteLine("8. Salir");
            Console.WriteLine("==============================");
        }

        // Método para dar de alta un médico
        static void AddDoctor()
        {
            Console.WriteLine("=== Dar de Alta un Médico ===");
            try
            {
                string name = ReadNonEmptyString("Nombre del médico: ");
                string specialty = ReadNonEmptyString("Especialidad: ");

                Doctor doctor = new Doctor(name, specialty);
                doctors.Add(doctor);

                Console.WriteLine("Médico dado de alta exitosamente:");
                Console.WriteLine(doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al dar de alta el médico: {ex.Message}");
            }
        }

        // Método para dar de alta un paciente
        static void AddPatient()
        {
            Console.WriteLine("=== Dar de Alta un Paciente ===");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos disponibles. Primero debe dar de alta un médico.");
                return;
            }

            try
            {
                string name = ReadNonEmptyString("Nombre del paciente: ");

                Console.WriteLine("Seleccione el médico asignado:");
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor);
                }

                int doctorId = ReadValidInteger("Ingrese el ID del médico: ");
                Doctor assignedDoctor = doctors.Find(d => d.Id == doctorId);
                if (assignedDoctor == null)
                {
                    Console.WriteLine("Médico no encontrado. Paciente no dado de alta.");
                    return;
                }

                Patient patient = new Patient(name, doctorId);
                patients.Add(patient);
                assignedDoctor.Patients.Add(patient);

                Console.WriteLine("Paciente dado de alta exitosamente:");
                Console.WriteLine(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al dar de alta el paciente: {ex.Message}");
            }
        }

        // Método para dar de alta personal administrativo
        static void AddAdminStaff()
        {
            Console.WriteLine("=== Dar de Alta Personal Administrativo ===");
            try
            {
                string name = ReadNonEmptyString("Nombre del personal administrativo: ");
                string department = ReadNonEmptyString("Departamento: ");

                AdminStaff admin = new AdminStaff(name, department);
                adminStaffs.Add(admin);

                Console.WriteLine("Personal administrativo dado de alta exitosamente:");
                Console.WriteLine(admin);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al dar de alta el personal administrativo: {ex.Message}");
            }
        }

        // Método para listar todos los médicos
        static void ListDoctors()
        {
            Console.WriteLine("=== Lista de Médicos ===");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
                return;
            }

            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }
        }

        // Método para listar los pacientes de un médico específico
        static void ListPatientsOfDoctor()
        {
            Console.WriteLine("=== Listar Pacientes de un Médico ===");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
                return;
            }

            try
            {
                Console.WriteLine("Seleccione el médico:");
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor);
                }

                int doctorId = ReadValidInteger("Ingrese el ID del médico: ");
                Doctor selectedDoctor = doctors.Find(d => d.Id == doctorId);
                if (selectedDoctor == null)
                {
                    Console.WriteLine("Médico no encontrado.");
                    return;
                }

                Console.WriteLine($"Pacientes asignados al Dr. {selectedDoctor.Name}:");
                if (selectedDoctor.Patients.Count == 0)
                {
                    Console.WriteLine("No hay pacientes asignados a este médico.");
                }
                else
                {
                    foreach (var patient in selectedDoctor.Patients)
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar los pacientes: {ex.Message}");
            }
        }

        // Método para eliminar un paciente
        static void RemovePatient()
        {
            Console.WriteLine("=== Eliminar un Paciente ===");
            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            try
            {
                Console.WriteLine("Lista de pacientes:");
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient);
                }

                int patientId = ReadValidInteger("Ingrese el ID del paciente a eliminar: ");
                Patient patientToRemove = patients.Find(p => p.Id == patientId);
                if (patientToRemove == null)
                {
                    Console.WriteLine("Paciente no encontrado.");
                    return;
                }

                // Remover el paciente de la lista general
                patients.Remove(patientToRemove);

                // Remover el paciente de la lista del médico asignado
                Doctor assignedDoctor = doctors.Find(d => d.Id == patientToRemove.DoctorId);
                if (assignedDoctor != null)
                {
                    assignedDoctor.Patients.Remove(patientToRemove);
                }

                Console.WriteLine("Paciente eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el paciente: {ex.Message}");
            }
        }

        // Método para ver la lista de todas las personas del hospital
        static void ViewPeopleList()
        {
            Console.WriteLine("=== Lista de Personas del Hospital ===");

            Console.WriteLine("\n--- Médicos ---");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
            }
            else
            {
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor);
                }
            }

            Console.WriteLine("\n--- Pacientes ---");
            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
            }
            else
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient);
                }
            }

            Console.WriteLine("\n--- Personal Administrativo ---");
            if (adminStaffs.Count == 0)
            {
                Console.WriteLine("No hay personal administrativo registrado.");
            }
            else
            {
                foreach (var admin in adminStaffs)
                {
                    Console.WriteLine(admin);
                }
            }
        }

        // Método para leer una cadena no vacía
        static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine("Entrada inválida. Por favor, ingrese un valor no vacío.");
            }
        }

        // Método para leer un entero válido
        static int ReadValidInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero válido.");
            }
        }
    }
}
