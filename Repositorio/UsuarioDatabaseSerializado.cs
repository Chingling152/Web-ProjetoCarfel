using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;
using Web_ProjetoCarfel.Util;

namespace Web_ProjetoCarfel.Repositorio
{
    public class UsuarioDatabaseSerializado : IUsuario
    {
        /// <summary>
        /// Caminho onde será salvo\importado os usuarios
        /// </summary>
        private const string caminho = "Databases/Dados/Usuario.dat";

        /// <summary>
        /// Lista de usuarios salvos , só podem ser acessados atraves desta classe
        /// </summary>
        private List<Usuario> usuariosSalvos;

        /// <summary>
        /// Construtor da classe usuario 
        /// Verifica se existe um arquivo no caminho especificado e cria uma lista de usuarios  
        /// </summary>
        public UsuarioDatabaseSerializado(){
            bool existe = System.IO.File.Exists(caminho);
            //Console.WriteLine(existe);
            usuariosSalvos = existe?Listar():new List<Usuario>();
            Serializar();
            /*Usuario user = Procurar("1");
            Console.Write($"\nID : {user.ID}\nNome {user.Nome}\n{user.Email}\n{user.Admin}\n{user.Senha}\n{user.dataCriacao}\n{user.dataNascimento}\n");
            */
        }
        
        #region CRUM
        /// <summary>
        /// Valida o usuario 
        /// Se o usuario estiver com os valores validados 
        /// Ele é adicionado na lista de usuarios e serializado
        /// </summary>
        /// <param name="usuario">O Usuario a ser cadastrado</param>
        /// <returns>O Usuario cadastrado ou null se for invalido</returns>
        public Usuario Cadastrar(Usuario usuario)
        {           
            usuariosSalvos.Add(usuario);
            Serializar();
            return usuario;
        }
        /// <summary>
        /// Remove o usuario no id selecionado
        /// </summary>
        /// <param name="id">id a ser procurado</param>
        /// <returns>
        /// Retorna true se o usuario existir  
        /// Retorna false se o usuario não existir ou a id não existir
        /// </returns>
        public bool Excluir(string id){
            Usuario user = Procurar(id);

            if(user==null){
                return false;
            }else{
                usuariosSalvos.RemoveAt(ProcurarIndex(user));
                Serializar();
                return true;
            }

        }
        #endregion
        #region Procura
        /// <summary>
        /// Procura o usuario no ID selecionado
        /// </summary>
        /// <param name="id">ID do usuario a ser procurado</param>
        /// <returns>Retorna um usuario ou null caso o mesmo não exista</returns>
        public Usuario Procurar(string id){
            Usuario user = null;
            foreach (Usuario item in usuariosSalvos)
            {
                if(item.ID == int.Parse(id)){
                    user = item;
                    break;
                }
            }
            return user;
        }
        /// <summary>
        /// Procura o ID do usuario pela posição na lista
        /// </summary>
        /// <param name="usuario">O Usuario a ser procurado</param>
        /// <returns>O ID do usuario</returns>
        public int ProcurarIndex(Usuario usuario){
            int index = 0;

            foreach (Usuario item in usuariosSalvos)
            {
                if(usuario.ID == item.ID){
                    return index;
                }
                index ++;
            }
            return -1;
        }
        /// <summary>
        /// Substitui o usuario na lista de usuarios , baseando se no ID do novo usuario
        /// </summary>
        /// <param name="usuario">Novo usuario</param>
        /// <returns>Retonar o novo usuario</returns>
        public Usuario Editar(Usuario usuario)
        {
            int index = ProcurarIndex(usuario);
            usuariosSalvos.RemoveAt(index);
            usuariosSalvos.Insert(index,usuario);
            Serializar();
            return usuario;
        }
        #endregion
        
        #region Verificação
        /// <summary>
        /// Procura o usuario no banco de dados e retorna o mesmo tiver a combinação correta de senha e email
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>Retona o usuario logado , caso a combinação não exista retorna null</returns>
        public Usuario Logar(string email, string senha)
        {
            Usuario usuario = null;

            foreach (Usuario item in usuariosSalvos)
            {
                if(item.Email == email){
                    if(item.Senha == senha){
                        usuario = item;
                        break;
                    }
                }
            }

            return usuario;
        }
        #endregion

        #region Salvar e carregar
        /// <summary>
        /// Salva a lista de usuarios em um arquivo .dat
        /// </summary>
        private void Serializar()
        {
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializador = new BinaryFormatter();               
            serializador.Serialize(memoria,usuariosSalvos);
            File.WriteAllBytes(caminho,memoria.ToArray());
            usuariosSalvos = Listar();
        }
        /// <summary>
        /// Le todos os bites do arquivo .dat e retona-os em forma de uma lista de usuarios
        /// </summary>
        /// <returns>Retorna uma Lista de usuarios</returns>
        public List<Usuario> Listar()
        {   
            byte[] retorno = File.ReadAllBytes(caminho);//cria array de bytes e le o arquivo .dat
            MemoryStream memoria = new MemoryStream(retorno);//le a array de bytes e armazena na memoria
            BinaryFormatter deserializador = new BinaryFormatter(); //criar um fomatador de binarios para converter bytes em objeto
            return deserializador.Deserialize(memoria) as List<Usuario>;//retorna os bytes convertidos como uma lsita de usuarios
        }
        #endregion
    }
}