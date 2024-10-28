using System.Collections.Generic;
using System.Windows.Forms;
using WinFormGestionHospital.Class;

namespace WinFormGestionHospital.Forms
{
    public partial class UserControlPersons : UserControl
    {
        private readonly Hospital _hospital;

        public UserControlPersons(Hospital hospital)
        {
            InitializeComponent();
            this._hospital = hospital;

            ConfigurePatientColumns();
            ShowPersonData(_hospital.GetPatients());

            // Asigna los eventos de los botones
            btShowDataPatient.Click += (sender, e) => { ConfigurePatientColumns(); ShowPersonData(_hospital.GetPatients()); };
            btShowDataDoctor.Click += (sender, e) => { ConfigureDoctorColumns(); ShowPersonData(_hospital.GetDoctors()); };
            btShowDataAdminStaff.Click += (sender, e) => { ConfigureAdminStaffColumns(); ShowPersonData(_hospital.GetAdminStaff()); };
        }

        private void ConfigurePatientColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("idPerson", "ID");
            dataGridView1.Columns.Add("Name", "Nombre");
            dataGridView1.Columns.Add("DateOfBirth", "Fecha de Nacimiento");
            dataGridView1.Columns.Add("Height", "Altura");
            dataGridView1.Columns.Add("Weight", "Peso");
            dataGridView1.Columns.Add("AssignedDoctor", "Médico Asignado");
            dataGridView1.Columns.Add("Condition", "Condición");
            dataGridView1.Columns.Add("AdmissionDate", "Fecha de Admisión");
        }

        private void ConfigureDoctorColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("idPerson", "ID");
            dataGridView1.Columns.Add("Name", "Nombre");
            dataGridView1.Columns.Add("DateOfBirth", "Fecha de Nacimiento");
            dataGridView1.Columns.Add("Specialty", "Especialidad");
            dataGridView1.Columns.Add("YearsExperience", "Años de Experiencia");
        }

        private void ConfigureAdminStaffColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("idPerson", "ID");
            dataGridView1.Columns.Add("Name", "Nombre");
            dataGridView1.Columns.Add("DateOfBirth", "Fecha de Nacimiento");
            dataGridView1.Columns.Add("Department", "Departamento");
            dataGridView1.Columns.Add("Position", "Puesto");
        }

        private void ShowPersonData<T>(List<T> persons) where T : Person
        {
            dataGridView1.Rows.Clear();

            foreach (var person in persons)
            {
                if (person is Patient patient)
                {
                    dataGridView1.Rows.Add(
                        patient.Id,
                        patient.Name,
                        patient.DateOfBirth.ToShortDateString(),
                        patient.Height,
                        patient.Weight,
                        patient.AssignedDoctor?.Name ?? "N/A",
                        patient.Condition,
                        patient.AdmissionDate.ToShortDateString()
                    );
                }
                else if (person is Doctor doctor)
                {
                    dataGridView1.Rows.Add(
                        doctor.Id,
                        doctor.Name,
                        doctor.DateOfBirth.ToShortDateString(),
                        doctor.Specialty,
                        doctor.ConsultationHours
                    );
                }
                else if (person is AdminStaff adminStaff)
                {
                    dataGridView1.Rows.Add(
                        adminStaff.Id,
                        adminStaff.Name,
                        adminStaff.DateOfBirth.ToShortDateString(),
                        adminStaff.Department,
                        adminStaff.Position
                    );
                }
            }
        }
    }
}
