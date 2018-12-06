using System.Collections.Generic;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IComentario
    {
        Comentario Cadastrar(Comentario comentario);
        bool Reprovar(Comentario comentario);
        List<Comentario> Listar();
        List<Comentario> ListarAprovados();
        List<Comentario> ListarRelevante();
        Usuario Procurar(string id);
    }
}