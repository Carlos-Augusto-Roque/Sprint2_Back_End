using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador,Usuario")]
        [HttpGet]
        public IActionResult Get()
        {
            //cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            //retorna o status code 200(OK) com a lista dos generos
            return Ok(listaGeneros);
        }

        /// <summary>
        /// busca um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>um genero buscado ou notfound caso nenhum genero seja encontrado</returns>
        [Authorize(Roles = "Administrador,Usuario")] 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //cria um objeto generoBuscado que irá receber o genero buscado no bd
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                //caso nao seja encontrado, retorna um statusCode 404 - NotFound com a mensagem personalizada
                return NotFound("Nenhum gênero foi encontrado");
            }

            //caso seja encontrado, retorna o genero buscado com um statusCode 200 Ok
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            // Verifica se algum gênero foi encontrado
            // ! -> negação (não)
            if (generoBuscado != null)
            {
                // Se sim, tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }

            // Caso não seja encontrado, retorna NotFoun com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado!"
                    }
                );
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero recebido na requisição</param>
        /// <returns>um status code 201 - created</returns>
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
