using ASP.NET_Core_MVC_Login.DAL;
using ASP.NET_Core_MVC_Login.Models;
using ASP.NET_Core_MVC_Login.Models.ViewModel;
using ASP.NET_Core_MVC_Login.Tools;
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

            var usuario = _userDAL.GetUserLogin(model.Username, model.Password);
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

        // V3: Login con SignUp
        [HttpGet]
        public IActionResult LoginV3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginV3(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = _userDAL.GetUserLogin(model.Username, model.Password);
            if (usuario != null)
            {
                // Set session
                HttpContext.Session.SetString("Username", usuario.UserName);
                HttpContext.Session.SetString("LoginVersion", "V3");

                // Redirect to welcome page
                ViewBag.Username = usuario.UserName;
                return View("Welcome");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUpV3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpV3(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.Username,
                Pwd = model.Password,
                Email = model.Email
            };

            if (_userDAL.CreateUser(user))
            {
                return RedirectToAction("LoginV3");
            }

            ModelState.AddModelError("", "Error creating user");
            return View(model);
        }

        // V4: Secure Login with Salt & Hash
        [HttpGet]
        public IActionResult LoginV4()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginV4(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = _userDAL.GetSecureUsuarioLogin(model.Username);
            if (usuario != null &&
                PasswordHelper.VerifyPasswordHash(model.Password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                // Set session
                HttpContext.Session.SetString("Username", usuario.UserName);
                HttpContext.Session.SetString("LoginVersion", "V4");

                // Redirect to welcome page
                ViewBag.Username = usuario.UserName;
                return View("Welcome");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUpV4()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpV4(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create password hash and salt
            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);

            var usuario = new User
            {
                UserName = model.Username,
                Email = model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            if (_userDAL.CreateSecureUser(usuario, passwordHash, passwordSalt))
            {
                // Redirect to login
                return RedirectToAction("LoginV4");
            }

            ModelState.AddModelError("", "Error creating user");
            return View(model);
        }

        // Logout action for all versions
        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();

            // Redirect to home page
            return RedirectToAction("Index", "Home");
        }

        // Welcome page
        public IActionResult Welcome()
        {
            // Check if user is logged in
            string username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("LoginV1"); // Default to V1 login
            }

            ViewBag.Username = username;
            return View();
        }
    }
}
