using ASP.NET_Core_MVC_Login.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Login.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly string usernameHC = "admin";
        private readonly string passwordHC = "123";

        public IActionResult Index()
        {
            return View();
        }

        // V1: Hardcoded Login
        [HttpGet]
        public IActionResult LoginV1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginV1(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (usernameHC.Equals(model.Username) && passwordHC.Equals(model.Password))
            {
                // Guardos credenciales en la sesión
                HttpContext.Session.SetString("Username", model.Username);
                HttpContext.Session.SetString("LoginVersion", "V1");
                ViewBag.Username = model.Username;

                return View("Welcome");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
    }
}
