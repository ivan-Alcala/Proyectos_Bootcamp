namespace Introduccion_ASP.NET_Core_MVC.Models.ViewModel
{
    public class AnimalesViewModel
    {
        public List<AnimalModel> ListAnimal { get; set; } = new List<AnimalModel>();
        public List<TipoAnimalModel> ListTipoAnimal { get; set; } = new List<TipoAnimalModel>();
    }
}
