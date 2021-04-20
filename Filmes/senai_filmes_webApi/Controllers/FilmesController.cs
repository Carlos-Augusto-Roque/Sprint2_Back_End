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
    // ex : http://localhost:5000/api/Filmes
    [Route("api/[controller]")]
        
    // define que é um controlador de API 
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// objeto _filmeRepository que irá receber todos os métodos definidos na interface IFilmes
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// instancia o objeto _filmesRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes cadastrados
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador,Usuario")]
        [HttpGet] 
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            return Ok(listaFilmes);
        }

        /// <summary>
        /// Atualiza um filme por seu id(URL)
        /// </summary>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")] 
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Filme não encontrado!",
                        erro = true
                    }
                    );
            }

            try
            {
                _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um filme pelo seu id(corpo da requisição)
        /// </summary>
        [Authorize(Roles = "Administrador")]
        [HttpPut] 
        public IActionResult PutIdBody(FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.idFilme);

            if (filmeBuscado != null)
            {
                try
                {
                    _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Filme não encontrado!"
                    }
                );
        }

        /// <summary>
        /// Busca um filme pelo seu id 
        /// </summary>
        [Authorize(Roles = "Administrador,Usuario")]
        [HttpGet("{id}")] 
        public IActionResult BuscarPoId(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum gênero foi encontrado");
            }

            return Ok(filmeBuscado);
        }

        /// <summary>
        /// Cadastra um novo filme  
        /// </summary>
        [Authorize(Roles = "Administrador")]
        [HttpPost] 
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um filme pelo seu id
        /// </summary>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
