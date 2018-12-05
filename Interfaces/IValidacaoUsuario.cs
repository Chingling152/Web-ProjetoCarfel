using System;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IValidacaoUsuario
    {
        string ValidarUsuario(Usuario user,string caminho);
        bool EmailValido(string email,string caminho);
        bool DataValida(DateTime data);
        bool NomeValido(string nome);
    }
}