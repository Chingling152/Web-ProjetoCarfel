namespace Web_ProjetoCarfel.Models
{
    public class Comentario
    {
        public readonly int ID;
        public readonly int IDUsuario;
        public string Comentario_;
        public bool Rejeitado;
        public int Prioridade;

        public Comentario(int ID,int IDUsuario,string Comentario_,int Prioridade){
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentario_ = Comentario_;
            this.Prioridade = Prioridade;
            this.Rejeitado = false;
        }
    }
}