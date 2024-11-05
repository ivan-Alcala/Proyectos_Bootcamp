using System;
using System.Data.SqlClient;

namespace ConexionBBDD.Class
{
    public class BBDDConnect
    {
        public SqlConnection connection;

        // Constructor que configura la cadena de conexión
        public BBDDConnect()
        {
            // Configuración de la cadena de conexión
            var connectionString = "Data Source=85.208.21.117,54321;Initial Catalog=IvanBDEmployee;User ID=sa;Password=Sql#123456789";
            connection = new SqlConnection(connectionString);
        }

        // Método para conectar a la base de datos
        public bool Connect()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    return true; // Conexión exitosa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
            return false; // Fallo en la conexión
        }

        // Método para desconectar de la base de datos
        public void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Método para verificar el estado de la conexión
        public bool IsConnected()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }
    }
}
