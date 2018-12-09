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
                    int prioridade = usuarioLogado.Admin? 5 : 1;
                    bool aprovado = usuarioLogado.Admin? true : false; 

                    Comentario novoComentario = new Comentario(id,usuario,comentario,prioridade,aprovado);

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
            ViewData["Lista"] = database.Listar();
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

        [HttpPost]
        public IActionResult Aprovar(int id){

            return RedirectToAction("Aprovar");
        }
    }
}