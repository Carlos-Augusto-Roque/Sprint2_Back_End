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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }


        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// <summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(Habilidade novaHabilidade)
        {

            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Lista todas as habilidades
        /// <summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.Listar());
        }

        /// <summary>
        /// Buscar uma habilidade pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_habilidadeRepository.BuscarPorId(id) == null)
            {
                return NotFound("Habilidade não encontrada !");
            }
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualizar uma habilidade pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            if (_habilidadeRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Habilidade não encontrada !",
                        erro = true
                    }
                    );
            }

            try
            {
                _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
                       
        }

        /// <summary>
        /// Deleta uma habilidade pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _habilidadeRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
