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

        [HttpPost("Cadastrar")]
        public IActionResult Post(Habilidade novaHabilidade)
        {

            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.Listar());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {

            _habilidadeRepository.Atualizar(id, habilidadeAtualizada);


            return StatusCode(204);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _habilidadeRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
