using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// controller responsaveis pelos endpoints(URLs) referentes aos generos
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    //define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // define que a rota de uma requisicao sera no formato dominio/api/nomeControoller
    // ex : http://localhost:5000/api/Generos
    [Route("api/[controller]")]

    // define que é um controlador de API 
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneros
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// instancia o objeto _generoRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public GenerosController() // metodo construtor
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>uma lista de generos e um status code</returns>
        /// http://localhost:5000/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            //cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            //retorna o status code 200(OK) com a lista dos generos
            return Ok(listaGeneros);
        }
        
        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero recebido na requisição</param>
        /// <returns>um status code 201 - created</returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //faz a chamada para o metodo .Cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //retorna um status code 201 - created
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um genero
        /// </summary>
        /// <param name="id"> id do genero que sera deletado</param>
        /// <returns>um status code 204 - no content</returns>
        ///http://localhost:5000/api/generos/4 por exempo excluir o genero cujo id seja 4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o metodo .Deletar
            _generoRepository.Deletar(id);

            //retorna um status code 204 - no content
            return StatusCode(204);
        }
    }
}
