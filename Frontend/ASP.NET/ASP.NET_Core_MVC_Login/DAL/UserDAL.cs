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

        // V2: Database Login con Hash
        public User GetUserLogin(string username, string password)
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

        // V3: SignUp metodos
        public bool CreateUser(User usuario)
        {
            try
            {
                _dbConnect.Connect();
                string query = @"INSERT INTO Usuario 
                    (UserName, Pwd, Email, FechaRegistro, Activo) 
                    VALUES (@Username, @Password, @Email, GETDATE(), 1)";

                using (SqlCommand cmd = new SqlCommand(query, _dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@Username", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Password", usuario.Pwd);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
            finally
            {
                _dbConnect.Disconnect();
            }
        }

        // V4: Secure Login with Salt & Hash
        public User GetSecureUsuarioLogin(string username)
        {
            User usuario = null;
            try
            {
                _dbConnect.Connect();
                string query = "SELECT * FROM Usuario WHERE UserName = @Username";

                using (SqlCommand cmd = new SqlCommand(query, _dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new User
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                PasswordHash = (byte[])reader["PasswordHash"],
                                PasswordSalt = (byte[])reader["PasswordSalt"]
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

        public bool CreateSecureUser(User usuario, byte[] passwordHash, byte[] passwordSalt)
        {
            try
            {
                _dbConnect.Connect();
                string query = @"INSERT INTO Usuario 
                    (UserName, PasswordHash, PasswordSalt, Email, FechaRegistro, Activo) 
                    VALUES (@Username, @PasswordHash, @PasswordSalt, @Email, GETDATE(), 1)";

                using (SqlCommand cmd = new SqlCommand(query, _dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@Username", usuario.UserName);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@PasswordSalt", passwordSalt);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
            finally
            {
                _dbConnect.Disconnect();
            }
        }
    }
}