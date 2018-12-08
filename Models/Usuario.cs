using System;
using System.IO;

namespace Web_ProjetoCarfel.Models
{
    [System.Serializable]
    public class Usuario
    {
        /// <summary>
        /// Define o ID do usuario  
        /// É unico e imutavel  
        /// </summary>
        public readonly int ID;
        /// <summary>
        /// Define o nome do usuario  
        /// Só pode ser alterado internamente  
        /// </summary>
        public string Nome{
            private set;
            get;
        }
        /// <summary>
        /// Define o email do usuario  
        /// Só pode ser alterado internamente  
        /// </summary>
        public string Email{
            private set;
            get;
        }
        /// <summary>
        /// Define o email do usuario  
        /// Só pode ser alterado internamente  
        /// </summary>
        public string Senha{
            private set;
            get;
        }
        /// <summary>
        /// Define a data de nascimento do usuario
        /// Só pode ser alterado internamente  
        /// </summary>
        public DateTime dataNascimento{
            private set;
            get;
        }
        /// <summary>
        /// Define a data de criação do perfil do usuario
        /// É imutavel e definido no momento que o objeto é criado
        /// </summary>
        public readonly DateTime dataCriacao;
        /// <summary>
        /// Define a foto de perfil do usuario  
        /// Será aleatorio kkk
        /// </summary>
        public string FotoPerfilNome;

        public readonly bool Admin;

        /// <summary> 
        /// Construtor da classe Usuario  
        /// Recebe os dados inseridos e cria um objeto do tipo Usuario
        /// </summary>
        /// <param name="ID">Define o id do usuario</param>
        /// <param name="Nome">Define o nome do usuario</param>
        /// <param name="Email">Define o email do usuario</param>
        /// <param name="Senha">Define a senha do usuario</param>
        /// <param name="dataNascimento">Define a data de nascimento do usuario</param>
        public Usuario(int ID,string Nome,string Email,string Senha,DateTime dataNascimento){
            this.ID = ID;
            this.Nome = Nome;
            this.Email = Email.ToLower();
            this.Senha = Senha;
            this.dataNascimento = dataNascimento;
            this.Admin = true;
            dataCriacao = DateTime.Now;
            FotoPerfilNome = "null-user.png";
        }
        
    }
}