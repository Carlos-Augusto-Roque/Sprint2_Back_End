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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// <summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(TiposUsuario novotipo)
        {

            _tiposUsuarioRepository.Cadastrar(novotipo);

            return StatusCode(201);
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// <summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_tiposUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de usuário pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_tiposUsuarioRepository.BuscarPorId(id) == null)
            {
                return NotFound("Tipo de Usuário não encontrado !");
            }

            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza um tipo de usuário pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            if (_tiposUsuarioRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de usuário não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                
                _tiposUsuarioRepository.Atualizar(id, tipoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
                       
        }

        /// <summary>
        /// Deleta um tipo de usuário pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _tiposUsuarioRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
