using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITiposDeHabilidadeRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">objeto tipo habilidade a ser criado</param>
        void Cadastrar(TiposDeHabilidade novoTipo);

        /// <summary>
        /// Listar os tipos de habilidades
        /// </summary>
        /// <returns>lista das dos tipos de habilidades</returns>
        List<TiposDeHabilidade> Listar();

        /// <summary>
        /// Buscar um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="id">id do tipo da habilidade a ser buscada</param>
        /// <returns>tipo da habilidade buscada</returns>
        TiposDeHabilidade BuscarPorId(int id);

        /// <summary>
        /// Atualizar um tipo de habilidade existente 
        /// </summary>
        /// <param name="id">id do tipo da habilidade a ser atualizado</param>
        /// <param name="tipo">objeto tipo habilidade com as novas informações</param>
        void Atualizar(int id, TiposDeHabilidade tipo);

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">id do tipo da habilidade a ser deletada</param>
        void Deletar(int id);
    }
}
