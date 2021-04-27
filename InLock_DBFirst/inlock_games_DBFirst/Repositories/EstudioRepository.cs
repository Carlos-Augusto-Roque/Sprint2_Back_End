using inlock_games_DbFirst.Contexts;
using inlock_games_DbFirst.Domains;
using inlock_games_DbFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlock_games_DbFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        inlockContext ctx = new inlockContext();
        public List<Estudio> Listar()
        {
            //Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public Estudio BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Estudio estudioAtualizar)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> ListarJogos()
        {
            throw new NotImplementedException();
        }
    }
}
