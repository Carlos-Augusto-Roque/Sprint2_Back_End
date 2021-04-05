using M_Peoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Interfaces
{
    //Criar a interface correspondente que contenha as ações de: listar, buscar por id, deletar, atualizar e inserir
    interface IFuncionarioRepository
    {
        //listar
        List<FuncionarioDomain> ListarTodos();

        //buscar por id
        FuncionarioDomain BuscarPorId(int id);

        //buscar por nome
        FuncionarioDomain BuscarPorNome(string nome);

        //mostrar nome completo buscando por id
        FuncionarioDomain NomesCompletos(int id);

        //deletar
        void Deletar(int id);

        //atualizar (id pela URL)
        void Atualizar(FuncionarioDomain funcionario);

        //inserir um novo funcionario
        void Cadastrar(FuncionarioDomain novoFuncionario);
    }
}
