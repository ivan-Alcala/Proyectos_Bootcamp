using Introduccion_ASP.NET_Core_MVC.DAL;
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

        [HttpPost]
        public IActionResult AnimalDetail(int id)
        {
            return RedirectToAction("Details", "Animal", new { id });
        }
    }
}
