using ConexionBBDD.Class;
using ConexionBBDD.Class.DAL;
using ConexionBBDD.Class.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConexionBBDD.Forms
{
    public partial class UserControlJobs : UserControl
    {
        DBConnect bbddConnect;
        DALJob _jobDAL;
        private Dictionary<int, bool> modifiedRows = new Dictionary<int, bool>();
        private Dictionary<int, Job> rowJobMapping = new Dictionary<int, Job>();
        private Dictionary<(int row, int column), bool> cellValidation = new Dictionary<(int row, int column), bool>();

        public UserControlJobs(DBConnect bbddConnect)
        {
            this._jobDAL = new DALJob(bbddConnect);
            this.bbddConnect = bbddConnect;
            InitializeComponent();
            InitStyleComponent();

            ConfigureJobsColumns();
            ShowJobData(_jobDAL.GetAllJobs());
            btAddJob.Click += btAddJob_Click;
        }

        #region Style
        private void InitStyleComponent()
        {
            SelectedButtonStyle(btShowDataJobs);

            // DataGridView de Persons
            DataGridViewCellStyle selectedRowStyle = dtGdVwShowJobs.RowsDefaultCellStyle;
            selectedRowStyle.SelectionBackColor = ColorTranslator.FromHtml("#d6e0ef");
            selectedRowStyle.SelectionForeColor = ColorTranslator.FromHtml("#282b3e");
            // Establecer el estilo para las filas pares
            dtGdVwShowJobs.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e9eff6");
            // Establecer el estilo para las filas impares
            dtGdVwShowJobs.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ffffff");
            dtGdVwShowJobs.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#f3f6fa");
        }

        private void UnselectedButtonStyle(Button button)
        {
            // Limpia los paneles agregados anteriormente
            button.Controls.Clear();

            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.Transparent;
            button.ForeColor = ColorTranslator.FromHtml("#9baaba");

            // Aplica negrita solo si no está en negrita
            if (button.Font.Style != FontStyle.Bold)
            {
                button.Font = new Font(button.Font, FontStyle.Bold);
            }

            button.FlatAppearance.BorderSize = 0;

            // Crea el borde inferior y agrégalo
            Panel borderBottom = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = ColorTranslator.FromHtml("#edeef2")
            };

            button.Controls.Add(borderBottom);
        }

        private void SelectedButtonStyle(Button button)
        {
            // Limpia los paneles agregados anteriormente
            button.Controls.Clear();

            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.Transparent;
            button.ForeColor = ColorTranslator.FromHtml("#3579fe");

            // Aplica negrita solo si no está en negrita
            if (button.Font.Style != FontStyle.Bold)
            {
                button.Font = new Font(button.Font, FontStyle.Bold);
            }

            button.FlatAppearance.BorderSize = 0;

            // Crea el borde inferior y agrégalo
            Panel borderBottom = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = ColorTranslator.FromHtml("#1361fe")
            };

            button.Controls.Add(borderBottom);
        }
        #endregion // END - Style

        #region Jobs
        private void LoadJobs()
        {
            List<Job> jobs = _jobDAL.GetAllJobs();
            dtGdVwShowJobs.DataSource = jobs;
        }

        private void btShowDataJobs_Click(object sender, System.EventArgs e)
        {
            ShowJobData(_jobDAL.GetAllJobs());
        }

        private void btAddJob_Click(object sender, EventArgs e)
        {
            int rowIndex = dtGdVwShowJobs.Rows.Add();
            DataGridViewRow newRow = dtGdVwShowJobs.Rows[rowIndex];

            // Inicializar la validación de todas las celdas como false
            for (int i = 0; i < newRow.Cells.Count; i++)
            {
                cellValidation[(rowIndex, i)] = false;
                newRow.Cells[i].Style.ForeColor = Color.Red;
            }

            // Establecer valores predeterminados según el tipo
            SetDefaultValues(newRow, new[] {
                "-", "-", "-"
            });
        }

        private void btSaveJob_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToProcess = new List<DataGridViewRow>();

            // Recolectar todas las filas modificadas
            foreach (DataGridViewRow row in dtGdVwShowJobs.Rows)
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
                    if (rowJobMapping.ContainsKey(row.Index))
                    {
                        // Modificar persona existente
                        UpdateJob(row, rowJobMapping[row.Index]);
                    }
                    else
                    {
                        // Agregar nueva persona
                        //AddPersonToHospital(row);
                    }

                    // Resetear el estado de modificación y el color
                    modifiedRows[row.Index] = false;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // Actualizar la vista
            ShowJobData(_jobDAL.GetAllJobs());
            btSaveJob.Enabled = false;
        }

        private void UpdateJob(DataGridViewRow row, Job job)
        {
            // Actualizar propiedades
            job.JobTitle = row.Cells["Title"].Value.ToString();
            job.MinSalary = decimal.Parse(row.Cells["MinSalary"].Value.ToString());
            job.MaxSalary = decimal.Parse(row.Cells["MaxSalary"].Value.ToString());

            _jobDAL.UpdateJob(job);
        }

        #endregion // END - Jobs

        #region DataGridView Jobs
        private void ConfigureJobsColumns()
        {
            dtGdVwShowJobs.Columns.Clear();
            dtGdVwShowJobs.Columns.Add("Title", "Titulo");
            dtGdVwShowJobs.Columns.Add("MinSalary", "Salario mínimo");
            dtGdVwShowJobs.Columns.Add("MaxSalary", "Salario máximo");
        }

        private void ShowJobData(List<Job> listJobs)
        {
            dtGdVwShowJobs.Rows.Clear();
            rowJobMapping.Clear();
            modifiedRows.Clear();

            int rowIndex;
            foreach (var job in listJobs)
            {
                rowIndex = dtGdVwShowJobs.Rows.Add(
                  job.JobTitle,
                  job.MinSalary,
                  job.MaxSalary
                );

                // Mapear la fila con el Job
                rowJobMapping[rowIndex] = job;
                modifiedRows[rowIndex] = false;
            }
        }

        private void ValidateCell(int rowIndex, int columnIndex, object value)
        {
            var cell = dtGdVwShowJobs.Rows[rowIndex].Cells[columnIndex];
            bool isValid = true;
            string columnName = dtGdVwShowJobs.Columns[columnIndex].Name;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || value.ToString() == "-")
            {
                isValid = false;
            }
            else
            {
                // Validación específica según el tipo de columna
                switch (columnName)
                {
                    case "MinSalary":
                        isValid = double.TryParse(value.ToString(), out _);
                        break;
                    case "MaxSalary":
                        isValid = double.TryParse(value.ToString(), out _);
                        break;

                    // Para campos de texto como Name, Title, etc.
                    default:
                        isValid = !string.IsNullOrWhiteSpace(value.ToString()) &&
                                value.ToString() != "-";
                        break;
                }
            }

            cellValidation[(rowIndex, columnIndex)] = isValid;
            cell.Style.ForeColor = isValid ? Color.Green : Color.Red;
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

        private void SetDefaultValues(DataGridViewRow row, string[] values)
        {
            for (int i = 0; i < values.Length && i < row.Cells.Count; i++)
            {
                row.Cells[i].Value = values[i];
                ValidateCell(row.Index, i, values[i]);
            }
        }

        private void dtGdVwShowJobs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            btSaveJob.Enabled = true;
            DataGridViewRow currentRow = dtGdVwShowJobs.Rows[e.RowIndex];

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

        private void dtGdVwShowJobs_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar el botón de eliminar solo si hay una fila seleccionada
            btRemoveJob.Enabled = dtGdVwShowJobs.SelectedRows.Count > 0;
        }
        #endregion // END - DataGridView Jobs
    }
}
