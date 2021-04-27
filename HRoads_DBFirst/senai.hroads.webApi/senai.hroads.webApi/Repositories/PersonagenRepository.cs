using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagenRepository : IPersonagenRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(Personagen personagen)
        {
            ctx.Personagens.Add(personagen);

            ctx.SaveChanges();
        }

        public List<Personagen> Listar()
        {
            return ctx.Personagens.ToList();
        }

        public Personagen BuscarPorId(int id)
        {
            return ctx.Personagens.Find(id);
        }

        public void Atualizar(int id, Personagen personagen)
        {
            Personagen personagemBuscado = ctx.Personagens.Find(id);

            if (personagen.Nome != null)
            {
                personagemBuscado.Nome = personagen.Nome;
            }
            if (personagemBuscado.CapacidadeVida >0)
            {
                personagemBuscado.CapacidadeVida = personagen.CapacidadeVida;
            }
            if (personagen.CapacidadeMana >0)
            {
                personagemBuscado.CapacidadeMana = personagen.CapacidadeMana;
            }

            ctx.Personagens.Update(personagemBuscado);

            ctx.SaveChanges();
        }
        
        public void Deletar(int id)
        {
            Personagen personagemBuscado = ctx.Personagens.Find(id);

            ctx.Personagens.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

    }
}
