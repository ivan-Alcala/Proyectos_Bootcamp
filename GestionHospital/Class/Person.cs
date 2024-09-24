namespace GestionHospital.Class
{
    public class Person
    {
        private static int _nextId = 1; // Identificador incremental estático

        public int Id { get; private set; }
        public string Name { get; set; }

        public Person(string name)
        {
            Id = _nextId++;
            Name = name;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}