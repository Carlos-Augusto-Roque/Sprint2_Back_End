using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        //ex: void Cadastrar();

        /// <summary>
        /// retorna todos os filmes
        /// </summary>
        /// <returns>uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// busca um filme atraves do seu id
        /// </summary>
        /// <param name="id">id do filme que será buscado</param>
        /// <returns>um objeto do tipo FilmeDomain que foi buscado</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// cadastra um novo filme 
        /// </summary>
        /// <param name="novoFilme">objeto novoFilme que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">objeto filme com as novas informacoes</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// atualiza um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do filme que será atulaizado</param>
        /// <param name="filme">objeto filme com as novas informacoes</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// deleta um filme
        /// </summary>
        /// <param name="id">id do filme que sera deletado</param>
        void Deletar(int id);
    }
}
