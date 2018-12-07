using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;
using Web_ProjetoCarfel.Repositorio;
using Web_ProjetoCarfel.Util;

namespace Web_ProjetoCarfel.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario usuarioLogado = null;
        /// <summary>
        /// Classe de validação de usuario  
        /// Usado para tratar qualquer erro
        /// </summary>
        private IValidacaoUsuario validacao = new ValidacaoUsuario();
    
        /// <summary>
        /// Classe que manuseia o banco de dados
        /// </summary>
        private IUsuario database = new UsuarioDatabaseSerializado();

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

            string mensagem = "";

            try{

                int id = database.Listar().Count + 1;
                string nome = form["Nome"]; 
                string email = form["Email"];
                string senha = form["Senha"];
                DateTime dataNascimento = DateTime.Parse(form["Data"]);

                if(!ValidacaoUsuario.Equals(email,form["CEmail"])){
                    mensagem = "O email confirmado não é igual ao registrado";
                }else{
                    if(!ValidacaoUsuario.Equals(senha,form["CSenha"])){
                        mensagem = "A senha inserida não é a igual a de confirmação";
                    }else{
                        Usuario usuario = new Usuario(id,nome,email,senha,dataNascimento);
                        mensagem = validacao.ValidarUsuario(usuario,database.Listar());

                        if(mensagem == $"Usuario {usuario.Nome} cadastrado com sucesso no id {usuario.ID} !"){
                            usuarioLogado = database.Cadastrar(usuario);
                        }
                    }
                }
            }catch(Exception erro){
                mensagem = $"Erro : \n {erro.Message} \n Contate o programador que fez isso e lhe de um socão nas costas ;-;";
            }finally{
                TempData["Mensagem"] = mensagem;
                Console.WriteLine($"{new string('-',mensagem.Length)}\n{mensagem}\n{new string('-',mensagem.Length)}");
            }
            return RedirectToAction("PaginaInicial");
        }
    }
}