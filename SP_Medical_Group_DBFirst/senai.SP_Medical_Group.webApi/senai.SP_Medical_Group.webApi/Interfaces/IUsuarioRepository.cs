using senai.SP_Medical_Group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario novoUsuario);

        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Deletar(int id);

        Paciente BuscarPacientePorId(int id);

        Medico BuscarMedicoPorId(int id);
    }
}
