using M_Peoples_webApi.Domains;
using M_Peoples_webApi.Interfaces;
using M_Peoples_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles ="2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(TipoUsuarioDomain novoTipo)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        [Authorize(Roles = "2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listarTipos = _tipoUsuarioRepository.Listar();

            return Ok(listarTipos);
        }

        [Authorize(Roles = "2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
           
            TipoUsuarioDomain usuario = _tipoUsuarioRepository.BuscarPorId(id);

         
            if (usuario != null)
            {
              
                return Ok(usuario);
            }
            
            return NotFound("Tipo de Usuario não encontrado !");
        }

        [Authorize(Roles = "2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id,TipoUsuarioDomain tipoAtualizado)
        {

            TipoUsuarioDomain tipoUsuario = _tipoUsuarioRepository.BuscarPorId(tipoAtualizado.idTipoUsuario);

            
            if (tipoAtualizado != null)
            {
               
                try
                {
                   
                    _tipoUsuarioRepository.Atualizar(id,tipoAtualizado);

                    
                    return NoContent();
                }
                
                catch (Exception erro)
                {
                   
                    return BadRequest(erro);
                }
            }

           
            return NotFound
                (
                    new
                    {
                        mensagem = "Tipo do Usuário não encontrado",
                        erro = true
                    }
                );


        }

        
        [Authorize(Roles = "2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            TipoUsuarioDomain tipoUsuario = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuario != null)
            {

                _tipoUsuarioRepository.Deletar(id);

                return Ok($"O Tipo de usuário {id} foi excluido com sucesso!");

            }

            
            return NotFound("Nenhum tipo de usuário foi encontrado com esse id");
        }
    }
}
