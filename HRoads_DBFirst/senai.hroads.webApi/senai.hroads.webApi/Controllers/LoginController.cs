using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
               

        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            // Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                // retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha inválidos!");
            }

            // Caso encontre, prossegue para a criação do token

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                // Formato da Claim = TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(
                issuer: "HROADS.webApi",                // emissor do token
                audience: "HROADS.webApi",              // destinatário do token
                claims: claims,                         // dados definidos acima (linha 59)
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            // Retorna um status code 200 - Ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
