namespace Hospital.Class
{
    public class AdminStaff : Person
    {
        public string Department { get; set; }

        public AdminStaff(string name, string department) : base(name)
        {
            Department = department;
        }

        public override string ToString()
        {
            return base.ToString() + $", Departamento: {Department}";
        }
    }
}