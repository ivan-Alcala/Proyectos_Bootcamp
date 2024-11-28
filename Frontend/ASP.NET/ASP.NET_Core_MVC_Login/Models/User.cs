namespace ASP.NET_Core_MVC_Login.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; } // For V1 and V2
        public byte[] PasswordHash { get; set; } // For V4
        public byte[] PasswordSalt { get; set; } // For V4
        public string Email { get; set; }
        public DateTime RecordDate { get; set; }
        public bool Activo { get; set; }
    }
}
