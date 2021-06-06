using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo InstituicaoRepository
    /// </summary>
    interface IInstituicaoRepository
    {
        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>Uma lista de instituicoes</returns>
        List<Instituico> Listar();

        /// <summary>
        /// Busca uma instituicao através do ID
        /// </summary>
        /// <param name="id">ID da instituicao que será buscada</param>
        /// <returns>Uma instituicao buscada</returns>
        Instituico BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrada</param>
        void Cadastrar(Instituico novaInstituicao);

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será atualizada</param>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Instituico instituicaoAtualizada);

        /// <summary>
        /// Deleta uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será deletada</param>
        void Deletar(int id);
    }
}
