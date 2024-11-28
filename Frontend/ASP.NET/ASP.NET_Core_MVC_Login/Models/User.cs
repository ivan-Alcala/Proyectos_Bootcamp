namespace ASP.NET_Core_MVC_Login.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; } // For V1 and V2
        public string Email { get; set; }
        public DateTime RecordDate { get; set; }
        public bool Activo { get; set; }
    }
}
