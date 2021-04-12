using M_Peoples_webApi.Domains;
using M_Peoples_webApi.Interfaces;
using M_Peoples_webApi.Repositories;
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

        //lista todos os funcionarios
        [HttpGet]
        public IActionResult Get()
        {
            //criado uma lista "listaFuncionarios" para receber os dados
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            //retorna a lista dos funcionarios e um status code 200 (OK)
            return Ok(listaFuncionarios);
        }

        //busca um funcionario pelo id
        //[HttpGet("{id}")]
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

        //busca um funcionario pelo nome
        //[HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            //criado um objeto "funcionario" que ira receber os dados
            FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorNome(nome);

            //se existir um funcionario
            if (funcionario != null)
            {
                //retorna um status code 200 Ok 
                return Ok(funcionario);
            }
            //se nao, retorna um status code 404 notfound e a msg
            return NotFound("Funcionário não encontrado !");
        }

        //mostra o nome completo de um funcionario (buscado pelo seu id)
        //[HttpGet("{id}")]
        public IActionResult NomesCompletos(int id)
        {
            //criado um objeto "funcionario" que ira receber os dados
            FuncionarioDomain funcionario = _funcionarioRepository.NomesCompletos(id);

            //se existir um funcionario
            if (funcionario != null)
            {
                //retorna um status code 200 Ok 
                return Ok(funcionario);
            }
            //se nao, retorna um status code 404 notfound e a msg
            return NotFound("Funcionário não encontrado !");

        }

        //deleta um funcionario pelo id
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            //chama o metodo deletar
             _funcionarioRepository.Deletar(id);

            //retorna status code 204 - no content
            return StatusCode(204);
        }

        //atualiza um funcionario pelo id
        [HttpPut]
        public IActionResult PutIdBody(FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto "funcionario" que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionario = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.idFuncionario);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (funcionario == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Funcionário não encontrado !"
                    }
                    );
            }
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

        //cadastra um novo funcionario
        [HttpPost]
        public IActionResult Put(FuncionarioDomain novoFuncionario)
        {
            //faz a chamada para o metodo .Cadastrar
            _funcionarioRepository.Cadastrar(novoFuncionario);

            //retorna um status code 201 - created
            return StatusCode(201);
        }

    }
}
