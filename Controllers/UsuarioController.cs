using Microsoft.AspNetCore.Mvc;
using Web_ProjetoCarfel.Repositorio;

namespace Web_ProjetoCarfel.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDatabaseSerializado database = new UsuarioDatabaseSerializado();

        [HttpGet]
        public IActionResult PaginaInicial(){
            @ViewBag.Titulo = "Pagina Inicial";
            return View();
        }
        [HttpGet]
        public IActionResult Contato(){
            @ViewBag.Titulo = "Contato";
            return View();
        }
        [HttpGet]
        public IActionResult Produto(){
            @ViewBag.Titulo = "Checkpoint";
            return View();
        }
        [HttpGet]
        public IActionResult PerguntasFrequentes(){
            @ViewBag.Titulo = "Perguntas frequentes";
            return View();
        }
        [HttpGet]
        public IActionResult SobreNos(){
            @ViewBag.Titulo = "Sobre nós";
            return View();
        }
    }
}