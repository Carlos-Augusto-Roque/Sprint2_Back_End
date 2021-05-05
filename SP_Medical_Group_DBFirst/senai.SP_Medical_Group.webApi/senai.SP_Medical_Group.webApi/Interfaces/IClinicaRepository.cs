using senai.SP_Medical_Group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);

        List<Clinica> Listar();

        Clinica BuscarPorId(int id);

        void Atualizar(int id, Clinica clinicaAtualizada);

        void Deletar(int id);
    }
}
