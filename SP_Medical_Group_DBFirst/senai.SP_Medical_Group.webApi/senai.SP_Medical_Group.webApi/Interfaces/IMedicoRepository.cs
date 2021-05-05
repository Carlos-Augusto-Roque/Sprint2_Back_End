using senai.SP_Medical_Group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface IMedicoRepository
    {
        void Cadastrar(Medico novoMedico);

        List<Medico> Listar();

        Medico BuscarPorId(int id);

        void Atualizar(int id, Medico medicoAtualizado);

        void Deletar(int id);
    }
}
