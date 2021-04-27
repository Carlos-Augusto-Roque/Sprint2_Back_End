using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">objeto usuário a ser cadastrada</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Listar os usuários
        /// </summary>
        /// <returns>lista dos usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Buscar um usuário pelo seu id
        /// </summary>
        /// <param name="id">id do usuário a ser buscado</param>
        /// <returns>usuario buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Atualizar um usuário existente 
        /// </summary>
        /// <param name="id">id do usuário a ser atualizado</param>
        /// <param name="usuario">objeto usuario com as novas informações</param>
        void Atualizar(int id, Usuario usuario);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">id do usuario a ser deletado</param>
        void Deletar(int id);

        Usuario BuscarPorEmailSenha(string email, string senha);
        
    }
}
