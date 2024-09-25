using System;

namespace GestionHospital.Class
{
    public class Patient : Person
    {
        public Doctor AssignedDoctor { get; set; }
        public string Condition { get; set; }
        public DateTime AdmissionDate { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public Patient(string name, Doctor assignedDoctor, DateTime dateOfBirth, double height, double weight, string condition, DateTime admissionDate)
            : base(name, dateOfBirth, height, weight)
        {
            AssignedDoctor = assignedDoctor;
            Condition = condition;
            AdmissionDate = admissionDate;
            MedicalRecord = new MedicalRecord(Id);
        }

        public override string ToString()
        {
            return base.ToString() + $", Médico Asignado: {AssignedDoctor.Name}, Condición: {Condition}, Fecha de Admisión: {AdmissionDate.ToShortDateString()}";
        }
    }
}