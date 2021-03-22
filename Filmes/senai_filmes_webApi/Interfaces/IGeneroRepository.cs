using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// interface responsável pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        //ex: void Cadastrar();

        /// <summary>
        /// retorna todos os generos
        /// </summary>
        /// <returns>uma lista de generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// busca um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que será buscado</param>
        /// <returns>um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// cadastra um novo genero 
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">objeto genero com as novas informacoes</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// atualiza um genero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do genero que será atulaizado</param>
        /// <param name="genero">objeto genero com as novas informacoes</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// deleta um genero 
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        void Deletar(int id);
    }
}
