namespace Web_ProjetoCarfel.Models
{
    public class Comentario
    {
        public readonly int ID;
        public readonly int IDUsuario;
        public string Comentario_;

        public Comentario(int ID,int IDUsuario,string Comentario_){
            this.ID = ID;
            this.IDUsuario = IDUsuario;
            this.Comentario_ = Comentario_;
        }
    }
}