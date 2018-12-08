namespace Web_ProjetoCarfel.Models
{
    public class Comentario
    {
        public readonly int ID;
        public readonly int IDUsuario;
        public string Comentario_;
        public bool Aprovado;
        public int Prioridade;
        public string Tipo;

        public Comentario(int ID,int IDUsuario,string Comentario_,int Prioridade,string Tipo){
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentario_ = Comentario_;
            this.Prioridade = Prioridade;
            this.Tipo = Tipo;
            this.Aprovado = false;
        }
    }
}