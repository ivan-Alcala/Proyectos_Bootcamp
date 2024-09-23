namespace Hospital.Class
{
    public class Patient : Person
    {
        public int DoctorId { get; set; }

        public Patient(string name, int doctorId) : base(name)
        {
            DoctorId = doctorId;
        }

        public override string ToString()
        {
            return base.ToString() + $", Médico Asignado ID: {DoctorId}";
        }
    }
}