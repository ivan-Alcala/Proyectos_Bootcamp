using System;

namespace GestionHospital.Class
{
    public class Appointment
    {
        public Doctor AssignedDoctor { get; set; }
        public Patient AssignedPatient { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(Doctor doctor, Patient patient, DateTime date)
        {
            AssignedDoctor = doctor;
            AssignedPatient = patient;
            AppointmentDate = date;
        }

        public override string ToString()
        {
            return $"Doctor: {AssignedDoctor.Name}, Paciente: {AssignedPatient.Name}, Fecha: {AppointmentDate}";
        }
    }
}
