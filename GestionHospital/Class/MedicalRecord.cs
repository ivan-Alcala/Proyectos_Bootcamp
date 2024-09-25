using System.Collections.Generic;

namespace GestionHospital.Class
{
    public class MedicalRecord
    {
        public int PatientId { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<string> Diagnoses { get; set; }
        public List<string> Treatments { get; set; }
        public List<string> DoctorNotes { get; set; }

        public MedicalRecord(int patientId)
        {
            PatientId = patientId;
            Appointments = new List<Appointment>();
            Diagnoses = new List<string>();
            Treatments = new List<string>();
            DoctorNotes = new List<string>();
        }

        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public void AddDiagnosis(string diagnosis)
        {
            Diagnoses.Add(diagnosis);
        }

        public void AddTreatment(string treatment)
        {
            Treatments.Add(treatment);
        }

        public void AddDoctorNote(string note)
        {
            DoctorNotes.Add(note);
        }

        public override string ToString()
        {
            return $"Historial médico del paciente ID: {PatientId}\n" +
                   $"Citas: {Appointments.Count}\n" +
                   $"Diagnósticos: {Diagnoses.Count}\n" +
                   $"Tratamientos: {Treatments.Count}\n" +
                   $"Notas del médico: {DoctorNotes.Count}";
        }
    }
}