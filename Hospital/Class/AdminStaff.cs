namespace Hospital.Class
{
    public class AdminStaff : Person
    {
        public string Position { get; set; }

        public AdminStaff(string name, string position) : base(name)
        {
            Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + $", Position: {Position}";
        }
    }
}