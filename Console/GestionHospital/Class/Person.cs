using System;

namespace GestionHospital.Class
{
    public class Person
    {
        private static int _nextId = 1; // Identificador incremental estático

        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; } // Altura de la persona en metros
        public double Weight { get; set; } // Peso de la persona en kilogramos

        public Person(string name, DateTime dateOfBirth, double height, double weight)
        {
            Id = _nextId++;
            Name = name;
            DateOfBirth = dateOfBirth;
            Height = height;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Name}, Fecha de Nacimiento: {DateOfBirth.ToShortDateString()}, Altura: {Height}m, Peso: {Weight}kg";
        }
    }
}
