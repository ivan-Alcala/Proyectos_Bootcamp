using ConexionBBDD.Class.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexionBBDD.Class.DAL
{
    public class DALJob
    {
        private readonly DBConnect _bdConnect;
        private readonly SqlConnection conn;

        public DALJob(DBConnect bdConnect)
        {
            this._bdConnect = bdConnect;
            this.conn = _bdConnect.connection;
        }

        // Método wrapper que maneja la conexión/desconexión
        private T ExecuteWithConnection<T>(Func<T> operation)
        {
            try
            {
                if (!_bdConnect.IsConnected())
                    _bdConnect.Connect();

                return operation();
            }
            finally
            {
                if (_bdConnect.IsConnected())
                    _bdConnect.Disconnect();
            }
        }

        // Sobrecarga para métodos que no devuelven valor
        private void ExecuteWithConnection(Action operation)
        {
            ExecuteWithConnection<object>(() =>
            {
                operation();
                return null;
            });
        }

        public bool AddJob(Job job)
        {
            return ExecuteWithConnection(() =>
            {
                string query = "INSERT INTO Jobs (job_title, min_salary, max_salary) VALUES (@JobTitle, @MinSalary, @MaxSalary)";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                        cmd.Parameters.AddWithValue("@MinSalary", job.MinSalary);
                        cmd.Parameters.AddWithValue("@MaxSalary", job.MaxSalary);

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
            return ExecuteWithConnection(() =>
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
                            Job job = new Job(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3));
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
            return ExecuteWithConnection(() =>
            {
                string query = "UPDATE Jobs SET job_title = @JobTitle, min_salary = @MinSalary, max_salary = @MaxSalary WHERE job_id = @JobId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobId", job.JobId);
                        cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                        cmd.Parameters.AddWithValue("@MinSalary", job.MinSalary);
                        cmd.Parameters.AddWithValue("@MaxSalary", job.MaxSalary);

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
    }
}