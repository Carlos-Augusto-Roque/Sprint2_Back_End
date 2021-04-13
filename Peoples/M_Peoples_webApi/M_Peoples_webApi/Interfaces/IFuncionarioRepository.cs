using M_Peoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Interfaces
{
    //Criar a interface correspondente que contenha as ações de: listar, buscar por id, buscar por nome, deletar, atualizar cadastrar e nomesCompletos
    interface IFuncionarioRepository
    {
        //Create
        void Cadastrar(FuncionarioDomain novoFuncionario);

        //Read
        List<FuncionarioDomain> ListarTodos();

        //Update
        void Atualizar(FuncionarioDomain funcionario);

        //Delete
        void Deletar(int id);
        
        //Extras
        //Buscar um funcionario pelo seu id
        FuncionarioDomain BuscarPorId(int id);

        //listar funcionarios que tenham o nome buscado
        List<FuncionarioDomain> BuscarPorNome(string nome);

        //mostrar o nome completo do funcionario buscado
        FuncionarioDomain NomesCompletos(int id);

        //Listar todos os funcionarios de forma ordenada ASC ou DESC pelo nome
        List<FuncionarioDomain> ListarOrdenado(string ordem);

    }
}
