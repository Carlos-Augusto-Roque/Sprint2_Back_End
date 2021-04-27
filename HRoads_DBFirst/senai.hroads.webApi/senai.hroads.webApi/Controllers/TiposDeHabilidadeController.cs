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

        [HttpPost("Cadastrar")]
        public IActionResult Post(TiposDeHabilidade novoTipo)
        {

            _tiposDeHabilidadeRepository.Cadastrar(novoTipo);

            return Ok();
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_tiposDeHabilidadeRepository.Listar());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_tiposDeHabilidadeRepository.BuscarPorId(id));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, TiposDeHabilidade tipoAtualizado)
        {

            _tiposDeHabilidadeRepository.Atualizar(id, tipoAtualizado);


            return StatusCode(204);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _tiposDeHabilidadeRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
