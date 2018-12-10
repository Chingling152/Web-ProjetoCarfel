namespace Web_ProjetoCarfel.Models
{
    [System.Serializable]
    public class Comentario
    {
        public readonly int ID;
        public readonly int IDUsuario;
        public readonly string Comentario_;
        public bool Aprovado;
        public System.DateTime DataCriacao;

        public Comentario(int ID,int IDUsuario,string Comentario_,bool Aprovado){
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentario_ = Comentario_;
            this.DataCriacao = System.DateTime.Now;
            this.Aprovado = Aprovado;
        }
    }
}