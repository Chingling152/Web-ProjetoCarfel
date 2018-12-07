using System;
using System.Collections.Generic;
using Web_ProjetoCarfel.Interfaces;
using Web_ProjetoCarfel.Models;

namespace Web_ProjetoCarfel.Util
{
    public class ValidacaoUsuario: IValidacaoUsuario
    {
        /// <summary>
        /// Verifica se a data atual subtraida poela data inserida fica entre 18 e 100
        /// </summary>
        /// <param name="data">Data de nascimento do usuario</param>
        /// <returns>Retorna true se o usuario tiver a idade maior ou igual a 18</returns>
        public bool DataValida(DateTime data)
        {
            DateTime agora = DateTime.Now;
            int idade = agora.Year - data.Year;
            if(idade < 18 || idade >= 100){
                return false;
            }else{
                if(idade == 18 && agora.Month > data.Month && agora.Day > data.Day){
                    return false;
                }else{
                    return true;
                }
            }
        }

        /// <summary>
        /// Percorre todo o banco de dados e verifica se há um email igual ao inserido
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="database">Database onde estão todos os emails</param>
        /// <returns>Retorna true se não houver nenhum email igual ao inserido registrado</returns>
        public bool EmailValido(string email, List<Usuario> database)
        {
            foreach (Usuario item in database)
            {
                if(item.Email == email){
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Verifica se o nome 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool NomeValido(string nome)
        {
            if(nome.Length > 80){
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metodo principal
        /// ----------------
        /// Verifica todos os metodos da classe e retorna uma string com resultados
        /// </summary>
        /// <param name="user">Usuario a ser validado</param>
        /// <param name="database">Banco de dados</param>
        /// <returns>Retorna uma string com uma mensagem</returns>
        public string ValidarUsuario(Usuario user, List<Usuario> database)
        {
            if(!NomeValido(user.Nome)){
                return "Nome invalido !";
            }
            if(!EmailValido(user.Email,database)){
                return "Email invalido ou em uso !";
            }
            if(!DataValida(user.dataNascimento)){
                return "Idade invalida !";
            }
            return $"Usuario {user.Nome} cadastrado com sucesso no id {user.ID} !";
        }

        /// <summary>
        /// Verifica se 2 strings são iguais
        /// </summary>
        /// <returns>Retorna true se ambas strings forem iguais</returns>
        public static bool Equals(string obj, string obj2){
            if(obj == obj2){
                return true;
            }else{
                return false;
            }
        }
    }
}