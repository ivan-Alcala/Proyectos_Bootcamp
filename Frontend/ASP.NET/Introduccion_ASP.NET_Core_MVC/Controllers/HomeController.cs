using Introduccion_ASP.NET_Core_MVC.DAL;
using Introduccion_ASP.NET_Core_MVC.Models;
using Introduccion_ASP.NET_Core_MVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Introduccion_ASP.NET_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AnimalesViewModel animalesViewModel = new AnimalesViewModel();
            DALAnimal _DALAnimal = new DALAnimal();
            DALTipoAnimal _DALTipoAnimal = new DALTipoAnimal();

            animalesViewModel.ListAnimal = _DALAnimal.GetAll();
            animalesViewModel.ListTipoAnimal = _DALTipoAnimal.GetAll();
            return View(animalesViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
