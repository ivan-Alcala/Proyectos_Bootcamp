using System.Collections.Generic;

namespace Hospital.Class
{
    public class Doctor : Person
    {
        public string Specialty { get; set; }
        public List<Patient> Patients { get; set; }

        public Doctor(string name, string specialty) : base(name)
        {
            Specialty = specialty;
            Patients = new List<Patient>();
        }

        public override string ToString()
        {
            return base.ToString() + $", Especialidad: {Specialty}";
        }
    }
}