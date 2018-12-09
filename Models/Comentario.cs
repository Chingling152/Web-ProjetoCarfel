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
        public int Prioridade;
        //public readonly string Tipo;

        public Comentario(int ID,int IDUsuario,string Comentario_,int Prioridade,bool Aprovado){
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentario_ = Comentario_;
            this.Prioridade = Prioridade > 10 || Prioridade < 0? 0 : Prioridade ;
            this.Aprovado = Aprovado;
        }
    }
}