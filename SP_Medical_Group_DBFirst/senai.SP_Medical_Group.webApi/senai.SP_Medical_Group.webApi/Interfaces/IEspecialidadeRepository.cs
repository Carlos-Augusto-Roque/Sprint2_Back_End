using senai.SP_Medical_Group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade novaEspecialidade);

        List<Especialidade> Listar();

        Especialidade BuscarPorId(int id);

        void Atualizar(int id, Especialidade especialidadeAtualizada);

        void Deletar(int id);
    }
}
