using ConexionBBDD.Class.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexionBBDD.Class.DAL
{
    public class DALEmployee
    {
        private readonly DBConnect _bdConnect;
        private readonly SqlConnection conn;

        public DALEmployee()
        {
            this._bdConnect = new DBConnect();
            this.conn = _bdConnect.connection;
        }

        public bool AddEmployee(Employee employee)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "INSERT INTO Employees (first_name, last_name, email, phone_number, hire_date, job_id, salary, manager_id, department_id) " +
                               "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @HireDate, @JobId, @Salary, @ManagerId, @DepartmentId)";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", (object)employee.FirstName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", (object)employee.PhoneNumber ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        cmd.Parameters.AddWithValue("@JobId", employee.JobId);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@ManagerId", (object)employee.ManagerId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartmentId", (object)employee.DepartmentId ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el Employee: " + ex.Message);
                    return false;
                }
            });
        }

        public List<Employee> GetAllEmployees()
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                var employees = new List<Employee>();
                string query = "SELECT * FROM Employees";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                EmployeeId = reader.GetInt32(0),
                                FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                LastName = reader.GetString(2),
                                Email = reader.GetString(3),
                                PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4),
                                HireDate = reader.GetDateTime(5),
                                JobId = reader.GetInt32(6),
                                Salary = reader.GetDecimal(7),
                                ManagerId = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                DepartmentId = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                            };
                            employees.Add(employee);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los Employees: " + ex.Message);
                }

                return employees;
            });
        }

        public bool UpdateEmployee(Employee employee)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "UPDATE Employees SET first_name = @FirstName, last_name = @LastName, email = @Email, phone_number = @PhoneNumber, " +
                               "hire_date = @HireDate, job_id = @JobId, salary = @Salary, manager_id = @ManagerId, department_id = @DepartmentId " +
                               "WHERE employee_id = @EmployeeId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                        cmd.Parameters.AddWithValue("@FirstName", (object)employee.FirstName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", (object)employee.PhoneNumber ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        cmd.Parameters.AddWithValue("@JobId", employee.JobId);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@ManagerId", (object)employee.ManagerId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartmentId", (object)employee.DepartmentId ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el Employee: " + ex.Message);
                    return false;
                }
            });
        }

        public bool DeleteEmployee(int employeeId)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "DELETE FROM Employees WHERE employee_id = @EmployeeId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el Employee: " + ex.Message);
                    return false;
                }
            });
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                Employee employee = null;
                string query = "SELECT * FROM Employees WHERE employee_id = @EmployeeId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee
                                {
                                    EmployeeId = reader.GetInt32(0),
                                    FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    HireDate = reader.GetDateTime(5),
                                    JobId = reader.GetInt32(6),
                                    Salary = reader.GetDecimal(7),
                                    ManagerId = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    DepartmentId = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el Employee: " + ex.Message);
                }

                return employee;
            });
        }
    }
}