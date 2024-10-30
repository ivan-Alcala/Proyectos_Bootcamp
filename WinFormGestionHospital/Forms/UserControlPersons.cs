using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormGestionHospital.Class;

namespace WinFormGestionHospital.Forms
{
    public partial class UserControlPersons : UserControl
    {
        private string _currentPersonType;
        private readonly Hospital _hospital;

        public UserControlPersons(Hospital hospital)
        {
            InitializeComponent();
            this._hospital = hospital;

            // Iniciar seleccionado un Paciente
            ConfigurePatientColumns();
            ShowPersonData(_hospital.GetPatients());
            _currentPersonType = "Patient";

            // Asigna los eventos de los botones
            btShowDataPatient.Click += (sender, e) =>
            {
                _currentPersonType = "Patient";
                ConfigurePatientColumns();
                ShowPersonData(_hospital.GetPatients());
            };
            btShowDataDoctor.Click += (sender, e) =>
            {
                _currentPersonType = "Doctor";
                ConfigureDoctorColumns();
                ShowPersonData(_hospital.GetDoctors());
            };
            btShowDataAdminStaff.Click += (sender, e) =>
            {
                _currentPersonType = "AdminStaff";
                ConfigureAdminStaffColumns();
                ShowPersonData(_hospital.GetAdminStaff());
            };
        }

        private void ConfigurePatientColumns()
        {
            dtGdVwShowPersons.Columns.Clear();
            dtGdVwShowPersons.Columns.Add("idPerson", "ID");
            dtGdVwShowPersons.Columns.Add("Name", "Nombre");
            dtGdVwShowPersons.Columns.Add("DateOfBirth", "Fecha de Nacimiento");
            dtGdVwShowPersons.Columns.Add("Height", "Altura");
            dtGdVwShowPersons.Columns.Add("Weight", "Peso");

            // Columna de médicos asignados con ComboBox
            var assignedDoctorColumn = new DataGridViewComboBoxColumn
            {
                Name = "AssignedDoctor",
                HeaderText = "Médico Asignado",
                FlatStyle = FlatStyle.Flat
            };

            // Agregar la opción "N/A" como primera opción y establecerla como predeterminada
            assignedDoctorColumn.Items.Add("N/A");
            assignedDoctorColumn.Items.AddRange(_hospital.GetDoctorNames().ToArray());
            assignedDoctorColumn.DefaultCellStyle.NullValue = "N/A";

            dtGdVwShowPersons.Columns.Add(assignedDoctorColumn);
            dtGdVwShowPersons.Columns.Add("Condition", "Condición");
            dtGdVwShowPersons.Columns.Add("AdmissionDate", "Fecha de Admisión");
        }

        private void ConfigureDoctorColumns()
        {
            dtGdVwShowPersons.Columns.Clear();
            dtGdVwShowPersons.Columns.Add("idPerson", "ID");
            dtGdVwShowPersons.Columns.Add("Name", "Nombre");
            dtGdVwShowPersons.Columns.Add("DateOfBirth", "Fecha de Nacimiento");
            dtGdVwShowPersons.Columns.Add("Height", "Altura");
            dtGdVwShowPersons.Columns.Add("Weight", "Peso");
            dtGdVwShowPersons.Columns.Add("Specialty", "Especialidad");
            dtGdVwShowPersons.Columns.Add("YearsExperience", "Años de Experiencia");
            dtGdVwShowPersons.Columns.Add("consultationHours", "Horario de consulta");
        }

        private void ConfigureAdminStaffColumns()
        {
            dtGdVwShowPersons.Columns.Clear();
            dtGdVwShowPersons.Columns.Add("idPerson", "ID");
            dtGdVwShowPersons.Columns.Add("Name", "Nombre");
            dtGdVwShowPersons.Columns.Add("Position", "Puesto");
            dtGdVwShowPersons.Columns.Add("DateOfBirth", "Fecha de Nacimiento");
            dtGdVwShowPersons.Columns.Add("Height", "Altura");
            dtGdVwShowPersons.Columns.Add("Weight", "Peso");
            dtGdVwShowPersons.Columns.Add("YearsInService", "Años en servicio");
            dtGdVwShowPersons.Columns.Add("Department", "Departamento");
        }

        private void ShowPersonData<T>(List<T> persons) where T : Person
        {
            dtGdVwShowPersons.Rows.Clear();

            foreach (var person in persons)
            {
                if (person is Patient patient)
                {
                    dtGdVwShowPersons.Rows.Add(
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
                    dtGdVwShowPersons.Rows.Add(
                        doctor.Id,
                        doctor.Name,
                        doctor.DateOfBirth.ToShortDateString(),
                        doctor.Height,
                        doctor.Weight,
                        doctor.Specialty,
                        doctor.YearsOfExperience,
                        doctor.ConsultationHours
                    );
                }
                else if (person is AdminStaff adminStaff)
                {
                    dtGdVwShowPersons.Rows.Add(
                        adminStaff.Id,
                        adminStaff.Name,
                        adminStaff.Position,
                        adminStaff.DateOfBirth.ToShortDateString(),
                        adminStaff.Height,
                        adminStaff.Weight,
                        adminStaff.YearsInService,
                        adminStaff.Department
                    );
                }
            }
        }

        private void btAddPerson_Click(object sender, System.EventArgs e)
        {
            int rowIndex = dtGdVwShowPersons.Rows.Add();

            DataGridViewRow newRow = dtGdVwShowPersons.Rows[rowIndex];
            newRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red; // Colorea el texto en rojo inicialmente

            // Dependiendo del tipo actual, configura la fila con los valores predeterminados
            switch (_currentPersonType)
            {
                case "Patient":
                    newRow.Cells["idPerson"].Value = "Auto"; // Usar texto de referencia o ID temporal
                    newRow.Cells["Name"].Value = "-";
                    newRow.Cells["DateOfBirth"].Value = new DateTime();
                    newRow.Cells["Height"].Value = "-";
                    newRow.Cells["Weight"].Value = "-";
                    newRow.Cells["Condition"].Value = "-";
                    newRow.Cells["AdmissionDate"].Value = new DateTime();
                    break;
                case "Doctor":
                    newRow.Cells["idPerson"].Value = "Auto";
                    newRow.Cells["Name"].Value = "-";
                    newRow.Cells["DateOfBirth"].Value = new DateTime();
                    newRow.Cells["Height"].Value = "-";
                    newRow.Cells["Weight"].Value = "-";
                    newRow.Cells["Specialty"].Value = "-";
                    newRow.Cells["YearsExperience"].Value = "-";
                    newRow.Cells["consultationHours"].Value = "-";
                    break;
                case "AdminStaff":
                    newRow.Cells["idPerson"].Value = "Auto";
                    newRow.Cells["Name"].Value = "-";
                    newRow.Cells["Position"].Value = "-";
                    newRow.Cells["DateOfBirth"].Value = new DateTime();
                    newRow.Cells["Height"].Value = "-";
                    newRow.Cells["Weight"].Value = "-";
                    newRow.Cells["YearsInService"].Value = "-";
                    break;
            }

            newRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red; // Colorea el texto en negro por defecto
        }

        private void dtGdVwShowPersons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dtGdVwShowPersons.Rows[e.RowIndex];

            if (ValidateRow(currentRow)) // Si todos los campos son válidos
            {
                currentRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;

                // Iniciar el temporizador para revertir a negro después de 1 segundo
                var timer = new Timer { Interval = 1000 };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    timer.Dispose();

                    // Añadir la persona a la lista del hospital
                    AddPersonToHospital(currentRow);
                    currentRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                };
                timer.Start();
            }
        }

        private bool ValidateRow(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()) || cell.Value.ToString().Equals("-"))
                {
                    return false; // Si algún campo está vacío o no válido, retorna falso
                }
            }
            return true;
        }

        private void AddPersonToHospital(DataGridViewRow row)
        {
            switch (_currentPersonType)
            {
                case "Patient":
                    // Obtener el nombre del doctor asignado del ComboBox
                    string doctorName = row.Cells["AssignedDoctor"].Value?.ToString();
                    Doctor assignedDoctor = _hospital.GetDoctors().FirstOrDefault(d => d.Name == doctorName);

                    var patient = new Patient(
                        row.Cells["Name"].Value.ToString(),
                        assignedDoctor,
                        DateTime.Parse(row.Cells["DateOfBirth"].Value.ToString()),
                        double.Parse(row.Cells["Height"].Value.ToString()),
                        double.Parse(row.Cells["Weight"].Value.ToString()),
                        row.Cells["Condition"].Value.ToString(),
                        DateTime.Parse(row.Cells["AdmissionDate"].Value.ToString())
                    );
                    _hospital.AddPerson(patient);
                    break;

                case "Doctor":
                    var doctor = new Doctor(
                        row.Cells["Name"].Value.ToString(),
                        row.Cells["Specialty"].Value.ToString(),
                        DateTime.Parse(row.Cells["DateOfBirth"].Value.ToString()),
                        double.Parse(row.Cells["Height"].Value.ToString()),
                        double.Parse(row.Cells["Weight"].Value.ToString()),
                        int.Parse(row.Cells["YearsExperience"].Value.ToString()),
                        row.Cells["ConsultationHours"].Value.ToString()
                    );
                    _hospital.AddPerson(doctor);
                    break;

                case "AdminStaff":
                    var adminStaff = new AdminStaff(
                        row.Cells["Name"].Value.ToString(),
                        row.Cells["Position"].Value.ToString(),
                        DateTime.Parse(row.Cells["DateOfBirth"].Value.ToString()),
                        double.Parse(row.Cells["Height"].Value.ToString()),
                        double.Parse(row.Cells["Weight"].Value.ToString()),
                        int.Parse(row.Cells["YearsInService"].Value.ToString()),
                        row.Cells["Department"].Value.ToString()
                    );
                    _hospital.AddPerson(adminStaff);
                    break;
            }

        }
    }
}
