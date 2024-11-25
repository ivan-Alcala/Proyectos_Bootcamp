using Introduccion_ASP.NET_Core_MVC.DAL;

namespace Introduccion_ASP.NET_Core_MVC.Models.ViewModel
{
    public class AnimalesViewModel
    {
        public List<string> Animales { get; set; } = new List<string>();

        public AnimalesViewModel()
        {
            DALAnimal dALAnimal = new DALAnimal();

            foreach (var item in dALAnimal.GetAll())
            {
                Animales.Add(item.NombreAnimal);
            }
        }
    }
}
