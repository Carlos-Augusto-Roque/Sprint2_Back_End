using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TiposDeHabilidadeRepository : ITiposDeHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(TiposDeHabilidade novoTipo)
        {
            ctx.TiposDeHabilidades.Add(novoTipo);
        }

        public List<TiposDeHabilidade> Listar()
        {
            return ctx.TiposDeHabilidades.ToList();
        }

        public TiposDeHabilidade BuscarPorId(int id)
        {
            return ctx.TiposDeHabilidades.Find(id);
        }

        public void Atualizar(int id, TiposDeHabilidade tipo)
        {
            TiposDeHabilidade tipoBuscado = ctx.TiposDeHabilidades.Find(id);

            if (tipoBuscado.Nome != null)
            {
                tipoBuscado.Nome = tipo.Nome;
            }
            
            ctx.TiposDeHabilidades.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposDeHabilidade tipoBuscado = ctx.TiposDeHabilidades.Find(id);

            ctx.TiposDeHabilidades.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

    }
}
