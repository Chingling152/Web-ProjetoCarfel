using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;
using Web_ProjetoCarfel.Repositorio;
using Web_ProjetoCarfel.Util;


namespace Web_ProjetoCarfel.Controllers
{
    public class ComentarioController : Controller
    {
        /// <summary>
        /// Classe que manuseia o banco de dados dos comentarios
        /// </summary>
        private IComentario database = new ComentarioDatabaseSerializado();

        [HttpGet]
        public IActionResult Comentarios(){
            ViewData["Lista"] = database.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Comentarios(IFormCollection form){
            
            return View();
        }
    }
}