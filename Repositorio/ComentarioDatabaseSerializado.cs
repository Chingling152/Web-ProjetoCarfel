using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Repositorio
{
    public class ComentarioDatabaseSerializado : IComentario
    {
        /// <summary>
        /// Define o caminho onde será salvo o banco de dados dos comentarios
        /// </summary>
        private const string caminho = "Databases/Dados/Comentarios.dat";

        /// <summary>
        /// Lista onde fica salvo todos os comentarios , só podem ser acessados atraves desta classe
        /// </summary>
        private List<Comentario> Comentarios;

        /// <summary>
        /// Construtor unico do database de comentarios  
        /// Verifica se existe um arquivo no caminho especificado e cria uma lista de comentarios
        /// </summary>
        public ComentarioDatabaseSerializado(){
            bool existe = System.IO.File.Exists(caminho);
            Comentarios = existe?Listar():new List<Comentario>();
            Serializar();
        }
        
        #region Alterações e Adições
            /// <summary>
            /// Cadastra o usuario no banco de dados
            /// </summary>
            /// <param name="comentario">Comentario a ser cadastrado no banco de dados</param>
            /// <returns>Retorna um objeto do tipo Comentario</returns>
            public Comentario Cadastrar(Comentario comentario){
                Comentarios.Add(comentario);
                Serializar();
                return comentario;
            }
            /// <summary>
            /// Seta o estado do comentario no ID selecionado para aprovado
            /// </summary>
            /// <param name="id">ID do comentario a ser aprovado</param>
            public void Aprovar(string id){
                int index = ProcurarIndex(int.Parse(id));
                if(!Comentarios[index].Aprovado){
                    Comentarios[index].Aprovado = true;
                    Serializar();
                }
            }
            /// <summary>
            /// Seta o estado do comentario no ID selecionado para Reprovado
            /// </summary>
            /// <param name="id">ID do comentario a ser reprovado</param>
            public void Reprovar(string id)
            {
                int index = ProcurarIndex(int.Parse(id));
                if(Comentarios[index].Aprovado){
                    Comentarios[index].Aprovado = false;
                    Serializar();
                }
            }
        #region Salvar e Carregar
            /// <summary>
            /// Pega a lista de comentarios e coverte ela em bytes  
            /// Depois salva em um arquivo .dat
            /// </summary>
            private void Serializar(){
                MemoryStream memoria = new MemoryStream();
                BinaryFormatter serializador = new BinaryFormatter();
                serializador.Serialize(memoria,Comentarios); 
                File.WriteAllBytes(caminho,memoria.ToArray());
                Comentarios = Listar();
            }
            /// <summary>
            /// Transforma todos os bytes do banco de dados em uma lista de comentarios
            /// </summary>
            /// <returns>Retorna uma lista de comentarios</returns>
            public List<Comentario> Listar(){
                byte[] bytes = File.ReadAllBytes(caminho);
                MemoryStream memoria = new MemoryStream(bytes);
                BinaryFormatter deserialisador = new BinaryFormatter();
                return deserialisador.Deserialize(memoria) as List<Comentario>;
            }
        #endregion
        #endregion
        #region Listar e Procura
            /// <summary>
            /// Procura um comentario que contenha o ID selecionado
            /// </summary>
            /// <param name="id">ID do comentario que será procurado</param>
            /// <returns>Retorna um objeto do tipo Comentario</returns> 
            public Comentario Procurar(string id)
            {
                int ID = int.Parse(id);
                Comentario tempComentario = null;
                foreach (Comentario item in Comentarios)
                {
                    if(item.ID == ID){
                        tempComentario = item;
                        break;
                    }
                }
                return tempComentario;
            }
            /// <summary>
            /// Procura um comentario que contenha o ID selecionado e retorna sua posição na Lista
            /// </summary>
            /// <param name="id">ID d usuario que será procurado</param>
            /// <returns>Indice do comentario na lista</returns>
            public int ProcurarIndex(int id){
                int contador = 0;
                foreach (Comentario item in Comentarios)
                {
                    if(item.ID == id){         
                        return contador;
                    }
                    contador ++;
                }
                return -1;
            }
            /// <summary>
            /// Percorre o banco de dados e retorna uma lista com todos os comentarios do Usuario selecionado
            /// </summary>
            /// <param name="userid"></param>
            /// <returns></returns>
            public List<Comentario> ProcurarPorUsuario(string userid)
            {
                List<Comentario> tempComentarios = new List<Comentario>();
                
                foreach (Comentario item in Comentarios)
                {
                    if(item.IDUsuario == int.Parse(userid)){
                        tempComentarios.Add(item);
                    }
                }
        
                return tempComentarios;
            }
            /// <summary>
            /// Procura no metodo listar todos os comentarios que forma aprovados  
            /// </summary>
            /// <returns>Retorna uma lista apenas com os comentarios aprovados pelo administrador</returns>
            public List<Comentario> ListarAprovados(){
                List<Comentario> Retorno = new List<Comentario>();

                foreach(Comentario comentario in Comentarios){
                    if(comentario.Aprovado){
                        Retorno.Add(comentario);
                    }
                }
                return Retorno;
            }
            /// <summary>
            /// Procura no metodo ListarAprovados todos os comentarios e os ordena em ordem cronologica (uuuu algoritmo magico)
            /// </summary>
            /// <returns>Retorna uma lista de comentarios ordenadas cronologicamente</returns>
            public List<Comentario> ListarOrdenado() => ListarAprovados().OrderByDescending(comment => comment.DataCriacao).ToList();
            /// <summary>
            /// Lista os primeiros comentarios aprovados 
            /// </summary>
            /// <returns></returns>
            public List<Comentario> ListarPrimeiros()
            {
                List<Comentario> Retorno = new List<Comentario>();
                for(int i = 0 ;i < 4 ;i++){
                    Comentario c = ListarOrdenado()[i];
                    if(c == null){
                        Retorno.Add(c);
                    }else{
                        break;
                    }
                    
                }
                return Retorno;
            }
        #endregion
    }
}

/*
𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼
█▀▀█ █▀▀█ █▀▀█ █ █
█░░█ █▄▄▀ █▄▄█ ▀ ▀
▀▀▀▀ ▀░▀▀ ▀░░▀ ▄ ▄
 */