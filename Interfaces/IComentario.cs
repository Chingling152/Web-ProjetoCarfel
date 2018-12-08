using System.Collections.Generic;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IComentario
    {
        Comentario Cadastrar(Comentario comentario);
        bool Aprovado(Comentario comentario);
        List<Comentario> Listar();
        List<Comentario> ListarOrdenado();
        List<Comentario> ListarAprovados();
        List<Comentario> ListarRelevante();
        List<Comentario> ListarPorTipo(string Tipo);
        Usuario Procurar(string id);
    }
}