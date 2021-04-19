using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(UsuarioDomain jogo);

        List<UsuarioDomain> Listar();

        UsuarioDomain BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(UsuarioDomain jogo);

        UsuarioDomain Login(string email, string senha);
    }
}
