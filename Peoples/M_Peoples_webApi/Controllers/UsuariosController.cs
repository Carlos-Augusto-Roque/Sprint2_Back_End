using M_Peoples_webApi.Domains;
using M_Peoples_webApi.Interfaces;
using M_Peoples_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Controllers
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
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao"));

            // Define as credenciais do token (Header)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(

                //emissor do token
                issuer: "Peoples.webApi",

                //destinatário do token
                audience: "Peoples.webApi",

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


        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        [Authorize]
        [HttpPost("Cadastrar")]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            if (novoUsuario.email == null || novoUsuario.senha == null)
            {
                return BadRequest("Os campos email e senha são obrigatórios !");
            }

            _usuarioRepository.Cadastrar(novoUsuario);
                        
            return Created("http://localhost:5000/api/usuarios", novoUsuario);
        }
                
        /// <summary>
        /// Lista todos os usuarios cadastrados
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {            
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Atualiza um funcionario
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPut("Atualizar")]
        public IActionResult PutIdBody(UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorId(usuarioAtualizado.idUsuario);

            
            if (usuario != null)
            {
                
                try
                {
                    _usuarioRepository.Atualizar(usuarioAtualizado);
                                        
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
                        mensagem = "Usuário não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um funcionario pelo seu id
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario != null)
            {
                _usuarioRepository.Deletar(id);

                return Ok($"O Usuario {id} foi excluido com sucesso!");
            }

            return NotFound("Nenhum usuário encontrado com esse id");
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
                
    }
}
