using senai.SP_Medical_Group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface IPacienteRepository
    {
        void Cadastrar(Paciente novoPaciente);

        List<Paciente> Listar();

        Paciente BuscarPorId(int id);

        void Atualizar(int id, Paciente pacienteAtualizado);

        void Deletar(int id);
    }
}
