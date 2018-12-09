using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Cadastra o usuario no banco de dados
        /// </summary>
        /// <param name="comentario">Comentario a ser cadastrado no banco de dados</param>
        /// <returns></returns>
        public Comentario Cadastrar(Comentario comentario)
        {
            Comentarios.Add(comentario);
            Serializar();
            return comentario;
        }

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

        public bool Aprovar(string id)
        {
            int index = ProcurarIndex(int.Parse(id));
            if(!Comentarios[index].Aprovado){
                Comentarios[index].Aprovado = true;
                return true;
            }else{
                return false;
            }
        }

        public Comentario ProcurarPorUsuario(string userid)
        {
            throw new System.NotImplementedException();
        }
        private void Serializar(){
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializador = new BinaryFormatter();
            serializador.Serialize(memoria,Comentarios);//serializa os objetos do tipo memoria 
            File.WriteAllBytes(caminho,memoria.ToArray());
            Comentarios = Listar();
        }
        public List<Comentario> Listar(){
            byte[] bytes = File.ReadAllBytes(caminho);
            MemoryStream memoria = new MemoryStream(bytes);
            BinaryFormatter deserialisador = new BinaryFormatter();
            return deserialisador.Deserialize(memoria) as List<Comentario>;
        }
        
        /// <summary>
        /// Procura no metodo listar todos os usuario  
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

        public List<Comentario> ListarOrdenado(){
            List<Comentario> tempComentario = new List<Comentario>();
            return tempComentario;
        }

        public List<Comentario> ListarPorTipo(string Tipo){
            throw new System.NotImplementedException();
        }

    }
}

/*
𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼𝙊𝙍𝘼
█▀▀█ █▀▀█ █▀▀█ █ █
█░░█ █▄▄▀ █▄▄█ ▀ ▀
▀▀▀▀ ▀░▀▀ ▀░░▀ ▄ ▄
 */