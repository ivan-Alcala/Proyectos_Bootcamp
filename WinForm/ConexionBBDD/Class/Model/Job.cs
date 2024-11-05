using System;
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
    }
}
