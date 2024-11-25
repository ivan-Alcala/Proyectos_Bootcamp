using FormEmployeeDB.Class;
using Introduccion_ASP.NET_Core_MVC.Models;
using System.Data.SqlClient;

namespace Introduccion_ASP.NET_Core_MVC.DAL
{
    public class DALAnimal
    {
        private readonly DBConnect _dbConnect;

        public DALAnimal()
        {
            _dbConnect = new DBConnect();
        }

        public List<AnimalModel> GetAll()
        {
            var animales = new List<AnimalModel>();

            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = @"
                    SELECT 
                        a.IdAnimal, 
                        a.NombreAnimal, 
                        a.Raza, 
                        a.RIdTipoAnimal, 
                        a.FechaNacimiento, 
                        t.TipoDescripcion
                    FROM Animal a
                    INNER JOIN TipoAnimal t ON a.RIdTipoAnimal = t.IdTipoAnimal";

                using (var cmd = new SqlCommand(query, _dbConnect.connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        animales.Add(new AnimalModel
                        {
                            IdAnimal = reader.GetInt32(0),
                            NombreAnimal = reader.GetString(1),
                            Raza = reader.IsDBNull(2) ? null : reader.GetString(2),
                            RIdTipoAnimal = reader.GetInt32(3),
                            FechaNacimiento = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            TipoAnimal = new TipoAnimalModel
                            {
                                IdTipoAnimal = reader.GetInt32(3),
                                TipoDescripcion = reader.GetString(5)
                            }
                        });
                    }
                }
            });

            return animales;
        }

        public AnimalModel GetById(int id)
        {
            AnimalModel animal = null;

            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = @"
                    SELECT 
                        a.IdAnimal, 
                        a.NombreAnimal, 
                        a.Raza, 
                        a.RIdTipoAnimal, 
                        a.FechaNacimiento, 
                        t.TipoDescripcion
                    FROM Animal a
                    INNER JOIN TipoAnimal t ON a.RIdTipoAnimal = t.IdTipoAnimal
                    WHERE a.IdAnimal = @Id";

                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            animal = new AnimalModel
                            {
                                IdAnimal = reader.GetInt32(0),
                                NombreAnimal = reader.GetString(1),
                                Raza = reader.IsDBNull(2) ? null : reader.GetString(2),
                                RIdTipoAnimal = reader.GetInt32(3),
                                FechaNacimiento = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                                TipoAnimal = new TipoAnimalModel
                                {
                                    IdTipoAnimal = reader.GetInt32(3),
                                    TipoDescripcion = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            });

            return animal;
        }

        public void Create(AnimalModel animal)
        {
            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "INSERT INTO Animal (NombreAnimal, Raza, RIdTipoAnimal, FechaNacimiento) VALUES (@NombreAnimal, @Raza, @RIdTipoAnimal, @FechaNacimiento)";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@NombreAnimal", animal.NombreAnimal);
                    command.Parameters.AddWithValue("@Raza", (object)animal.Raza ?? DBNull.Value);
                    command.Parameters.AddWithValue("@RIdTipoAnimal", animal.RIdTipoAnimal);
                    command.Parameters.AddWithValue("@FechaNacimiento", (object)animal.FechaNacimiento ?? DBNull.Value);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void Update(AnimalModel animal)
        {
            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "UPDATE Animal SET NombreAnimal = @NombreAnimal, Raza = @Raza, RIdTipoAnimal = @RIdTipoAnimal, FechaNacimiento = @FechaNacimiento WHERE IdAnimal = @IdAnimal";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@NombreAnimal", animal.NombreAnimal);
                    command.Parameters.AddWithValue("@Raza", (object)animal.Raza ?? DBNull.Value);
                    command.Parameters.AddWithValue("@RIdTipoAnimal", animal.RIdTipoAnimal);
                    command.Parameters.AddWithValue("@FechaNacimiento", (object)animal.FechaNacimiento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void Delete(int id)
        {
            _dbConnect.ExecuteWithConnection(() =>
            {
                var query = "DELETE FROM Animal WHERE IdAnimal = @Id";
                using (var command = new SqlCommand(query, _dbConnect.connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            });
        }
    }
}
