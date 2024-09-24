namespace Hospital.Class
{
    public class Patient : Person
    {
        public Doctor AssignedDoctor { get; set; }

        public Patient(string name, Doctor assignedDoctor) : base(name)
        {
            AssignedDoctor = assignedDoctor;
        }

        public override string ToString()
        {
            return base.ToString() + $", Assigned Doctor: {AssignedDoctor.Name}";
        }
    }
}