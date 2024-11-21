using FormEmployeeDB.Class.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FormEmployeeDB.Class.DAL
{
    public class DALJob
    {
        private readonly DBConnect _bdConnect;
        private readonly SqlConnection conn;

        public DALJob()
        {
            this._bdConnect = new DBConnect();
            this.conn = _bdConnect.connection;
        }

        public bool AddJob(Job job)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "INSERT INTO Jobs (job_title, min_salary, max_salary) VALUES (@JobTitle, @MinSalary, @MaxSalary)";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                        cmd.Parameters.AddWithValue("@MinSalary", (object)job.MinSalary ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaxSalary", (object)job.MaxSalary ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el Job: " + ex.Message);
                    return false;
                }
            });
        }

        public List<Job> GetAllJobs()
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                var jobs = new List<Job>();
                string query = "SELECT * FROM Jobs";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var job = new Job
                            {
                                JobId = reader.GetInt32(0),
                                JobTitle = reader.GetString(1),
                                MinSalary = GetSafeDecimal(reader, 2),
                                MaxSalary = GetSafeDecimal(reader, 3)
                            };
                            jobs.Add(job);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los Jobs: " + ex.Message);
                }

                return jobs;
            });
        }

        public bool UpdateJob(Job job)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "UPDATE Jobs SET job_title = @JobTitle, min_salary = @MinSalary, max_salary = @MaxSalary WHERE job_id = @JobId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobId", job.JobId);
                        cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                        cmd.Parameters.AddWithValue("@MinSalary", (object)job.MinSalary ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaxSalary", (object)job.MaxSalary ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el Job: " + ex.Message);
                    return false;
                }
            });
        }

        public bool DeleteJobById(int jobId)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "DELETE FROM Jobs WHERE job_id = @JobId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parámetro para identificar el Job a eliminar
                        cmd.Parameters.AddWithValue("@JobId", jobId);

                        // Ejecutar la consulta y verificar si se afectó alguna fila
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el Job: " + ex.Message);
                    return false;
                }
            });
        }

        public int GetJobIdByTitle(string jobTitle)
        {
            return _bdConnect.ExecuteWithConnection(() =>
            {
                string query = "SELECT job_id FROM Jobs WHERE job_title = @JobTitle";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parámetro para buscar el título del trabajo
                        cmd.Parameters.AddWithValue("@JobTitle", jobTitle);

                        // Ejecutar la consulta y obtener el resultado
                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int jobId))
                        {
                            return jobId;
                        }
                        else
                        {
                            return -1; // Indica que no se encontró el Job con el título dado
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar el Job por título: " + ex.Message);
                    return -1;
                }
            });
        }

        private decimal? GetSafeDecimal(SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (decimal?)null : reader.GetDecimal(index);
        }
    }
}