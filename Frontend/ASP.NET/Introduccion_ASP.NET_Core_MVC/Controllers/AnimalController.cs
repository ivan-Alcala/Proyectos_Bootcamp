using Introduccion_ASP.NET_Core_MVC.DAL;
using Introduccion_ASP.NET_Core_MVC.Models;
using Introduccion_ASP.NET_Core_MVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Introduccion_ASP.NET_Core_MVC.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            DALAnimal dALAnimal = new DALAnimal();
            DetailAnimalViewModel viewModel = new DetailAnimalViewModel();

            viewModel.AnimalDetail = dALAnimal.GetById(id);

            if (viewModel.AnimalDetail == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public ActionResult Add()
        {
            DALTipoAnimal _DALTipoAnimal = new DALTipoAnimal();

            AnimalesViewModel animalesViewModel = new AnimalesViewModel();

            if (animalesViewModel.ListTipoAnimal == null)
            {
                return NotFound();
            }

            animalesViewModel.ListTipoAnimal = _DALTipoAnimal.GetAll();
            return View(animalesViewModel);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animalToAdd)
        {
            DALAnimal dALAnimalToAdd = new DALAnimal();
            AnimalesViewModel animalesViewModel = new AnimalesViewModel();

            if (animalesViewModel.ListTipoAnimal == null)
            {
                return NotFound();
            }

            dALAnimalToAdd.Create(animalToAdd);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AnimalDetail(int id)
        {
            return RedirectToAction("Details", "Animal", new { id });
        }

        public IActionResult ShowAddAnimal()
        {
            return RedirectToAction("Add", "Animal");
        }
    }
}
