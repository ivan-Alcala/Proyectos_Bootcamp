using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormGestionHospital.Class;

namespace WinFormGestionHospital.Forms
{
    public partial class UserControlPersons : UserControl
    {
        private string _currentPersonType;
        private readonly Hospital _hospital;
        private Dictionary<int, bool> modifiedRows = new Dictionary<int, bool>();
        private Dictionary<int, Person> rowPersonMapping = new Dictionary<int, Person>();
        private Dictionary<(int row, int column), bool> cellValidation = new Dictionary<(int row, int column), bool>();

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
            rowPersonMapping.Clear();
            modifiedRows.Clear();

            foreach (var person in persons)
            {
                int rowIndex;
                if (person is Patient patient)
                {
                    rowIndex = dtGdVwShowPersons.Rows.Add(
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
                    rowIndex = dtGdVwShowPersons.Rows.Add(
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
                    rowIndex = dtGdVwShowPersons.Rows.Add(
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
                else
                {
                    continue;
                }

                // Mapear la fila con la persona
                rowPersonMapping[rowIndex] = person;
                modifiedRows[rowIndex] = false;
            }
        }

        private void btAddPerson_Click(object sender, EventArgs e)
        {
            int rowIndex = dtGdVwShowPersons.Rows.Add();
            DataGridViewRow newRow = dtGdVwShowPersons.Rows[rowIndex];

            // Inicializar la validación de todas las celdas como false
            for (int i = 0; i < newRow.Cells.Count; i++)
            {
                cellValidation[(rowIndex, i)] = false;
                newRow.Cells[i].Style.ForeColor = Color.Red;
            }

            // Establecer valores predeterminados según el tipo
            switch (_currentPersonType)
            {
                case "Patient":
                    SetDefaultValues(newRow, new[] {
                        "Auto", "-", DateTime.Now.ToShortDateString(), "-", "-", "N/A", "-", DateTime.Now.ToShortDateString()
                    });
                    break;
                case "Doctor":
                    SetDefaultValues(newRow, new[] {
                        "Auto", "-", DateTime.Now.ToShortDateString(), "-", "-", "-", "0", "-"
                    });
                    break;
                case "AdminStaff":
                    SetDefaultValues(newRow, new[] {
                        "Auto", "-", "-", DateTime.Now.ToShortDateString(), "-", "-", "0", "-"
                    });
                    break;
            }
        }

        private void dtGdVwShowPersons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            btSavePerson.Enabled = true;
            DataGridViewRow currentRow = dtGdVwShowPersons.Rows[e.RowIndex];

            // Validar la celda que cambió
            ValidateCell(e.RowIndex, e.ColumnIndex, currentRow.Cells[e.ColumnIndex].Value);

            // Verificar si toda la fila es válida
            bool isRowValid = true;
            foreach (DataGridViewCell cell in currentRow.Cells)
            {
                if (!cellValidation.ContainsKey((e.RowIndex, cell.ColumnIndex)) ||
                    !cellValidation[(e.RowIndex, cell.ColumnIndex)])
                {
                    isRowValid = false;
                    break;
                }
            }

            modifiedRows[e.RowIndex] = true;

            // Si la fila es válida, cambiar el color del texto de la fila a naranja (pendiente de guardar)
            if (isRowValid)
            {
                foreach (DataGridViewCell cell in currentRow.Cells)
                {
                    if (cellValidation[(e.RowIndex, cell.ColumnIndex)])
                    {
                        cell.Style.ForeColor = Color.Orange;
                    }
                }
            }
        }

        private bool ValidateRow(DataGridViewRow row)
        {
            bool isValid = true;

            for (int i = 0; i < row.Cells.Count; i++)
            {
                ValidateCell(row.Index, i, row.Cells[i].Value);
                if (!cellValidation[(row.Index, i)])
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private void ValidateCell(int rowIndex, int columnIndex, object value)
        {
            var cell = dtGdVwShowPersons.Rows[rowIndex].Cells[columnIndex];
            bool isValid = true;
            string columnName = dtGdVwShowPersons.Columns[columnIndex].Name;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || value.ToString() == "-")
            {
                isValid = false;
            }
            else
            {
                // Validación específica según el tipo de columna
                switch (columnName)
                {
                    case "Height":
                    case "Weight":
                        isValid = double.TryParse(value.ToString(), out _);
                        break;

                    case "YearsExperience":
                    case "YearsInService":
                        isValid = int.TryParse(value.ToString(), out _) &&
                                int.Parse(value.ToString()) >= 0;
                        break;

                    case "DateOfBirth":
                    case "AdmissionDate":
                        isValid = DateTime.TryParse(value.ToString(), out var date) &&
                                date <= DateTime.Now;
                        break;

                    case "AssignedDoctor":
                        isValid = value.ToString() != "N/A" && !string.IsNullOrEmpty(value.ToString());
                        break;

                    // Para campos de texto como Name, Condition, Position, etc.
                    default:
                        isValid = !string.IsNullOrWhiteSpace(value.ToString()) &&
                                value.ToString() != "-";
                        break;
                }
            }

            cellValidation[(rowIndex, columnIndex)] = isValid;
            cell.Style.ForeColor = isValid ? Color.Green : Color.Red;
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

        private void BtSavePerson_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToProcess = new List<DataGridViewRow>();

            // Recolectar todas las filas modificadas
            foreach (DataGridViewRow row in dtGdVwShowPersons.Rows)
            {
                if (modifiedRows.ContainsKey(row.Index) && modifiedRows[row.Index])
                {
                    rowsToProcess.Add(row);
                }
            }

            foreach (var row in rowsToProcess)
            {
                if (ValidateRow(row))
                {
                    if (rowPersonMapping.ContainsKey(row.Index))
                    {
                        // Modificar persona existente
                        UpdateExistingPerson(row, rowPersonMapping[row.Index]);
                    }
                    else
                    {
                        // Agregar nueva persona
                        AddPersonToHospital(row);
                    }

                    // Resetear el estado de modificación y el color
                    modifiedRows[row.Index] = false;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // Actualizar la vista
            RefreshCurrentView();
            btSavePerson.Enabled = false;
        }

        private void UpdateExistingPerson(DataGridViewRow row, Person person)
        {
            // Actualizar propiedades comunes
            person.Name = row.Cells["Name"].Value.ToString();
            person.DateOfBirth = DateTime.Parse(row.Cells["DateOfBirth"].Value.ToString());
            person.Height = double.Parse(row.Cells["Height"].Value.ToString());
            person.Weight = double.Parse(row.Cells["Weight"].Value.ToString());

            // Actualizar propiedades específicas según el tipo
            switch (person)
            {
                case Patient patient:
                    string doctorName = row.Cells["AssignedDoctor"].Value?.ToString();
                    patient.AssignedDoctor = _hospital.GetDoctors().FirstOrDefault(d => d.Name == doctorName);
                    patient.Condition = row.Cells["Condition"].Value.ToString();
                    patient.AdmissionDate = DateTime.Parse(row.Cells["AdmissionDate"].Value.ToString());
                    break;

                case Doctor doctor:
                    doctor.Specialty = row.Cells["Specialty"].Value.ToString();
                    doctor.YearsOfExperience = int.Parse(row.Cells["YearsExperience"].Value.ToString());
                    doctor.ConsultationHours = row.Cells["consultationHours"].Value.ToString();
                    break;

                case AdminStaff adminStaff:
                    adminStaff.Position = row.Cells["Position"].Value.ToString();
                    adminStaff.YearsInService = int.Parse(row.Cells["YearsInService"].Value.ToString());
                    adminStaff.Department = row.Cells["Department"].Value.ToString();
                    break;
            }
        }

        private void RefreshCurrentView()
        {
            switch (_currentPersonType)
            {
                case "Patient":
                    ShowPersonData(_hospital.GetPatients());
                    break;
                case "Doctor":
                    ShowPersonData(_hospital.GetDoctors());
                    break;
                case "AdminStaff":
                    ShowPersonData(_hospital.GetAdminStaff());
                    break;
            }
        }

        private void SetDefaultValues(DataGridViewRow row, string[] values)
        {
            for (int i = 0; i < values.Length && i < row.Cells.Count; i++)
            {
                row.Cells[i].Value = values[i];
                ValidateCell(row.Index, i, values[i]);
            }
        }

        private void btRemovePerson_Click(object sender, EventArgs e)
        {
            {
                if (dtGdVwShowPersons.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una persona para eliminar.",
                                  "Ninguna fila seleccionada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dtGdVwShowPersons.SelectedRows[0];

                // Obtener el ID de la columna "idPerson"
                if (!int.TryParse(selectedRow.Cells["idPerson"].Value?.ToString(), out int idToRemove))
                {
                    MessageBox.Show("No se puede obtener el ID de la persona seleccionada.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar la persona con ID {idToRemove}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Eliminar la persona usando el método de Hospital
                        _hospital.RemovePerson(idToRemove);

                        // Actualizar la vista según el tipo actual
                        RefreshCurrentView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la persona: {ex.Message}",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtGdVwShowPersons_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar el botón de eliminar solo si hay una fila seleccionada
            btRemovePerson.Enabled = dtGdVwShowPersons.SelectedRows.Count > 0;
        }
    }
}
