using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;
using System.Security.Claims;
using Models.Login;

namespace CrudLogin8.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IAuthService _authService;

        public AccesoController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM modelo)
        {
            try
            {
                await _authService.RegisterUser(modelo);
                return RedirectToAction("Login", "Acceso");
            }
            catch (ArgumentException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
            catch (Exception)
            {
                ViewData["Mensaje"] = "No se puede crear el usuario, error fatal";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Lista", "Empleado");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuario? usuario_encontrado = await _authService.AuthenticateUser(modelo.Correo, modelo.Clave);

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Lista", "Empleado");
        }

       


    }
}
