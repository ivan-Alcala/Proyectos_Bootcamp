using FormEmployeeDB.Class;
using Introduccion_ASP.NET_Core_MVC.Models;
using System.Data.SqlClient;

namespace Introduccion_ASP.NET_Core_MVC.DAL
{
    public class DALTipoAnimal
    {

        private readonly DBConnect _dbConnect;

        public DALTipoAnimal()
        {
            _dbConnect = new DBConnect();
        }

        public List<TipoAnimalModel> GetAll()
        {
            var tipoAnimales = new List<TipoAnimalModel>();

            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "SELECT IdTipoAnimal, TipoDescripcion FROM TipoAnimal";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipoAnimales.Add(new TipoAnimalModel
                        {
                            IdTipoAnimal = reader.GetInt32(0),
                            TipoDescripcion = reader.GetString(1)
                        });
                    }
                }
            });

            return tipoAnimales;
        }

        public TipoAnimalModel GetById(int id)
        {
            TipoAnimalModel tipoAnimal = null;

            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "SELECT IdTipoAnimal, TipoDescripcion FROM TipoAnimal WHERE IdTipoAnimal = @Id";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipoAnimal = new TipoAnimalModel
                            {
                                IdTipoAnimal = reader.GetInt32(0),
                                TipoDescripcion = reader.GetString(1)
                            };
                        }
                    }
                }
            });

            return tipoAnimal;
        }

        public void Create(TipoAnimalModel tipoAnimal)
        {
            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "INSERT INTO TipoAnimal (TipoDescripcion) VALUES (@TipoDescripcion)";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@TipoDescripcion", tipoAnimal.TipoDescripcion);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void Update(TipoAnimalModel tipoAnimal)
        {
            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "UPDATE TipoAnimal SET TipoDescripcion = @TipoDescripcion WHERE IdTipoAnimal = @Id";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@TipoDescripcion", tipoAnimal.TipoDescripcion);
                    command.Parameters.AddWithValue("@Id", tipoAnimal.IdTipoAnimal);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void Delete(int id)
        {
            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "DELETE FROM TipoAnimal WHERE IdTipoAnimal = @Id";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            });
        }
    }
}
