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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(TiposUsuario novotipo)
        {

            _tiposUsuarioRepository.Cadastrar(novotipo);

            return StatusCode(201);
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_tiposUsuarioRepository.Listar());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {

            _tiposUsuarioRepository.Atualizar(id, tipoAtualizado);


            return StatusCode(204);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _tiposUsuarioRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
