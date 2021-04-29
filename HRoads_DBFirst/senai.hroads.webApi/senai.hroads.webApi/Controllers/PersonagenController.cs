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
    public class PersonagenController : ControllerBase
    {
        private IPersonagenRepository _personagenRepository { get; set; }

        public PersonagenController()
        {
            _personagenRepository = new PersonagenRepository();
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// <summary>
        [Authorize(Roles = "1")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(Personagen novoPersonagem)
        {
            try
            {
                _personagenRepository.Cadastrar(novoPersonagem);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista todos os personagens
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_personagenRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Busca um personagem pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_personagenRepository.BuscarPorId(id) == null)
            {
                return NotFound
                   (new
                   {
                       mensagem = "Personagem não encontrado !",
                       erro = true
                   }
                   );
            }

            try
            {
                return Ok(_personagenRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um personagem pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Personagen personagemAtualizado)
        {
            if (_personagenRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Personagem não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                _personagenRepository.Atualizar(id, personagemAtualizado);
                
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta um personagem pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {
            if (_personagenRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Personagem não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                _personagenRepository.Deletar(id);


                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
    }
}
