using System.Collections.Generic;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IUsuario
    {
        Usuario Cadastrar(Usuario usuario);
        bool Excluir(string id);
        Usuario Editar(Usuario usuario);
        List<Usuario> Listar();
        Usuario Procurar(string id);
        Usuario Logar(string email,string senha);
    } 
}