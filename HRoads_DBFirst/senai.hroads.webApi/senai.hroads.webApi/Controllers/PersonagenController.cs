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

        [HttpPost("Cadastrar")]
        public IActionResult Post(Personagen novoPersonagem)
        {

            _personagenRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_personagenRepository.Listar());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_personagenRepository.BuscarPorId(id));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Personagen personagemAtualizado)
        {

            _personagenRepository.Atualizar(id, personagemAtualizado);


            return StatusCode(204);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _personagenRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
