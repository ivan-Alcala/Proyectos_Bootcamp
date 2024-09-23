namespace Hospital.Class
{
    public class AdminStaff : Person
    {
        public string Department { get; set; }

        // Constructor
        public AdminStaff(int id, string name, string department) : base(id, name)
        {
            Department = department;
        }

        // Redefinición del método ToString()
        public override string ToString()
        {
            return base.ToString() + $", Departamento: {Department}";
        }
    }
}