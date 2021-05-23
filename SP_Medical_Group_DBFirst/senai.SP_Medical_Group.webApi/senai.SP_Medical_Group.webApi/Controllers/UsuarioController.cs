using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SP_Medical_Group.webApi.Domains;
using senai.SP_Medical_Group.webApi.Interfaces;
using senai.SP_Medical_Group.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes às presenças
    /// </summary>
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario a ser cadastrado</param>
        /// <returns>Um StatusCode 201 - Created</returns>
        [Authorize(Roles ="1")]        
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {                
                _usuarioRepository.Cadastrar(novoUsuario);
                
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista todos usuários existentes
        /// </summary>
        /// <returns>Uma lista dos usuários e um StatusCode 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário buscado</param>
        /// <returns>Um usuario buscado e um StatusCode 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
                

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
