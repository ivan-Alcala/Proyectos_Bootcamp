using Introduccion_ASP.NET_Core_MVC.DAL;
using Introduccion_ASP.NET_Core_MVC.Models;
using Introduccion_ASP.NET_Core_MVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpGet]
        public ActionResult Save(Animal animal)
        {
            DALTipoAnimal _DALTipoAnimal = new DALTipoAnimal();
            AnimalesViewModel animalesViewModel = new AnimalesViewModel();
            animalesViewModel.Animal = animal;

            if (animalesViewModel.ListTipoAnimal == null)
            {
                return NotFound();
            }

            animalesViewModel.ListTipoAnimal = _DALTipoAnimal.GetAll();
            return View(animalesViewModel);
        }

        [HttpPost]
        public IActionResult SaveAnimal(Animal animal)
        {
            DALAnimal dalAnimal = new DALAnimal();

            if (dalAnimal.GetById(animal.IdAnimal) != null)
                dalAnimal.Update(animal); // Actualizar si ya existe
            else
                dalAnimal.Create(animal); // Crear si es nuevo

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AnimalDetail(int id)
        {
            return RedirectToAction("Details", "Animal", new { id });
        }

        [HttpPost]
        public IActionResult ShowSaveAnimal(string AnimalJson)
        {
            var animal = new Animal();

            if (!string.IsNullOrEmpty(AnimalJson))
                animal = JsonSerializer.Deserialize<Animal>(AnimalJson); // Deserializar el JSON al objeto Animal

            return RedirectToAction("Save", "Animal", animal);
        }
    }
}
