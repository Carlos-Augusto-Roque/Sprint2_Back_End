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
    public class ClassController : ControllerBase
    {
        private IClassRepository _classRepository { get; set; }

       
        public ClassController()
        {
            _classRepository = new ClassRepository();
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// <summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(Class novaClasse)
        {
            
            _classRepository.Cadastrar(novaClasse);
                        
            return StatusCode(201);
        }

        /// <summary>
        /// Lista todas as classes
        /// <summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_classRepository.Listar());
        }

        /// <summary>
        /// Busca uma classe pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_classRepository.BuscarPorId(id) == null)
            {
                return NotFound("Classe não encontrada !");
            }
            return Ok(_classRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza uma classe pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Class classeAtualizada)
        {
            if (_classRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Classe não encontrada !",
                        erro = true
                    }
                    );
            }

            try
            {
                _classRepository.Atualizar(id, classeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
      
        }

        /// <summary>
        /// Deleta uma classe pelo seu id
        /// <summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {
            
            _classRepository.Deletar(id);

            
            return StatusCode(204);
        }

    }
}
