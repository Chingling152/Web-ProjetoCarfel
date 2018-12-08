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


        public Usuario Procurar(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Aprovado(Comentario comentario)
        {
            throw new System.NotImplementedException();
        }


        public Comentario ProcurarPorID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Comentario ProcurarPorUsuario(string id)
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

        /// <summary>
        /// Retorna a lista de comentarios ordenado por mais relevancia primeiro
        /// </summary>
        /// <returns>O banco de dados porem com os comentarios ordenados por ordem de relevancia</returns>
        public List<Comentario> ListarRelevante(){
            List<Comentario> tempComentario = new List<Comentario>();
            for(int i = 10; i > 0;i++){
                foreach (Comentario item in Comentarios)
                {
                    if(item.Prioridade == i){
                        tempComentario.Add(item);
                    }
                }
            }
            return tempComentario;
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