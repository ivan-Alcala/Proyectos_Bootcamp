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
            InicializarDatosEjemplo();

            bool exit = false;
            while (!exit)
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        DarDeAltaMedico();
                        break;
                    case "2":
                        DarDeAltaPaciente();
                        break;
                    case "3":
                        DarDeAltaPersonalAdministrativo();
                        break;
                    case "4":
                        ListarMedicos();
                        break;
                    case "5":
                        ListarPacientesDeMedico();
                        break;
                    case "6":
                        EliminarPaciente();
                        break;
                    case "7":
                        VerListaPersonas();
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
        static void InicializarDatosEjemplo()
        {
            // Crear médicos de ejemplo
            Doctor medico1 = new Doctor(nextId++, "Dr. Juan Pérez", "Cardiología");
            Doctor medico2 = new Doctor(nextId++, "Dra. María López", "Neurología");
            Doctor medico3 = new Doctor(nextId++, "Dr. Carlos García", "Pediatría");

            doctors.Add(medico1);
            doctors.Add(medico2);
            doctors.Add(medico3);

            // Crear pacientes de ejemplo y asignarlos a médicos
            Patient paciente1 = new Patient(nextId++, "Ana Torres", medico1.Id);
            Patient paciente2 = new Patient(nextId++, "Luis Fernández", medico2.Id);
            Patient paciente3 = new Patient(nextId++, "Sofía Martínez", medico1.Id);
            Patient paciente4 = new Patient(nextId++, "Pedro Sánchez", medico3.Id);

            patients.Add(paciente1);
            patients.Add(paciente2);
            patients.Add(paciente3);
            patients.Add(paciente4);

            // Asignar pacientes a los médicos correspondientes
            medico1.Patients.Add(paciente1);
            medico1.Patients.Add(paciente3);
            medico2.Patients.Add(paciente2);
            medico3.Patients.Add(paciente4);

            // Crear personal administrativo de ejemplo
            AdminStaff admin1 = new AdminStaff(nextId++, "Laura Gómez", "Administración");
            AdminStaff admin2 = new AdminStaff(nextId++, "Miguel Rodríguez", "Recursos Humanos");
            AdminStaff admin3 = new AdminStaff(nextId++, "Elena Díaz", "Finanzas");

            adminStaffs.Add(admin1);
            adminStaffs.Add(admin2);
            adminStaffs.Add(admin3);
        }

        // Método para mostrar el menú de opciones
        static void MostrarMenu()
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
        static void DarDeAltaMedico()
        {
            Console.WriteLine("=== Dar de Alta un Médico ===");
            Console.Write("Nombre del médico: ");
            string nombre = Console.ReadLine();
            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine();

            Doctor medico = new Doctor(nextId++, nombre, especialidad);
            doctors.Add(medico);

            Console.WriteLine("Médico dado de alta exitosamente:");
            Console.WriteLine(medico);
        }

        // Método para dar de alta un paciente
        static void DarDeAltaPaciente()
        {
            Console.WriteLine("=== Dar de Alta un Paciente ===");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos disponibles. Primero debe dar de alta un médico.");
                return;
            }

            Console.Write("Nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Seleccione el médico asignado:");
            foreach (var medico in doctors)
            {
                Console.WriteLine(medico);
            }

            Console.Write("Ingrese el ID del médico: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Doctor medicoAsignado = doctors.Find(m => m.Id == doctorId);
                if (medicoAsignado != null)
                {
                    Patient paciente = new Patient(nextId++, nombre, doctorId);
                    patients.Add(paciente);
                    medicoAsignado.Patients.Add(paciente);

                    Console.WriteLine("Paciente dado de alta exitosamente:");
                    Console.WriteLine(paciente);
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
        static void DarDeAltaPersonalAdministrativo()
        {
            Console.WriteLine("=== Dar de Alta Personal Administrativo ===");
            Console.Write("Nombre del personal administrativo: ");
            string nombre = Console.ReadLine();
            Console.Write("Departamento: ");
            string departamento = Console.ReadLine();

            AdminStaff admin = new AdminStaff(nextId++, nombre, departamento);
            adminStaffs.Add(admin);

            Console.WriteLine("Personal administrativo dado de alta exitosamente:");
            Console.WriteLine(admin);
        }

        // Método para listar todos los médicos
        static void ListarMedicos()
        {
            Console.WriteLine("=== Lista de Médicos ===");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
                return;
            }

            foreach (var medico in doctors)
            {
                Console.WriteLine(medico);
            }
        }

        // Método para listar los pacientes de un médico específico
        static void ListarPacientesDeMedico()
        {
            Console.WriteLine("=== Listar Pacientes de un Médico ===");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
                return;
            }

            Console.WriteLine("Seleccione el médico:");
            foreach (var medico in doctors)
            {
                Console.WriteLine(medico);
            }

            Console.Write("Ingrese el ID del médico: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Doctor medicoSeleccionado = doctors.Find(m => m.Id == doctorId);
                if (medicoSeleccionado != null)
                {
                    Console.WriteLine($"Pacientes asignados al Dr. {medicoSeleccionado.Name}:");
                    if (medicoSeleccionado.Patients.Count == 0)
                    {
                        Console.WriteLine("No hay pacientes asignados a este médico.");
                    }
                    else
                    {
                        foreach (var paciente in medicoSeleccionado.Patients)
                        {
                            Console.WriteLine(paciente);
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
        static void EliminarPaciente()
        {
            Console.WriteLine("=== Eliminar un Paciente ===");
            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.WriteLine("Lista de pacientes:");
            foreach (var paciente in patients)
            {
                Console.WriteLine(paciente);
            }

            Console.Write("Ingrese el ID del paciente a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int pacienteId))
            {
                Patient pacienteAEliminar = patients.Find(p => p.Id == pacienteId);
                if (pacienteAEliminar != null)
                {
                    // Remover el paciente de la lista general
                    patients.Remove(pacienteAEliminar);

                    // Remover el paciente de la lista del médico asignado
                    Doctor medicoAsignado = doctors.Find(m => m.Id == pacienteAEliminar.DoctorId);
                    if (medicoAsignado != null)
                    {
                        medicoAsignado.Patients.Remove(pacienteAEliminar);
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
        static void VerListaPersonas()
        {
            Console.WriteLine("=== Lista de Personas del Hospital ===");

            Console.WriteLine("\n--- Médicos ---");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
            }
            else
            {
                foreach (var medico in doctors)
                {
                    Console.WriteLine(medico);
                }
            }

            Console.WriteLine("\n--- Pacientes ---");
            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
            }
            else
            {
                foreach (var paciente in patients)
                {
                    Console.WriteLine(paciente);
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