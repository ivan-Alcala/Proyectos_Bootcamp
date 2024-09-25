using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionHospital.Class
{
    public class Hospital
    {
        private List<Person> _people = new List<Person>();
        private List<Appointment> _appointments = new List<Appointment>();

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

        #region Appointment
        public void ScheduleAppointment()
        {
            int doctorId = Tools.AskInt("ID del médico: ");
            Doctor doctor = GetDoctorById(doctorId);

            int patientId = Tools.AskInt("ID del paciente: ");
            Patient patient = GetPatientById(patientId);

            DateTime appointmentDate = Tools.AskDate("Fecha de la cita (dd/MM/yyyy hh:mm): ");

            if (doctor != null && patient != null)
            {
                Appointment appointment = new Appointment(doctor, patient, appointmentDate);
                _appointments.Add(appointment);
                Console.WriteLine("Cita programada correctamente.");
            }
            else
                Console.WriteLine("Error al asignar el médico o paciente.");
        }

        public void ListAppointments()
        {
            if (_appointments.Count == 0)
            {
                Console.WriteLine("No hay citas programadas.");
                return;
            }

            foreach (var appointment in _appointments)
                Console.WriteLine(appointment);
        }

        public void CancelAppointment()
        {
            int patientId = Tools.AskInt("ID del paciente para cancelar la cita: ");
            var appointment = _appointments.FirstOrDefault(a => a.AssignedPatient.Id == patientId);

            if (appointment != null)
            {
                _appointments.Remove(appointment);
                Console.WriteLine("Cita cancelada correctamente.");
            }
            else
                Console.WriteLine("Cita no encontrada.");
        }

        public void ModifyAppointment()
        {
            int patientId = Tools.AskInt("ID del paciente para modificar la cita: ");
            var appointment = _appointments.FirstOrDefault(a => a.AssignedPatient.Id == patientId);

            if (appointment != null)
            {
                Console.WriteLine($"Cita actual: {appointment}");
                DateTime newDate = Tools.AskDate("Nueva fecha de la cita (dd/MM/yyyy hh:mm): ");
                appointment.AppointmentDate = newDate;
                Console.WriteLine("Cita modificada correctamente.");
            }
            else
                Console.WriteLine("Cita no encontrada.");
        }

        public Patient GetPatientById(int id)
        {
            return _people.OfType<Patient>().FirstOrDefault(p => p.Id == id);
        }
        #endregion

        #region MedicalRecord
        public void AddMedicalRecord(int patientId)
        {
            var patient = GetPatientById(patientId);
            if (patient != null)
            {
                Console.WriteLine($"Agregando historial médico para el paciente {patient.Name}");

                string diagnosis = Tools.AskString("Diagnóstico: ");
                patient.MedicalRecord.AddDiagnosis(diagnosis);

                string treatment = Tools.AskString("Tratamiento: ");
                patient.MedicalRecord.AddTreatment(treatment);

                string note = Tools.AskString("Nota del médico: ");
                patient.MedicalRecord.AddDoctorNote(note);

                Console.WriteLine("Historial médico actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }

        public void ViewMedicalRecord(int patientId)
        {
            var patient = GetPatientById(patientId);
            if (patient != null)
            {
                Console.WriteLine(patient.MedicalRecord);
                Console.WriteLine("\nDiagnósticos:");
                foreach (var diagnosis in patient.MedicalRecord.Diagnoses)
                {
                    Console.WriteLine(diagnosis);
                }
                Console.WriteLine("\nTratamientos:");
                foreach (var treatment in patient.MedicalRecord.Treatments)
                {
                    Console.WriteLine(treatment);
                }
                Console.WriteLine("\nNotas del médico:");
                foreach (var note in patient.MedicalRecord.DoctorNotes)
                {
                    Console.WriteLine(note);
                }
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }

        #endregion

        public void AddTestData()
        {
            // Agregar médicos
            var doctor1 = new Doctor("Dr. Carlos", "Cardiología", new DateTime(1975, 5, 20), 1.78, 75, 20, "9am-2pm");
            var doctor2 = new Doctor("Dra. Ana", "Neurología", new DateTime(1980, 10, 12), 1.65, 60, 15, "10am-4pm");
            var doctor3 = new Doctor("Dr. Roberto", "Pediatría", new DateTime(1985, 1, 5), 1.80, 85, 10, "8am-1pm");

            _people.Add(doctor1);
            _people.Add(doctor2);
            _people.Add(doctor3);

            // Agregar pacientes
            var patient1 = new Patient("Juan Pérez", doctor1, new DateTime(1990, 7, 15), 1.70, 70, "Hipertensión", DateTime.Now.AddDays(-10));
            var patient2 = new Patient("María López", doctor2, new DateTime(1988, 2, 20), 1.62, 55, "Migraña Crónica", DateTime.Now.AddDays(-5));
            var patient3 = new Patient("Pedro Martínez", doctor3, new DateTime(1995, 11, 22), 1.75, 68, "Asma", DateTime.Now.AddDays(-2));

            _people.Add(patient1);
            _people.Add(patient2);
            _people.Add(patient3);

            // Agregar empleados administrativos
            _people.Add(new AdminStaff("Lucía González", "Secretaria", new DateTime(1992, 4, 30), 1.60, 50, 5, "Administración"));
            _people.Add(new AdminStaff("Javier Reyes", "Contador", new DateTime(1985, 8, 14), 1.75, 78, 12, "Finanzas"));

            // Agregar citas
            _appointments.Add(new Appointment(doctor1, patient1, new DateTime(2024, 9, 25)));
            _appointments.Add(new Appointment(doctor2, patient2, new DateTime(2024, 9, 26)));
            _appointments.Add(new Appointment(doctor3, patient3, new DateTime(2024, 9, 27)));

            // Añadir datos de ejemplo para el historial médico
            patient1.MedicalRecord.AddDiagnosis("Hipertensión grado 2");
            patient1.MedicalRecord.AddTreatment("Losartán 50mg, 1 comprimido cada 12 horas");
            patient1.MedicalRecord.AddDoctorNote("Paciente responde bien al tratamiento. Programar revisión en 3 meses.");

            var appointment1 = new Appointment(patient1.AssignedDoctor, patient1, new DateTime(2024, 9, 25, 10, 0, 0));
            patient1.MedicalRecord.AddAppointment(appointment1);

            patient2.MedicalRecord.AddDiagnosis("Migraña crónica");
            patient2.MedicalRecord.AddTreatment("Sumatriptán 50mg, 1 comprimido al inicio de los síntomas");
            patient2.MedicalRecord.AddDoctorNote("Considerar terapia preventiva si los episodios aumentan en frecuencia.");

            var appointment2 = new Appointment(patient2.AssignedDoctor, patient2, new DateTime(2024, 9, 26, 11, 30, 0));
            patient2.MedicalRecord.AddAppointment(appointment2);

            patient3.MedicalRecord.AddDiagnosis("Asma leve persistente");
            patient3.MedicalRecord.AddTreatment("Salbutamol inhalador, 2 inhalaciones cada 6 horas según sea necesario");
            patient3.MedicalRecord.AddDoctorNote("Educar al paciente sobre el uso correcto del inhalador. Programar pruebas de función pulmonar.");

            var appointment3 = new Appointment(patient3.AssignedDoctor, patient3, new DateTime(2024, 9, 27, 9, 15, 0));
            patient3.MedicalRecord.AddAppointment(appointment3);

            Console.WriteLine("Datos de prueba añadidos.");
        }
    }
}
