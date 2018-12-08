using System.Collections.Generic;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IComentario
    {
        Comentario Cadastrar(Comentario comentario);
        bool Aprovado(Comentario comentario);
        List<Comentario> ListarOrdenado();
        List<Comentario> ListarAprovados();
        List<Comentario> ListarRelevante();
        List<Comentario> ListarPorTipo(string Tipo);
        Comentario ProcurarPorID(string id);
        Comentario ProcurarPorUsuario(string id);
        List<Comentario> Listar();
        
    }
}