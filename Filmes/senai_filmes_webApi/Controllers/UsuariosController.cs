using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints (URLs) referentes aos usuários
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    /// <summary>
    /// // Define que o tipo de resposta da API será no formato JSON
    /// </summary>
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz a autenticação do usuário
        /// </summary>
        /// <param name="login">objeto com os dados de e-mail e senha</param>
        /// <returns>Um status code e, em caso de sucesso, os dados do usuário buscado</returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            // Busca o usuário pelo e-mail e senha
            UsuarioDomain usuario = _usuarioRepository.Login(login.email, login.senha);

            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuario == null)
            {
                // retorna NotFound com uma mensagem personalizada
                return NotFound("Email ou senha inválidos!");
            }
            // Caso encontre, retorna um status code 200 com os dados do usuário buscado
            return Ok(usuario);
        }
    }
}
