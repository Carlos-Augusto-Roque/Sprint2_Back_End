using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        void Cadastrar(JogoDomain jogo);

        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(JogoDomain jogo);

    }
}
