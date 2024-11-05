using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexionBBDD.Class.Model
{
    public class Job
    {
        public int JobId { get; set; } // job_id
        public string JobTitle { get; set; } // job_title
        public float MinSalary { get; set; } // min_salary
        public float MaxSalary { get; set; } // max_salary

        public bool AddJob(Job job, SqlConnection connection)
        {
            string query = "INSERT INTO Jobs (job_title, min_salary, max_salary) VALUES (@JobTitle, @MinSalary, @MaxSalary)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
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
        public List<Job> GetJobs(SqlConnection connection)
        {
            var jobs = new List<Job>();
            string query = "SELECT * FROM Jobs";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
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
    }
}
