using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="tipo">objeto tipo a ser cadastrada</param>
        void Cadastrar(TiposUsuario tipo);

        /// <summary>
        /// Listar os tipos de usuários
        /// </summary>
        /// <returns>lista dos tipos dos usuarios</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Buscar um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">id do tipo de usuário a ser buscado</param>
        /// <returns>tipo do usuario buscado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Atualizar um tipo de usuário existente 
        /// </summary>
        /// <param name="id">id do tipo de usuário a ser atualizado</param>
        /// <param name="tipo">objeto tipo com as novas informações</param>
        void Atualizar(int id, TiposUsuario tipo);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">id do tipo de usuario a ser deletado</param>
        void Deletar(int id);
    }
}
