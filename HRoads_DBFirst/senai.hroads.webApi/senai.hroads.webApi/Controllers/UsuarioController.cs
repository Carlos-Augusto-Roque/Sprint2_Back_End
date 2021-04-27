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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// <summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(Usuario novoUsuario)
        {

            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Lista todos os usuarios cadastrados
        /// <summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuario pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_usuarioRepository.BuscarPorId(id) == null)
            {
                return NotFound("Usuário não encontrado !");
            }
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza um usuario pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            if (_usuarioRepository.BuscarPorId(id) == null) 
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuário não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(204);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta um usuario pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _usuarioRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
