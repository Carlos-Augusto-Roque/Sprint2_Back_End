using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SP_Medical_Group.webApi.Domains;
using senai.SP_Medical_Group.webApi.Interfaces;
using senai.SP_Medical_Group.webApi.Repositories;
using senai.SP_Medical_Group.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class ConsultaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _consultaRepository que irá receber todos os métodos definidos na interface 
        /// </summary>
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();            
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto consulta a ser criado</param>
        /// <returns>Um StatusCode 201 - Created</returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista todas consultas existentes
        /// </summary>
        /// <returns>Uma lista das consultas e um StatusCode 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="id">Id da consulta a ser buscada</param>
        /// <returns>Uma consulta buscada e um StatusCode 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizada com as novas informações</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id,Consulta consultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(id,consultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="id">Id da consulta a ser deletada</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _consultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza apenas a descrição de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada a descrição</param>
        /// <param name="atualizarDescricao">Objeto atualizarDescrição com a nova descrição </param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        [Authorize(Roles = "3")]
        [HttpPatch("{id}")]
        public IActionResult Path(int id, ConsultaViewModel atualizarDescricao)
        {
            try
            {
                _consultaRepository.AtualizarDescricao(id, atualizarDescricao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista as consultas relacionadas com o id de quem estiver logado (médico ou paciente) 
        /// </summary>
        /// <returns>Uma lista das consultas e um StatusCode 200 - Ok</returns>
        [Authorize(Roles ="2,3")]
        [HttpGet("Minhas")]
        public IActionResult GetMy ()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(idUsuario));

                
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }
        
        [Authorize(Roles = "2,3")]
        [HttpGet("Agenda")]
        public IActionResult GetAgend ()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarAgenda(idUsuario));


            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar a agenda se o usuário não estiver logado!",
                    erro
                });
            }
        }

        /// <summary>
        /// Atualiza o Status de uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="idStatus">Id do novo Status que será atualizado</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        [Authorize(Roles ="1")]
        [HttpPatch("{idConsulta}/{idStatus}")]
        public IActionResult Patch(int idConsulta, int idStatus)
        {
            try
            {
                _consultaRepository.AtualizarStatus(idConsulta, idStatus);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
