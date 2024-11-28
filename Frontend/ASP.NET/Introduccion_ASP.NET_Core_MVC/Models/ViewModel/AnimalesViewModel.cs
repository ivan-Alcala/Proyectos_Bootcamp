namespace Introduccion_ASP.NET_Core_MVC.Models.ViewModel
{
    public class AnimalesViewModel
    {
        public List<Animal> ListAnimal { get; set; } = new List<Animal>();
        public List<TipoAnimalModel> ListTipoAnimal { get; set; } = new List<TipoAnimalModel>();
        public Animal Animal { get; set; } = new Animal();
    }
}
