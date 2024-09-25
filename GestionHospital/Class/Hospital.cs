using System;
using System.Collections.Generic;

namespace GestionHospital.Class
{
    public class Hospital
    {
        private List<Person> _people = new List<Person>();

        public void AddPerson(Person person)
        {
            _people.Add(person);
            Console.WriteLine("Persona añadida correctamente.");
        }

        public void RemovePerson(int id)
        {
            var personToRemove = _people.Find(p => p.Id == id);
            if (personToRemove != null)
            {
                _people.Remove(personToRemove);
                Console.WriteLine("Persona eliminada correctamente.");
            }
            else
                Console.WriteLine("Persona no encontrada.");
        }

        // Método para modificar los datos de una persona
        public void ModifyPerson(int id)
        {
            var person = _people.Find(p => p.Id == id);

            if (person == null)
            {
                Console.WriteLine("Persona no encontrada.");
                return;
            }

            Console.WriteLine($"Modificando datos de {person.Name} (ID: {person.Id})");

            // Modificar atributos generales (comunes a todas las personas)
            person.Name = Tools.AskString("Nuevo nombre: ");
            person.DateOfBirth = Tools.AskDate("Nueva fecha de nacimiento (dd/MM/yyyy): ");
            person.Height = Tools.AskDouble("Nueva altura (en metros): ");
            person.Weight = Tools.AskDouble("Nuevo peso (en kg): ");

            // Modificar atributos específicos según el tipo de persona
            if (person is Doctor doctor)
            {
                doctor.Specialty = Tools.AskString("Nueva especialidad: ");
                doctor.YearsOfExperience = Tools.AskInt("Años de experiencia: ");
                doctor.ConsultationHours = Tools.AskString("Nuevo horario de consultas: ");
            }
            else if (person is Patient patient)
            {
                patient.Condition = Tools.AskString("Nueva condición del paciente: ");
                patient.AdmissionDate = Tools.AskDate("Nueva fecha de admisión (dd/MM/yyyy): ");
            }
            else if (person is AdminStaff adminStaff)
            {
                adminStaff.Position = Tools.AskString("Nuevo cargo: ");
            }

            Console.WriteLine("Datos modificados correctamente.");
        }

        public void ListPeople()
        {
            // Listar médicos
            Console.WriteLine("\nMédicos:");
            bool hasDoctors = false;
            foreach (var person in _people)
            {
                if (person is Doctor doctor)
                {
                    Console.WriteLine(doctor);
                    hasDoctors = true;
                }
            }
            if (!hasDoctors)
                Console.WriteLine("No hay médicos registrados.");

            // Listar pacientes
            Console.WriteLine("\nPacientes:");
            bool hasPatients = false;
            foreach (var person in _people)
            {
                if (person is Patient patient)
                {
                    Console.WriteLine(patient);
                    hasPatients = true;
                }
            }
            if (!hasPatients)
                Console.WriteLine("No hay pacientes registrados.");

            // Listar personal administrativo
            Console.WriteLine("\nPersonal Administrativo:");
            bool hasAdminStaff = false;
            foreach (var person in _people)
            {
                if (person is AdminStaff adminStaff)
                {
                    Console.WriteLine(adminStaff);
                    hasAdminStaff = true;
                }
            }
            if (!hasAdminStaff)
                Console.WriteLine("No hay personal administrativo registrado.");
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _people.Find(p => p.Id == id && p is Doctor) as Doctor;

            if (doctor != null)
                return doctor;
            else
            {
                Console.WriteLine("Médico no encontrado.");
                return null;
            }
        }

        public void AddTestData()
        {
            // Agregar médicos
            var doctor1 = new Doctor("Dr. Carlos", "Cardiología", new DateTime(1975, 5, 20), 1.78, 75, 20, "9am-2pm");
            var doctor2 = new Doctor("Dra. Ana", "Neurología", new DateTime(1980, 10, 12), 1.65, 60, 15, "10am-4pm");
            var doctor3 = new Doctor("Dr. Roberto", "Pediatría", new DateTime(1985, 1, 5), 1.80, 85, 10, "8am-1pm");

            _people.Add(doctor1);
            _people.Add(doctor2);
            _people.Add(doctor3);

            // Agregar pacientes asignados a médicos
            _people.Add(new Patient("Juan Pérez", doctor1, new DateTime(1990, 7, 15), 1.70, 70, "Hipertensión", DateTime.Now.AddDays(-10)));
            _people.Add(new Patient("María López", doctor2, new DateTime(1988, 2, 20), 1.62, 55, "Migraña Crónica", DateTime.Now.AddDays(-5)));
            _people.Add(new Patient("Pedro Martínez", doctor3, new DateTime(1995, 11, 22), 1.75, 68, "Asma", DateTime.Now.AddDays(-2)));

            // Agregar empleados administrativos
            _people.Add(new AdminStaff("Lucía González", "Secretaria", new DateTime(1992, 4, 30), 1.60, 50, 5, "Administración"));
            _people.Add(new AdminStaff("Javier Reyes", "Contador", new DateTime(1985, 8, 14), 1.75, 78, 12, "Finanzas"));

            Console.WriteLine("Datos de prueba añadidos.");
        }
    }
}
