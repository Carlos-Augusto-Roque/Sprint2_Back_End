using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(Habilidade habilidade)
        {
            ctx.Habilidades.Add(habilidade);

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.Find(id);
        }

        public void Atualizar(int id, Habilidade habilidade)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            if (habilidade.Nome != null)
            {
                habilidadeBuscada.Nome = habilidade.Nome;
            }
            if (habilidadeBuscada.IdTipoHabilidade != null)
            {
                habilidadeBuscada.IdTipoHabilidade = habilidade.IdTipoHabilidade;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

    }
}
