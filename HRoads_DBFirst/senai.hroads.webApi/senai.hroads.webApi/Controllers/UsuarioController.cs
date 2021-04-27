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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Usuario novoUsuario)
        {

            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {

            _usuarioRepository.Atualizar(id, usuarioAtualizado);


            return StatusCode(204);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _usuarioRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
