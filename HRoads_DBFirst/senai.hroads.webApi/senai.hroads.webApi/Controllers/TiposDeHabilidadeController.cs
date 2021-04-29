using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeHabilidadeController : ControllerBase
    {
        private ITiposDeHabilidadeRepository _tiposDeHabilidadeRepository { get; set; }

        public TiposDeHabilidadeController()
        {
            _tiposDeHabilidadeRepository = new TiposDeHabilidadeRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// <summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(TiposDeHabilidade novoTipo)
        {
            try
            {
                _tiposDeHabilidadeRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);               
            }
        }

        /// <summary>
        /// Lista todos os tipos de habilidade
        /// <summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposDeHabilidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um tipo de habilidade pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_tiposDeHabilidadeRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de habilidade não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                return Ok(_tiposDeHabilidadeRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um tipo de habilidade pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, TiposDeHabilidade tipoAtualizado)
        {
            if (_tiposDeHabilidadeRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de habilidade não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {                            
                _tiposDeHabilidadeRepository.Atualizar(id, tipoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta um tipo de habilidade pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {
            if (_tiposDeHabilidadeRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de habilidade não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                _tiposDeHabilidadeRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
