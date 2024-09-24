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
            var doctor1 = new Doctor("Dr. Carlos", "Cardiología");
            var doctor2 = new Doctor("Dr. Ana", "Neurología");
            var doctor3 = new Doctor("Dr. Roberto", "Pediatría");

            _people.Add(doctor1);
            _people.Add(doctor2);
            _people.Add(doctor3);

            // Agregar pacientes asignados a médicos
            _people.Add(new Patient("Paciente Juan", doctor1));
            _people.Add(new Patient("Paciente María", doctor2));
            _people.Add(new Patient("Paciente Pedro", doctor3));

            // Agregar empleados administrativos
            _people.Add(new AdminStaff("Lucía", "Secretaria"));
            _people.Add(new AdminStaff("Javier", "Contador"));

            Console.WriteLine("Datos de prueba añadidos.");
        }
    }
}
