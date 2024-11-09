using ConexionBBDD.Class.DAL;
using ConexionBBDD.Class.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormEmployeeDB.Class.DataGridViewManager
{
    public class DGVJob
    {
        DALJob _jobDAL;
        DataGridView dtGdVwShowJobs;
        Button btSaveJob;
        Button btRemoveJob;
        Dictionary<int, bool> modifiedRows;
        Dictionary<int, Job> rowJobMapping;
        Dictionary<(int row, int column), bool> cellValidation;

        public DGVJob(DataGridView dtGdVwShowJobs, Button btSaveJob, Button btRemoveJob, Dictionary<int, bool> modifiedRows, Dictionary<int, Job> rowJobMapping, Dictionary<(int row, int column), bool> cellValidation)
        {
            this._jobDAL = new DALJob();
            this.dtGdVwShowJobs = dtGdVwShowJobs;
            this.btSaveJob = btSaveJob;
            this.btRemoveJob = btRemoveJob;
            this.modifiedRows = modifiedRows;
            this.rowJobMapping = rowJobMapping;
            this.cellValidation = cellValidation;

            ConfigureJobsColumns();
        }

        #region Jobs
        public void btShowDataJobs_Click(object sender, System.EventArgs e)
        {
            ShowJobData(_jobDAL.GetAllJobs());
        }

        public void btAddJob_Click(object sender, EventArgs e)
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

        public void btSaveJob_Click(object sender, EventArgs e)
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
                        // Modificar trabajo existente
                        UpdateJob(row, rowJobMapping[row.Index]);
                    }
                    else
                    {
                        // Agregar un nuevo trabajo
                        AddJob(row);
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

        public void btRemoveJob_Click(object sender, EventArgs e)
        {
            {
                if (dtGdVwShowJobs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un trabajo para eliminar.",
                                  "Ninguna fila seleccionada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dtGdVwShowJobs.SelectedRows[0];

                // Obtener el Titulo de la columna "Title"
                string titleToSearch = selectedRow.Cells["Title"].Value.ToString();
                if (string.IsNullOrEmpty(titleToSearch))
                {
                    MessageBox.Show("No se puede obtener el Titulo del trabajo seleccionado.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el trabajo {titleToSearch}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idJobToRemove = _jobDAL.GetJobIdByTitle(titleToSearch);
                        _jobDAL.DeleteJobById(idJobToRemove);

                        // Actualizar la vista
                        ShowJobData(_jobDAL.GetAllJobs());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el trabajo: {ex.Message}",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddJob(DataGridViewRow row)
        {
            var jobToAdd = new Job
            {
                JobTitle = row.Cells["Title"].Value.ToString(),
                MinSalary = ParseNullableDecimal(row.Cells["MinSalary"].Value),
                MaxSalary = ParseNullableDecimal(row.Cells["MaxSalary"].Value)
            };
            _jobDAL.AddJob(jobToAdd);
        }

        private void UpdateJob(DataGridViewRow row, Job job)
        {
            job.JobTitle = row.Cells["Title"].Value.ToString();
            job.MinSalary = ParseNullableDecimal(row.Cells["MinSalary"].Value);
            job.MaxSalary = ParseNullableDecimal(row.Cells["MaxSalary"].Value);

            _jobDAL.UpdateJob(job);
        }
        #endregion // END - Jobs

        #region DataGridView Jobs
        public void ConfigureJobsColumns()
        {
            dtGdVwShowJobs.Columns.Clear();
            dtGdVwShowJobs.Columns.Add("Title", "Titulo");
            dtGdVwShowJobs.Columns.Add("MinSalary", "Salario mínimo");
            dtGdVwShowJobs.Columns.Add("MaxSalary", "Salario máximo");
        }

        public void ShowJobData(List<Job> listJobs)
        {
            dtGdVwShowJobs.Rows.Clear();
            rowJobMapping.Clear();
            modifiedRows.Clear();

            int rowIndex;
            foreach (var job in listJobs)
            {
                // Si MinSalary o MaxSalary son null, los reemplazamos por "-"
                var minSalary = job.MinSalary.HasValue ? job.MinSalary.ToString() : "-";
                var maxSalary = job.MaxSalary.HasValue ? job.MaxSalary.ToString() : "-";

                rowIndex = dtGdVwShowJobs.Rows.Add(
                    job.JobTitle,
                    minSalary,
                    maxSalary
                );

                // Mapear la fila con el Job
                rowJobMapping[rowIndex] = job;
                modifiedRows[rowIndex] = false;
            }
        }

        public void ValidateCell(int rowIndex, int columnIndex, object value)
        {
            var cell = dtGdVwShowJobs.Rows[rowIndex].Cells[columnIndex];
            bool isValid = true;
            string columnName = dtGdVwShowJobs.Columns[columnIndex].Name;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || value.ToString() == "-")
            {
                isValid = columnName == "MinSalary" || columnName == "MaxSalary"; // Aceptar null o "-" solo para salarios
            }
            else
            {
                // Validación específica según el tipo de columna
                switch (columnName)
                {
                    case "MinSalary":
                    case "MaxSalary":
                        isValid = decimal.TryParse(value.ToString(), out _);
                        break;
                    default:
                        isValid = !string.IsNullOrWhiteSpace(value.ToString()) && value.ToString() != "-";
                        break;
                }
            }

            cellValidation[(rowIndex, columnIndex)] = isValid;
            cell.Style.ForeColor = isValid ? Color.Green : Color.Red;
        }

        public bool ValidateRow(DataGridViewRow row)
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

        public void SetDefaultValues(DataGridViewRow row, string[] values)
        {
            for (int i = 0; i < values.Length && i < row.Cells.Count; i++)
            {
                row.Cells[i].Value = values[i];
                ValidateCell(row.Index, i, values[i]);
            }
        }

        public void dtGdVwShowJobs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

            // Verificar todas las filas modificadas
            bool allModifiedRowsValid = true;
            foreach (var kvp in modifiedRows)
            {
                if (kvp.Value) // Si la fila está modificada
                {
                    DataGridViewRow row = dtGdVwShowJobs.Rows[kvp.Key];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (!cellValidation.ContainsKey((kvp.Key, cell.ColumnIndex)) ||
                            !cellValidation[(kvp.Key, cell.ColumnIndex)])
                        {
                            allModifiedRowsValid = false;
                            break;
                        }
                    }
                    if (!allModifiedRowsValid) break;
                }
            }

            // Habilitar o deshabilitar el botón de guardar según la validación
            btSaveJob.Enabled = allModifiedRowsValid && modifiedRows.Any(x => x.Value);
        }

        public void dtGdVwShowJobs_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar el botón de eliminar solo si hay una fila seleccionada
            btRemoveJob.Enabled = dtGdVwShowJobs.SelectedRows.Count > 0;
        }

        // Método auxiliar para interpretar "-" o valores vacíos como null
        private decimal? ParseNullableDecimal(object value)
        {
            if (value == null || value.ToString() == "-")
                return null;

            if (decimal.TryParse(value.ToString(), out var result))
                return result;

            return null;
        }
        #endregion // END - DataGridView Jobs
    }
}
