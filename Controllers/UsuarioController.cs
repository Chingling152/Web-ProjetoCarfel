using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Repositorio;
using Web_ProjetoCarfel.Util;

namespace Web_ProjetoCarfel.Controllers
{
    public class UsuarioController : Controller
    {
        
        /// <summary>
        /// Classe de validação de usuario  
        /// Usado para tratar qualquer erro
        /// </summary>
        private IValidacaoUsuario validacao = new ValidacaoUsuarioSerializado();
    
        /// <summary>
        /// Classe que manuseia o banco de dados
        /// </summary>
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
        [HttpPost]
        public IActionResult Login(){
            return RedirectToAction("PaginaInicial");
        }
        [HttpPost]
        public IActionResult Registrar(IFormCollection form){
            int id = database.Listar().Count + 1;
            string nome = form["Nome"]; 
            string email = form["Email"];
            string senha = form["Senha"];
            return RedirectToAction("PaginaInicial");
        }
    }
}