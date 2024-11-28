using Introduccion_ASP.NET_Core_MVC.DAL;
using Introduccion_ASP.NET_Core_MVC.Models;
using Introduccion_ASP.NET_Core_MVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Introduccion_ASP.NET_Core_MVC.Controllers
{
    public class AnimalManagementController : Controller
    {
        private readonly DALAnimal _dalAnimal;
        private readonly DALTipoAnimal _dalTipoAnimal;

        public AnimalManagementController()
        {
            _dalAnimal = new DALAnimal();
            _dalTipoAnimal = new DALTipoAnimal();
        }

        public IActionResult Index()
        {
            AnimalesViewModel viewModel = new AnimalesViewModel
            {
                ListAnimal = _dalAnimal.GetAll(),
                ListTipoAnimal = _dalTipoAnimal.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveAnimals([FromBody] List<Animal> animals)
        {
            try
            {
                foreach (var animal in animals)
                {
                    if (animal.IdAnimal == 0)
                    {
                        // Create new animal
                        _dalAnimal.Create(animal);
                    }
                    else
                    {
                        // Update existing animal
                        _dalAnimal.Update(animal);
                    }
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeleteAnimals([FromBody] List<int> animalIds)
        {
            try
            {
                foreach (var id in animalIds)
                {
                    _dalAnimal.Delete(id);
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAnimalTypes()
        {
            var animalTypes = _dalTipoAnimal.GetAll();
            return Json(animalTypes);
        }
    }
}