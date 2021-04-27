using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClassRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar uma nova classe
        /// </summary>
        /// <param name="classe">objeto tipo a ser cadastrada</param>
        void Cadastrar(Class classe);

        /// <summary>
        /// Listar as classes
        /// </summary>
        /// <returns>lista as classes</returns>
        List<Class> Listar();

        /// <summary>
        /// Buscar uma classe pelo seu id
        /// </summary>
        /// <param name="id">id da classe a ser buscado</param>
        /// <returns>classe buscada</returns>
        Class BuscarPorId(int id);

        /// <summary>
        /// Atualizar uma classe existente 
        /// </summary>
        /// <param name="id">id da classe a ser atualizado</param>
        /// <param name="classe">objeto classe com as novas informações</param>
        void Atualizar(int id , Class classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">id da classe a ser deletado</param>
        void Deletar(int id);
    }
}
