using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize(Roles = "2" )]
        [HttpPost("Cadastrar")]
        public IActionResult Post(JogoDomain jogo)
        {
            if (jogo.nome == null)
            {
                return BadRequest("O campo nome é obrigatório !");
            }

            _jogoRepository.Cadastrar(jogo);

            return Ok();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.Listar();

            return Ok(listaJogos);
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogo = _jogoRepository.BuscarPorId(id);

            if (jogo != null)
            {
                return Ok(jogo);
            }

            return NotFound("Jogo não encontrado !");
        }

        [Authorize(Roles = "2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            JogoDomain jogo = _jogoRepository.BuscarPorId(id);

            if (jogo == null)
            {
                return NotFound("Nenhum jogo encontrado com esse identificador !");
            }

            _jogoRepository.Deletar(id);

            return Ok($"O jogo {id} foi excluido com sucesso!");
        }

        [Authorize(Roles = "2")]
        [HttpPut("Atualizar")]
        public IActionResult Atualizar(JogoDomain jogo)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogo.idJogo);

            if (jogoBuscado != null)
            {

                try
                {
                    _jogoRepository.Atualizar(jogo);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                   (new
                       {
                           mensagem = "Jogo não encontrado !"
                       }
                   );
        }

    }

    
}
