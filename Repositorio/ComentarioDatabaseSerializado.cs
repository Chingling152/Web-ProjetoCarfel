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

        public bool Aprovado(Comentario comentario)
        {
            throw new System.NotImplementedException();
        }

        public List<Comentario> ListarOrdenado()
        {
            throw new System.NotImplementedException();
        }

        public List<Comentario> ListarPorTipo(string Tipo)
        {
            throw new System.NotImplementedException();
        }
    }
}