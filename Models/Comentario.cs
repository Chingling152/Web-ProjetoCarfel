using System;

namespace Web_ProjetoCarfel.Models
{
    [System.Serializable]
    public class Comentario
    {
        public readonly int ID;
        public readonly int IDUsuario;
        public readonly string Comentario_;
        public bool Aprovado;
        /// <summary>
        /// Um nivel de prioridade para o comentario vai de 0 a 10   
        /// Sendo 10 mais relevante e 0 menos relevante
        /// </summary>
        public DateTime DataCriacao;

        public Comentario(int ID,int IDUsuario,string Comentario_,bool Aprovado){
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentario_ = Comentario_;
            this.DataCriacao = DateTime.Now;
            this.Aprovado = Aprovado;
        }
    }
}