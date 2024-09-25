using System;

namespace GestionHospital.Class
{
    public class AdminStaff : Person
    {
        public string Position { get; set; }
        public int YearsInService { get; set; }
        public string Department { get; set; }

        public AdminStaff(string name, string position, DateTime dateOfBirth, double height, double weight, int yearsInService, string department)
            : base(name, dateOfBirth, height, weight)
        {
            Position = position;
            YearsInService = yearsInService;
            Department = department;
        }

        public override string ToString()
        {
            return base.ToString() + $", Posición: {Position}, Años de Servicio: {YearsInService}, Departamento: {Department}";
        }
    }
}
