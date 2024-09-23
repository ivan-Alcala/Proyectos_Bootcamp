namespace Hospital.Class
{
    public class Patient : Person
    {
        public int DoctorId { get; set; }

        public Patient(int id, string name, int doctorId) : base(id, name)
        {
            DoctorId = doctorId;
        }

        public override string ToString()
        {
            return base.ToString() + $", Médico Asignado ID: {DoctorId}";
        }
    }
}