using System.Collections.Generic;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Interfaces
{
    public interface IComentario
    {
        Comentario Cadastrar(Comentario comentario);
        bool Aprovar(string id);
        List<Comentario> ListarOrdenado();
        List<Comentario> ListarAprovados();
        List<Comentario> ListarPorTipo(string Tipo);
        Comentario Procurar(string id);
        int ProcurarIndex(int id);
        Comentario ProcurarPorUsuario(string id);
        List<Comentario> Listar();
        
    }
}