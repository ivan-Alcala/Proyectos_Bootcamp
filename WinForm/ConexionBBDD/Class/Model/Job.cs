namespace ConexionBBDD.Class.Model
{
    public class Job
    {
        public int JobId { get; set; } // job_id
        public string JobTitle { get; set; } // job_title
        public decimal? MinSalary { get; set; } // min_salary
        public decimal? MaxSalary { get; set; } // max_salary

        public Job(int jobId, string jobTitle, decimal? minSalary, decimal? maxSalary)
        {
            JobId = jobId;
            JobTitle = jobTitle;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }

        public Job(string jobTitle, decimal? minSalary, decimal? maxSalary)
        {
            JobTitle = jobTitle;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }
    }
}
