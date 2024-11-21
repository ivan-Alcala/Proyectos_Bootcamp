using FormEmployeeDB.Class.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FormEmployeeDB.Class.DAL
{
    public class DALDepartment
    {
        private readonly DBConnect _bdConnect;
        private readonly SqlConnection conn;

        public DALDepartment()
        {
            this._bdConnect = new DBConnect();
            this.conn = _bdConnect.connection;
        }

        public bool AddDepartment(Department department)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "INSERT INTO Departments (department_name, location_id) VALUES (@DepartmentName, @LocationId)";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                        cmd.Parameters.AddWithValue("@LocationId", (object)department.LocationId ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el Department: " + ex.Message);
                    return false;
                }
            });
        }

        public List<Department> GetAllDepartments()
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                var departments = new List<Department>();
                string query = "SELECT * FROM Departments";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var department = new Department
                            {
                                DepartmentId = reader.GetInt32(0),
                                DepartmentName = reader.GetString(1),
                                LocationId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)
                            };
                            departments.Add(department);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los Departments: " + ex.Message);
                }

                return departments;
            });
        }

        public bool UpdateDepartment(Department department)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "UPDATE Departments SET department_name = @DepartmentName, location_id = @LocationId " +
                               "WHERE department_id = @DepartmentId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                        cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                        cmd.Parameters.AddWithValue("@LocationId", (object)department.LocationId ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el Department: " + ex.Message);
                    return false;
                }
            });
        }

        public bool DeleteDepartmentById(int departmentId)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "DELETE FROM Departments WHERE department_id = @DepartmentId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el Department: " + ex.Message);
                    return false;
                }
            });
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                Department department = null;
                string query = "SELECT * FROM Departments WHERE department_id = @DepartmentId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                department = new Department
                                {
                                    DepartmentId = reader.GetInt32(0),
                                    DepartmentName = reader.GetString(1),
                                    LocationId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el Department: " + ex.Message);
                }

                return department;
            });
        }
    }
}