using senai.SP_Medical_Group.webApi.Domains;
using senai.SP_Medical_Group.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);

        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        void Atualizar(int id, Consulta consultaAtualizada);

        void Deletar(int id);

        List<Consulta> ListarMinhas(int id);

        List<Consulta> ListarAgenda(int id);

        void AtualizarStatus(int id, int idStatus);

        void AtualizarDescricao(int id,ConsultaViewModel atualizarDescricao);
    }
}
