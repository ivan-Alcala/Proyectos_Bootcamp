namespace Hospital.Class
{
    public class Patient : Person
    {
        public int DoctorId { get; set; }

        // Constructor
        public Patient(int id, string name, int doctorId) : base(id, name)
        {
            DoctorId = doctorId;
        }

        // Redefinición del método ToString()
        public override string ToString()
        {
            return base.ToString() + $", Médico Asignado ID: {DoctorId}";
        }
    }
}