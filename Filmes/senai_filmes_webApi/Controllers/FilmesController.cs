using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet] // EndPoint para o método listar filmes
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            return Ok(listaFilmes);
        }

        [HttpPut("{id}")] // EndPoint para o método atualizar filme na URL
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

        [HttpPut] // EndPoint para o método atualizar filme no body
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

        [HttpGet("{id}")] // EndPoint para o método buscar filme 
        public IActionResult BuscarPoId(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum gênero foi encontrado");
            }

            return Ok(filmeBuscado);
        }

        [HttpPost] // EndPoint para o método cadastrar filmes
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }


        [HttpDelete("{id}")] // EndPoint para o método deletar filme
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
