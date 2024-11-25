namespace Introduccion_ASP.NET_Core_MVC.Models
{
    public class AnimalModel
    {
        public int IdAnimal { get; set; }
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public int RIdTipoAnimal { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public TipoAnimalModel TipoAnimal { get; set; }
    }
}
