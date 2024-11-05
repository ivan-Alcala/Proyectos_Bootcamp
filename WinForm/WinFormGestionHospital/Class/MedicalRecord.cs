using System.Collections.Generic;

namespace WinFormGestionHospital.Class
{
    public class MedicalRecord
    {
        public Patient Patient { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<string> Diagnoses { get; set; }
        public List<string> Treatments { get; set; }
        public List<string> DoctorNotes { get; set; }

        public MedicalRecord(Patient patient)
        {
            Patient = patient;
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
            return $"Historial médico de {Patient.Name} (ID: {Patient.Id})\n" +
                   $"Citas: {Appointments.Count}\n" +
                   $"Diagnósticos: {Diagnoses.Count}\n" +
                   $"Tratamientos: {Treatments.Count}\n" +
                   $"Notas del médico: {DoctorNotes.Count}";
        }
    }
}