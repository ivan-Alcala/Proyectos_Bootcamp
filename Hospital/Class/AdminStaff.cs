namespace Hospital.Class
{
    public class AdminStaff : Person
    {
        public string Department { get; set; }

        public AdminStaff(int id, string name, string department) : base(id, name)
        {
            Department = department;
        }

        public override string ToString()
        {
            return base.ToString() + $", Departamento: {Department}";
        }
    }
}