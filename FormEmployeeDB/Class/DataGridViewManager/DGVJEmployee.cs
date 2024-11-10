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
        Button btSaveEmployee;
        Button btRemoveEmployee;
        Dictionary<int, bool> modifiedRows;
        Dictionary<int, Employee> rowEmployeeMapping;
        Dictionary<(int row, int column), bool> cellValidation;

        public DGVEmployee(DataGridView dtGdVwShowEmployees, Button btSaveEmployee, Button btRemoveEmployee)
        {
            this._DALEmployee = new DALEmployee();
            this.dtGdVwShowEmployees = dtGdVwShowEmployees;
            this.btSaveEmployee = btSaveEmployee;
            this.btRemoveEmployee = btRemoveEmployee;

            modifiedRows = new Dictionary<int, bool>();
            rowEmployeeMapping = new Dictionary<int, Employee>();
            cellValidation = new Dictionary<(int row, int column), bool>();

            ConfigureEmployeesColumns();
        }

        #region Employees
        public void btShowDataEmployees_Click(object sender, EventArgs e)
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
                "-", "-", "-", "-", DateTime.Now.ToString(), "-", "-", "-", "-" });
        }

        public void btSaveEmployee_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToProcess = new List<DataGridViewRow>();

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
                        UpdateEmployee(row, rowEmployeeMapping[row.Index]);
                    }
                    else
                    {
                        AddEmployee(row);
                    }

                    modifiedRows[row.Index] = false;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            ShowEmployeeData(_DALEmployee.GetAllEmployees());
            btSaveEmployee.Enabled = false;
        }

        public void btRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (dtGdVwShowEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.",
                                "Ninguna fila seleccionada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dtGdVwShowEmployees.SelectedRows[0];

            if (rowEmployeeMapping.TryGetValue(selectedRow.Index, out var employeeToRemove))
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar al empleado {employeeToRemove.FirstName} {employeeToRemove.LastName}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Eliminar el empleado usando su EmployeeId
                        _DALEmployee.DeleteEmployeeById(employeeToRemove.EmployeeId);

                        // Actualizar la vista
                        ShowEmployeeData(_DALEmployee.GetAllEmployees());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}",
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
                FirstName = row.Cells["FirstName"].Value.ToString(),
                LastName = row.Cells["LastName"].Value.ToString(),
                Email = row.Cells["Email"].Value.ToString(),
                PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                HireDate = DateTime.Parse(row.Cells["HireDate"].Value.ToString()),
                JobId = int.Parse(row.Cells["JobId"].Value.ToString()),
                Salary = decimal.Parse(row.Cells["Salary"].Value.ToString()),
                ManagerId = ParseNullableInt(row.Cells["ManagerId"].Value),
                DepartmentId = ParseNullableInt(row.Cells["DepartmentId"].Value)
            };
            _DALEmployee.AddEmployee(employeeToAdd);
        }

        private void UpdateEmployee(DataGridViewRow row, Employee employee)
        {
            employee.FirstName = row.Cells["FirstName"].Value.ToString();
            employee.LastName = row.Cells["LastName"].Value.ToString();
            employee.Email = row.Cells["Email"].Value.ToString();
            employee.PhoneNumber = row.Cells["PhoneNumber"].Value.ToString();
            employee.HireDate = DateTime.Parse(row.Cells["HireDate"].Value.ToString());
            employee.JobId = int.Parse(row.Cells["JobId"].Value.ToString());
            employee.Salary = decimal.Parse(row.Cells["Salary"].Value.ToString());
            employee.ManagerId = ParseNullableInt(row.Cells["ManagerId"].Value);
            employee.DepartmentId = ParseNullableInt(row.Cells["DepartmentId"].Value);

            _DALEmployee.UpdateEmployee(employee);
        }
        #endregion // END - Employees

        #region DataGridView Employees
        public void ConfigureEmployeesColumns()
        {
            dtGdVwShowEmployees.Columns.Clear();
            dtGdVwShowEmployees.Columns.Add("FirstName", "Nombre");
            dtGdVwShowEmployees.Columns.Add("LastName", "Apellido");
            dtGdVwShowEmployees.Columns.Add("Email", "Correo Electrónico");
            dtGdVwShowEmployees.Columns.Add("PhoneNumber", "Teléfono");
            dtGdVwShowEmployees.Columns.Add("HireDate", "Fecha de Contratación");
            dtGdVwShowEmployees.Columns.Add("JobId", "ID de Trabajo");
            dtGdVwShowEmployees.Columns.Add("Salary", "Salario");
            dtGdVwShowEmployees.Columns.Add("ManagerId", "ID de Gerente");
            dtGdVwShowEmployees.Columns.Add("DepartmentId", "ID de Departamento");
        }

        public void ShowEmployeeData(List<Employee> listEmployees)
        {
            dtGdVwShowEmployees.Rows.Clear();
            rowEmployeeMapping.Clear();
            modifiedRows.Clear();

            int rowIndex;
            foreach (var employee in listEmployees)
            {
                var managerId = employee.ManagerId.HasValue ? employee.ManagerId.ToString() : "-";
                var departmentId = employee.DepartmentId.HasValue ? employee.DepartmentId.ToString() : "-";

                rowIndex = dtGdVwShowEmployees.Rows.Add(
                    employee.FirstName,
                    employee.LastName,
                    employee.Email,
                    employee.PhoneNumber,
                    employee.HireDate.ToString("yyyy-MM-dd"),
                    employee.JobId,
                    employee.Salary,
                    managerId,
                    departmentId
                );

                rowEmployeeMapping[rowIndex] = employee;
                modifiedRows[rowIndex] = false;
            }
        }

        private void ValidateCell(int rowIndex, int columnIndex, object value)
        {
            var cell = dtGdVwShowEmployees.Rows[rowIndex].Cells[columnIndex];
            bool isValid = true;
            string columnName = dtGdVwShowEmployees.Columns[columnIndex].Name;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || value.ToString() == "-")
            {
                isValid = columnName == "ManagerId" || columnName == "DepartmentId";
            }
            else
            {
                switch (columnName)
                {
                    case "HireDate":
                        isValid = DateTime.TryParse(value.ToString(), out _);
                        break;
                    case "JobId":
                    case "ManagerId":
                    case "DepartmentId":
                        isValid = int.TryParse(value.ToString(), out _);
                        break;
                    case "Salary":
                        isValid = decimal.TryParse(value.ToString(), out _);
                        break;
                    default:
                        isValid = !string.IsNullOrWhiteSpace(value.ToString());
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
            btSaveEmployee.Enabled = allModifiedRowsValid && modifiedRows.Any(x => x.Value);
        }

        public void dtGdVwShowEmployees_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar el botón de eliminar solo si hay una fila seleccionada
            btRemoveEmployee.Enabled = dtGdVwShowEmployees.SelectedRows.Count > 0;
        }

        // Método auxiliar para interpretar "-" o valores vacíos como null
        private int? ParseNullableInt(object value)
        {
            if (value == null || value.ToString() == "-") return null;
            if (int.TryParse(value.ToString(), out int result)) return result;
            return null;
        }
        #endregion // END - DataGridView Employees
    }
}
