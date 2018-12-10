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
        public static Usuario usuarioLogado = null;
    
        /// <summary>
        /// Classe que manuseia o banco de dados do usuario
        /// </summary>
        public static IUsuario database = new UsuarioDatabaseSerializado();

        [HttpGet]
        public IActionResult PaginaInicial(){
            @ViewBag.Titulo = "Pagina Inicial";
            ViewData["Usuario"] = usuarioLogado;
            ViewData["Lista"] = ComentarioController.database.ListarPrimeiros();
            //ComentarioController.database
            return View();
        }
        [HttpGet]
        public IActionResult Contato(){
            @ViewBag.Titulo = "Contato";
            ViewData["Usuario"] = usuarioLogado;
            return View();
        }
        [HttpGet]
        public IActionResult Produto(){
            @ViewBag.Titulo = "Checkpoint";
            ViewData["Usuario"] = usuarioLogado;
            return View();
        }
        [HttpGet]
        public IActionResult PerguntasFrequentes(){
            @ViewBag.Titulo = "Perguntas frequentes";
            ViewData["Usuario"] = usuarioLogado;
            return View();
        }
        [HttpGet]
        public IActionResult SobreNos(){
            ViewData["Usuario"] = usuarioLogado;
            @ViewBag.Titulo = "Sobre nós";
            return View();
        }
        [HttpGet]
        public IActionResult Logoff(){
            usuarioLogado = null;
            @TempData["Mensagem"] = "Você foi deslogado com sucesso";
            return RedirectToAction("PaginaInicial","Usuario");
        }
        [HttpGet]
        public IActionResult Perfil(string id){
            Usuario user = database.Procurar(id);
            
            if(user == null){
                TempData["Mensagem"] = "Esse perfil não existe";
                return RedirectToAction("Pagina Inicial");
            }else{
                ViewData["Usuario"] = usuarioLogado;
                ViewData["Dono"] = user;
                @ViewBag.Titulo = $"Perfil de {user.Nome}";
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form){
            string mensagem = "";

            if(usuarioLogado == null){// se não houver ninguem logado
                string email = form["Email"].ToString().ToLower();
                string senha = form["Senha"];

                Usuario usuario = database.Logar(email,senha);

                if(usuario != null){//se o retorno do database.Login não for nulo , ou seja ... se houver um usuario com essa combinação de email\senha
                    mensagem = $"Seja bem vindo {usuario.Nome}";
                    usuarioLogado = usuario;
                }else{
                    mensagem = "Email e senha incorretos ou invalidos"; 
                         
                }
                //Console.WriteLine($"\n {usuarioLogado.Nome} \n");
                ViewData["Usuario"] = usuarioLogado;    
            }else{
                mensagem = "Você já está logado";
            }

            if(usuarioLogado != null){
                TempData["Mensagem"] = mensagem;
                return RedirectToAction("Perfil","Usuario",new{id = usuarioLogado.ID});
            }else{
                TempData["Mensagem"] = mensagem;
                return RedirectToAction("PaginaInicial","Usuario");
            }
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
                string foto = UsuarioDatabaseSerializado.fotos[new Random().Next(UsuarioDatabaseSerializado.fotos.Count)];

                if(!ValidacaoUsuario.Equals(email,form["CEmail"])){
                    mensagem = "O email confirmado não é igual ao registrado";
                }else{
                    if(!ValidacaoUsuario.Equals(senha,form["CSenha"])){
                        mensagem = "A senha inserida não é a igual a de confirmação";
                    }else{
                        Usuario usuario = new Usuario(id,nome,email,senha,dataNascimento,foto);
                        mensagem = ValidacaoUsuario.ValidarUsuario(usuario,database.Listar());

                        if(mensagem == $"Usuario {usuario.Nome} cadastrado com sucesso no id {usuario.ID} !"){
                            usuarioLogado = database.Cadastrar(usuario);
                        }
                    }
                }
            }catch(Exception erro){
                mensagem = $"Erro : \n {erro.Message} \n Contate o programador que fez isso e lhe de um socão nas costas ;-;";
            }finally{
                TempData["Mensagem"] = mensagem;
                //Console.WriteLine($"{new string('-',mensagem.Length)}\n{mensagem}\n{new string('-',mensagem.Length)}");
            }
            return RedirectToAction("PaginaInicial");
        }

        [HttpGet]
        public IActionResult Mostrar(){
            ViewData["Lista"] = database.Listar();
            return View();
        }
    }
}