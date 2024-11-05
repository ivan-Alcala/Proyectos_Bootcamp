using ConexionBBDD.Class.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexionBBDD.Class.DAL
{
    public class JobDAL
    {
        BBDDConnect _bdConnect;
        SqlConnection conn;

        public JobDAL(BBDDConnect bdConnect)
        {
            this._bdConnect = bdConnect;
            this.conn = _bdConnect.connection;
        }

        // Método para añadir un nuevo Job a la base de datos
        public bool AddJob(Job job)
        {
            string query = "INSERT INTO Jobs (job_title, min_salary, max_salary) VALUES (@JobTitle, @MinSalary, @MaxSalary)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Parámetros de la consulta
                    cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    cmd.Parameters.AddWithValue("@MinSalary", job.MinSalary);
                    cmd.Parameters.AddWithValue("@MaxSalary", job.MaxSalary);

                    // Ejecutar la consulta y verificar si se afectó alguna fila
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el Job: " + ex.Message);
                return false;
            }
        }

        // Método para obtener la lista de Jobs desde la base de datos
        public List<Job> GetJobs()
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
                            MinSalary = (float)reader.GetDecimal(2),  // Convertir de decimal a float
                            MaxSalary = (float)reader.GetDecimal(3)   // Convertir de decimal a float
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
        }

        public bool UpdateJob(Job job)
        {
            string query = "UPDATE Jobs SET job_title = @JobTitle, min_salary = @MinSalary, max_salary = @MaxSalary WHERE job_id = @JobId";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Parámetros de la consulta
                    cmd.Parameters.AddWithValue("@JobId", job.JobId);
                    cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    cmd.Parameters.AddWithValue("@MinSalary", job.MinSalary);
                    cmd.Parameters.AddWithValue("@MaxSalary", job.MaxSalary);

                    // Ejecutar la consulta y verificar si se afectó alguna fila
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el Job: " + ex.Message);
                return false;
            }
        }
    }
}
