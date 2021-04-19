using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    interface IEstudioRepository
    {
        void Cadastrar(EstudioDomain estudio);

        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(EstudioDomain estudio);

               
    }
}
