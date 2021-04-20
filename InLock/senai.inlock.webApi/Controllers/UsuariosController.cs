using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário 
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(UsuarioDomain usuario)
        {
            if (usuario.email == null || usuario.senha == null)
            {
                return BadRequest("Os campos email e senha são obrigatórios !");
            }

            _usuarioRepository.Cadastrar(usuario);

            return Ok();
        }

        /// <summary>
        /// Lista todos os usuários cadastrados
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuarios = _usuarioRepository.Listar();

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Busca um usuário pelo seu id 
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }

            return NotFound("Usuário não encontrado !");
        }

        /// <summary>
        /// Deleta um usuário pelo seu id 
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound("Nenhum usuário foi encontrado com esse identificador !");
            }

            _usuarioRepository.Deletar(id);

            return Ok($"O Usuario {id} foi excluido com sucesso!");
        }

        /// <summary>
        /// Atualiza um usuário (id no corpo da requisição) 
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPut("Atualizar")]
        public IActionResult Atualizar(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(usuario.idUsuario);

            if (usuarioBuscado != null)
            {

                try
                {
                    _usuarioRepository.Atualizar(usuario);

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
                           mensagem = "Usuário não encontrado !"
                       }
                   );
        }

        /// <summary>
        /// Realiza o login do usuário (por email e senha)
        /// </summary>
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

            // Caso encontre , prossegue para criação do token

            // Define os dados que serão fornecidos no token (Payload)
            var claims = new[]
            {
                //formato da Claim (tipo, valor)
                new Claim(JwtRegisteredClaimNames.Email, usuario.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.idTipoUsuario.ToString())
                
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao"));

            // Define as credenciais do token (Header)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(

                //emissor do token
                issuer: "inlock.webApi",

                //destinatário do token
                audience: "inlock.webApi",

                //dados definidos na variável claims(Payload)
                claims: claims,

                //tempo de expiração
                expires: DateTime.Now.AddMinutes(30),

                //credenciais do token
                signingCredentials: creds

                );

            //retorna um status code 200 Ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
