using System.Collections.Generic;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Repositorio
{
    public class ComentarioDatabaseSerializado : IComentario
    {
        public Comentario Cadastrar(Comentario comentario)
        {
            throw new System.NotImplementedException();
        }

        public List<Comentario> Listar()
        {
            throw new System.NotImplementedException();
        }

        public List<Comentario> ListarAprovados()
        {
            throw new System.NotImplementedException();
        }

        public List<Comentario> ListarRelevante()
        {
            throw new System.NotImplementedException();
        }

        public Usuario Procurar(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Reprovar(Comentario comentario)
        {
            throw new System.NotImplementedException();
        }
    }
}