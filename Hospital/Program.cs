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
        static int nextId = 1; // Identificador incremental

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
            Doctor doctor1 = new Doctor(nextId++, "Dr. Juan Pérez", "Cardiología");
            Doctor doctor2 = new Doctor(nextId++, "Dra. María López", "Neurología");
            Doctor doctor3 = new Doctor(nextId++, "Dr. Carlos García", "Pediatría");

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);

            // Crear pacientes de ejemplo y asignarlos a médicos
            Patient patient1 = new Patient(nextId++, "Ana Torres", doctor1.Id);
            Patient patient2 = new Patient(nextId++, "Luis Fernández", doctor2.Id);
            Patient patient3 = new Patient(nextId++, "Sofía Martínez", doctor1.Id);
            Patient patient4 = new Patient(nextId++, "Pedro Sánchez", doctor3.Id);

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
            AdminStaff admin1 = new AdminStaff(nextId++, "Laura Gómez", "Administración");
            AdminStaff admin2 = new AdminStaff(nextId++, "Miguel Rodríguez", "Recursos Humanos");
            AdminStaff admin3 = new AdminStaff(nextId++, "Elena Díaz", "Finanzas");

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
            Console.Write("Nombre del médico: ");
            string name = Console.ReadLine();
            Console.Write("Especialidad: ");
            string specialty = Console.ReadLine();

            Doctor doctor = new Doctor(nextId++, name, specialty);
            doctors.Add(doctor);

            Console.WriteLine("Médico dado de alta exitosamente:");
            Console.WriteLine(doctor);
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

            Console.Write("Nombre del paciente: ");
            string name = Console.ReadLine();

            Console.WriteLine("Seleccione el médico asignado:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }

            Console.Write("Ingrese el ID del médico: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Doctor assignedDoctor = doctors.Find(d => d.Id == doctorId);
                if (assignedDoctor != null)
                {
                    Patient patient = new Patient(nextId++, name, doctorId);
                    patients.Add(patient);
                    assignedDoctor.Patients.Add(patient);

                    Console.WriteLine("Paciente dado de alta exitosamente:");
                    Console.WriteLine(patient);
                }
                else
                {
                    Console.WriteLine("Médico no encontrado. Paciente no dado de alta.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Paciente no dado de alta.");
            }
        }

        // Método para dar de alta personal administrativo
        static void AddAdminStaff()
        {
            Console.WriteLine("=== Dar de Alta Personal Administrativo ===");
            Console.Write("Nombre del personal administrativo: ");
            string name = Console.ReadLine();
            Console.Write("Departamento: ");
            string department = Console.ReadLine();

            AdminStaff admin = new AdminStaff(nextId++, name, department);
            adminStaffs.Add(admin);

            Console.WriteLine("Personal administrativo dado de alta exitosamente:");
            Console.WriteLine(admin);
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

            Console.WriteLine("Seleccione el médico:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }

            Console.Write("Ingrese el ID del médico: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Doctor selectedDoctor = doctors.Find(d => d.Id == doctorId);
                if (selectedDoctor != null)
                {
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
                else
                {
                    Console.WriteLine("Médico no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
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

            Console.WriteLine("Lista de pacientes:");
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }

            Console.Write("Ingrese el ID del paciente a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int patientId))
            {
                Patient patientToRemove = patients.Find(p => p.Id == patientId);
                if (patientToRemove != null)
                {
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
                else
                {
                    Console.WriteLine("Paciente no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
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
    }
}