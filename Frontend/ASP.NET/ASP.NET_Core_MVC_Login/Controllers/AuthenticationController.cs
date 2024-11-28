﻿using ASP.NET_Core_MVC_Login.DAL;
using ASP.NET_Core_MVC_Login.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Login.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserDAL _userDAL;
        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _userDAL = new UserDAL();
        }

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

            if (_userDAL.ValidateUserHardcoded(model.Username, model.Password))
            {
                // Set session
                HttpContext.Session.SetString("Username", model.Username);
                HttpContext.Session.SetString("LoginVersion", "V1");

                // Redirect to welcome page
                ViewBag.Username = model.Username;
                return View("Welcome");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        // V2: Database Login
        [HttpGet]
        public IActionResult LoginV2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginV2(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = _userDAL.GetUsuarioLogin(model.Username, model.Password);
            if (usuario != null)
            {
                // Set session
                HttpContext.Session.SetString("Username", usuario.UserName);
                HttpContext.Session.SetString("LoginVersion", "V2");

                // Redirect to welcome page
                ViewBag.Username = usuario.UserName;
                return View("Welcome");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
    }
}
