using Microsoft.AspNetCore.Mvc;

namespace Web_ProjetoCarfel.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult PaginaInicial(){
            return View();
        }
    }
}