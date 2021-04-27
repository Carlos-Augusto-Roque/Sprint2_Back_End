using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagenRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar um novo personagem
        /// </summary>
        /// <param name="personagen">objeto habilidade a ser criado</param>
        void Cadastrar(Personagen personagen);

        /// <summary>
        /// Listar os personagens 
        /// </summary>
        /// <returns>lista dos personagens</returns>
        List<Personagen> Listar();

        /// <summary>
        /// Buscar um personagem pelo seu id
        /// </summary>
        /// <param name="id">id do personagem a ser buscada</param>
        /// <returns>personagem buscada</returns>
        Personagen BuscarPorId(int id);

        /// <summary>
        /// Atualizar um personagem existente 
        /// </summary>
        /// <param name="id">id do personagem a ser atualizado</param>
        /// <param name="personagen">objeto personagem com as novas informações</param>
        void Atualizar(int id, Personagen personagen);

        /// <summary>
        /// Deleta uma personagem existente
        /// </summary>
        /// <param name="id">id do personagem a ser deletada</param>
        void Deletar(int id);
    }
}
