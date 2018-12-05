using System;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Util
{
    public class ValidacaoUsuarioSerializado : IValidacaoUsuario
    {
        public bool DataValida(DateTime data)
        {
            throw new NotImplementedException();
        }

        public bool EmailValido(string email, string caminho)
        {
            throw new NotImplementedException();
        }

        public bool NomeValido(string nome)
        {
            throw new NotImplementedException();
        }

        public string ValidarUsuario(Usuario user, string caminho)
        {
            throw new NotImplementedException();
        }
    }
}