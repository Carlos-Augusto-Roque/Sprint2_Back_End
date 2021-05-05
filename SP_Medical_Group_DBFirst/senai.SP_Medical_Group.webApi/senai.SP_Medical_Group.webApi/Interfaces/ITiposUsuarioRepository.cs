using senai.SP_Medical_Group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario novoTipo);

        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(int id);

        void Atualizar(int id, TiposUsuario tipoAtualizado);

        void Deletar(int id);

    }
}
