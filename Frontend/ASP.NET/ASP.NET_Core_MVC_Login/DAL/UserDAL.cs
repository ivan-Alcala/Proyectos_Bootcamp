using ASP.NET_Core_MVC_Login.Models;
using System.Data.SqlClient;

namespace ASP.NET_Core_MVC_Login.DAL
{
    public class UserDAL
    {
        private readonly DBConnect _dbConnect;

        public UserDAL()
        {
            _dbConnect = new DBConnect();
        }

        // V1: Hardcoded Login
        public bool ValidateUserHardcoded(string username, string password)
        {
            return username == "user" && password == "123";
        }

        // V2: Database Login without Hash
        public User GetUsuarioLogin(string username, string password)
        {
            User usuario = null;
            try
            {
                _dbConnect.Connect();
                string query = "SELECT * FROM Usuario WHERE UserName = @Username AND Pwd = @Password";

                using (SqlCommand cmd = new SqlCommand(query, _dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new User
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
            }
            finally
            {
                _dbConnect.Disconnect();
            }
            return usuario;
        }
    }
}