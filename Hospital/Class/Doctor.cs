namespace Hospital.Class
{
    public class Doctor : Person
    {
        public string Specialty { get; set; }

        public Doctor(string name, string specialty) : base(name)
        {
            Specialty = specialty;
        }

        public override string ToString()
        {
            return base.ToString() + $", Specialty: {Specialty}";
        }
    }
}