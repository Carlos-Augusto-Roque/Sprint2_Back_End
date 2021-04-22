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
    //define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //define que a rota de uma requisicao sera no formato dominio/api/nomeController
    [Route("api/[controller]")]

    //define que é um controlador de API 
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        // objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneros
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        //instancia o objeto _funcionarioRepository para que haja a referencia aos metodos no repositorio
        public FuncionariosController() // metodo construtor (mesmo nome da classe)
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        // Cadastrar um novo funcionario
        [Authorize(Roles ="1")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            if (novoFuncionario.nome == null)
            {
                return BadRequest("O campo nome é obrigatório!");
            }

            //faz a chamada para o metodo .Cadastrar
            _funcionarioRepository.Cadastrar(novoFuncionario);

            //retorna um status code 201 - created
            return Created("http://localhost:5000/api/funcionarios", novoFuncionario);
        }

        // Lista todos os funcionarios cadastrados
        [Authorize(Roles = "1")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            //retorna a lista dos funcionarios e um status code 200 (OK)
            return Ok(_funcionarioRepository.ListarTodos());
        }

        // Atualiza um funcionario
        [Authorize(Roles = "2")]
        [HttpPut("Atualizar")]
        public IActionResult PutIdBody(FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto "funcionario" que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.idFuncionario);

            //verifica se algum funcionario foi encontrado
            if (funcionario != null)
            {
                //tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar
                    _funcionarioRepository.Atualizar(funcionarioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um status 400 - BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }

        // Deleta um funcionario cadastrado
        [Authorize(Roles = "2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorId(id);

            if (funcionario != null)
            {

                //chama o metodo deletar
                _funcionarioRepository.Deletar(id);

                return Ok($"O Funcionario {id} foi excluido com sucesso!");

            }

            //retorna status code 204 - no content
            return NotFound("Nenhum funcionário encontrado com esse id");
        }

        // Busca um funcionario cadastrado pelo id
        [Authorize(Roles = "1")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            //criado um objeto "funcionario" que ira receber os dados
            FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorId(id);

            //se existir um funcionario
            if (funcionario != null)
            {
                //retorna um status code 200 Ok 
                return Ok(funcionario);
            }
            //se nao, retorna um status code 404 notfound e a msg
            return NotFound("Funcionário não encontrado !");
        }

        // Busca um funcionario cadastrado pelo seu nome
        [Authorize(Roles = "1")]
        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome)
        {
            return Ok(_funcionarioRepository.BuscarPorNome(nome));
        }

        // Ler o nome completo de um funcionário buscado pelo id
        [Authorize(Roles = "2")]
        [HttpGet("Ler/{id}")]
        public IActionResult GetFullName(int id)
        {
            FuncionarioDomain funcionario = _funcionarioRepository.NomesCompletos(id);

            if (funcionario != null)
            {

            return Ok(funcionario);

            }

            return NotFound("Não encontrado!");
        }

        // Lista todos os funcionários de maneira ordenada pelo nome        
        [Authorize(Roles = "1")]
        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetOrderBy(string ordem)
        {
            // Verifica se a ordenação atende aos requisitos
            if (ordem != "ASC" && ordem != "DESC")
            {
                // Caso não, retorna um status code 404 - BadRequest com uma mensagem de erro
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'ASC' ou 'DESC'");
            }

            // Retorna a lista ordenada com um status code 200 - OK
            return Ok(_funcionarioRepository.ListarOrdenado(ordem));
        }

    }
}
