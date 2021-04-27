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
        
        [HttpPost("Cadastrar")]
        public IActionResult Post(Class novaClasse)
        {
            
            _classRepository.Cadastrar(novaClasse);
                        
            return StatusCode(201);
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_classRepository.Listar());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            
            return Ok(_classRepository.BuscarPorId(id));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Class classeAtualizada)
        {
            
            _classRepository.Atualizar(id, classeAtualizada);

            
            return StatusCode(204);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {
            
            _classRepository.Deletar(id);

            
            return StatusCode(204);
        }

    }
}
