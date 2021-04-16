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

        [Authorize]
        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipo)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listarTipos = _tipoUsuarioRepository.Listar();

            return Ok(listarTipos);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(TipoUsuarioDomain tipoAtualizado)
        {
            TipoUsuarioDomain tipoUsuario = _tipoUsuarioRepository.(tipoAtualizado);
        }
    }
}
