using System;
using System.Collections.Generic;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IValidacaoUsuario
    {
        string ValidarUsuario(Usuario user,List<Usuario> database);
        bool EmailValido(string email,List<Usuario> database);
        bool DataValida(DateTime data);
        bool NomeValido(string nome);
        bool SenhaValida(string senha);
    }
}