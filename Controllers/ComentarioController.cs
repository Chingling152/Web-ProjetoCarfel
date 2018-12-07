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
        [HttpGet]
        public IActionResult Comentarios(){
            System.Console.WriteLine("\nTTTTTTTTT\n");
            return View();
        }
    }
}