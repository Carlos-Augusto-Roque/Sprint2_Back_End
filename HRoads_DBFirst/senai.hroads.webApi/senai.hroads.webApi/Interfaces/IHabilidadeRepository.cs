using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar uma nova habilidade
        /// </summary>
        /// <param name="habilidade">objeto habilidade a ser criado</param>
        void Cadastrar(Habilidade habilidade);

        /// <summary>
        /// Listar as habilidades
        /// </summary>
        /// <returns>lista das habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Buscar uma habilidade pelo seu id
        /// </summary>
        /// <param name="id">id da habilidade a ser buscada</param>
        /// <returns>habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Atualizar uma habilidade existente 
        /// </summary>
        /// <param name="id">id da habilidade a ser atualizado</param>
        /// <param name="habilidade">objeto habilidade com as novas informações</param>
        void Atualizar(int id, Habilidade habilidade);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade a ser deletada</param>
        void Deletar(int id);
    }
}
