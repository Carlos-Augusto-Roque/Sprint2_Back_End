using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(EstudioDomain estudio)
        {
            if (estudio.nome == null)
            {
                return BadRequest("O campo nome é obrigatório !");
            }

            _estudioRepository.Cadastrar(estudio);

            return Ok();
        }

        /// <summary>
        /// Lista todos os estúdios cadastrados
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.Listar();

            return Ok(listaEstudios);
        }

        /// <summary>
        /// Busca um estúdio pelo seu id
        /// </summary>
        [Authorize(Roles = "1, 2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudio = _estudioRepository.BuscarPorId(id);

            if (estudio != null)
            {
                return Ok(estudio);
            }

            return NotFound("Estudio não encontrado !");
        }

        /// <summary>
        /// Deleta um estúdio pelo seu id 
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            EstudioDomain estudio = _estudioRepository.BuscarPorId(id);

            if (estudio == null)
            {
                return NotFound("Nenhum estudio encontrado com esse identificador !");
            }

            _estudioRepository.Deletar(id);

            return Ok($"O estudio {id} foi excluido com sucesso!");
        }

        /// <summary>
        /// Atualiza um estúdio (id no corpo da requisição)
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPut("Atualizar")]
        public IActionResult Atualizar(EstudioDomain estudio)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudio.idEstudio);

            if (estudioBuscado != null)
            {

                try
                {
                    _estudioRepository.Atualizar(estudio);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                   (new
                   {
                       mensagem = "Estudio não encontrado !"
                   }
                   );
        }
    }
}
