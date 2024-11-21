using System;

namespace GestionHospital.Class
{
    public class Doctor : Person
    {
        public string Specialty { get; set; }
        public int YearsOfExperience { get; set; }
        public string ConsultationHours { get; set; }

        public Doctor(string name, string specialty, DateTime dateOfBirth, double height, double weight, int yearsOfExperience, string consultationHours)
            : base(name, dateOfBirth, height, weight)
        {
            Specialty = specialty;
            YearsOfExperience = yearsOfExperience;
            ConsultationHours = consultationHours;
        }

        public override string ToString()
        {
            return base.ToString() + $", Especialidad: {Specialty}, Años de Experiencia: {YearsOfExperience}, Horario de Consultas: {ConsultationHours}";
        }
    }
}
