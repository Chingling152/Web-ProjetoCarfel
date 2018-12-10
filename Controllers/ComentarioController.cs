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
        private static Usuario usuarioLogado = null;
        /// <summary>
        /// Classe que manuseia o banco de dados dos comentarios
        /// </summary>
        public static IComentario database = new ComentarioDatabaseSerializado();

        [HttpGet]
        public IActionResult Comentarios(){
            usuarioLogado = UsuarioController.usuarioLogado;

            ViewData["Lista"] = database.Listar();
            ViewData["Usuario"] = usuarioLogado;
            ViewBag.Titulo = "Comentarios";
            return View();
        }

        [HttpPost]
        public IActionResult Comentarios(IFormCollection form){
            string mensagem = "";
            try{
                if(usuarioLogado != null){
                    int id = database.Listar().Count + 1;
                    int usuario = usuarioLogado.ID;
                    string comentario = form["Comment"];
                    bool aprovado = usuarioLogado.Admin? true : false; 

                    Comentario novoComentario = new Comentario(id,usuario,comentario,aprovado);

                    database.Cadastrar(novoComentario);
                    mensagem = aprovado ? "Seu comentario foi enviado com sucesso":"Seu comentario foi enviado com sucesso e aguarda aprovação";
                }else{
                    if(usuarioLogado.ID == 0){
                        mensagem = "Você precisa estar logado para fazer um comentario...";
                        return RedirectToAction("PaginaInicial","Usuario");
                    }
                }
            }catch(Exception exc){
                mensagem = $"Ops ;-; alguma merda aconteceu por debaixo dos panos....\n {exc.Message}";
            }
            ViewData["Lista"] = database.ListarAprovados();
            ViewData["Usuario"] = usuarioLogado;
            TempData["Mensagem"] = mensagem;
            return View();
        }
        [HttpGet]
        public IActionResult Aprovar(){
            ViewData["Lista"] = database.Listar();
            ViewBag.Titulo = "Aprovação de comentarios";
            return View();
        }

        [HttpGet]
        public IActionResult AprovarComentario(int id){
            database.Aprovar(id.ToString());
            ViewData["Lista"] = database.Listar();
            return RedirectToAction("Aprovar");
        }

        [HttpGet]
        public IActionResult ReprovarComentario(int id){
            database.Reprovar(id.ToString());
            ViewData["Lista"] = database.Listar();
            return RedirectToAction("Aprovar");
        }
    }
}