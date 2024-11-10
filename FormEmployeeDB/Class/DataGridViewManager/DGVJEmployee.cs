using ConexionBBDD.Class.DAL;
using ConexionBBDD.Class.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormEmployeeDB.Class.DataGridViewManager
{
    public class DGVEmployee
    {
        DALEmployee _DALEmployee;
        DataGridView dtGdVwShowEmployees;
        Button btSaveEmployees;
        Button btRemoveEmployee;
        Dictionary<int, bool> modifiedRows;
        Dictionary<int, Employee> rowEmployeeMapping;
        Dictionary<(int row, int column), bool> cellValidation;

        public DGVEmployee(DataGridView dtGdVwShowEmployees, Button btSaveEmployees, Button btRemoveEmployee, Dictionary<int, bool> modifiedRows, Dictionary<int, Employee> rowEmployeeMapping, Dictionary<(int row, int column), bool> cellValidation)
        {
            this._DALEmployee = new DALEmployee();
            this.dtGdVwShowEmployees = dtGdVwShowEmployees;
            this.btSaveEmployees = btSaveEmployees;
            this.btRemoveEmployee = btRemoveEmployee;
            this.modifiedRows = modifiedRows;
            this.rowEmployeeMapping = rowEmployeeMapping;
            this.cellValidation = cellValidation;

            ConfigureEmployeesColumns();
        }

        #region Employees
        public void btShowDataEmployees_Click(object sender, System.EventArgs e)
        {
            ShowEmployeeData(_DALEmployee.GetAllEmployees());
        }

        public void btAddEmployee_Click(object sender, EventArgs e)
        {
            int rowIndex = dtGdVwShowEmployees.Rows.Add();
            DataGridViewRow newRow = dtGdVwShowEmployees.Rows[rowIndex];

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

        public void btSaveEmployee_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToProcess = new List<DataGridViewRow>();

            // Recolectar todas las filas modificadas
            foreach (DataGridViewRow row in dtGdVwShowEmployees.Rows)
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
                    if (rowEmployeeMapping.ContainsKey(row.Index))
                    {
                        // Modificar trabajo existente
                        UpdateEmployee(row, rowEmployeeMapping[row.Index]);
                    }
                    else
                    {
                        // Agregar un nuevo trabajo
                        AddEmployee(row);
                    }

                    // Resetear el estado de modificación y el color
                    modifiedRows[row.Index] = false;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // Actualizar la vista
            ShowEmployeeData(_DALEmployee.GetAllEmployees());
            btSaveEmployees.Enabled = false;
        }

        public void btRemoveEmployee_Click(object sender, EventArgs e)
        {
            {
                if (dtGdVwShowEmployees.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un trabajo para eliminar.",
                                  "Ninguna fila seleccionada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dtGdVwShowEmployees.SelectedRows[0];

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
                        int idJobToRemove = _DALEmployee.GetEmployeeById(titleToSearch);
                        _DALEmployee.DeleteJobById(idJobToRemove);

                        // Actualizar la vista
                        ShowEmployeeData(_DALEmployee.GetAllEmployees());
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

        private void AddEmployee(DataGridViewRow row)
        {
            var employeeToAdd = new Employee
            {
                JobTitle = row.Cells["Title"].Value.ToString(),
                MinSalary = ParseNullableDecimal(row.Cells["MinSalary"].Value),
                MaxSalary = ParseNullableDecimal(row.Cells["MaxSalary"].Value)
            };
            _DALEmployee.AddEmployee(employeeToAdd);
        }

        private void UpdateEmployee(DataGridViewRow row, Employee employee)
        {
            employee.JobTitle = row.Cells["Title"].Value.ToString();
            employee.MinSalary = ParseNullableDecimal(row.Cells["MinSalary"].Value);
            employee.MaxSalary = ParseNullableDecimal(row.Cells["MaxSalary"].Value);

            _DALEmployee.UpdateEmployee(employee);
        }
        #endregion // END - Employees

        #region DataGridView Employees
        public void ConfigureEmployeesColumns()
        {
            dtGdVwShowEmployees.Columns.Clear();
            dtGdVwShowEmployees.Columns.Add("Title", "Titulo");
            dtGdVwShowEmployees.Columns.Add("MinSalary", "Salario mínimo");
            dtGdVwShowEmployees.Columns.Add("MaxSalary", "Salario máximo");
        }

        public void ShowEmployeeData(List<Employee> listEmployees)
        {
            dtGdVwShowEmployees.Rows.Clear();
            rowEmployeeMapping.Clear();
            modifiedRows.Clear();

            int rowIndex;
            foreach (var employee in listEmployees)
            {
                // Si MinSalary o MaxSalary son null, los reemplazamos por "-"
                var minSalary = employee.MinSalary.HasValue ? employee.MinSalary.ToString() : "-";
                var maxSalary = employee.MaxSalary.HasValue ? employee.MaxSalary.ToString() : "-";

                rowIndex = dtGdVwShowEmployees.Rows.Add(
                    employee.JobTitle,
                    minSalary,
                    maxSalary
                );

                // Mapear la fila con el Employee
                rowEmployeeMapping[rowIndex] = employee;
                modifiedRows[rowIndex] = false;
            }
        }

        public void ValidateCell(int rowIndex, int columnIndex, object value)
        {
            var cell = dtGdVwShowEmployees.Rows[rowIndex].Cells[columnIndex];
            bool isValid = true;
            string columnName = dtGdVwShowEmployees.Columns[columnIndex].Name;

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

        public void dtGdVwShowEmployees_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow currentRow = dtGdVwShowEmployees.Rows[e.RowIndex];

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
                    DataGridViewRow row = dtGdVwShowEmployees.Rows[kvp.Key];
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
            btSaveEmployees.Enabled = allModifiedRowsValid && modifiedRows.Any(x => x.Value);
        }

        public void dtGdVwShowEmployees_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar el botón de eliminar solo si hay una fila seleccionada
            btRemoveEmployee.Enabled = dtGdVwShowEmployees.SelectedRows.Count > 0;
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
        #endregion // END - DataGridView Employees
    }
}
