using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(TiposUsuario tipo)
        {
            ctx.TiposUsuarios.Add(tipo);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.Include(t => t.Usuarios).ToList();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.Find(id);
        }

        public void Atualizar(int id, TiposUsuario tipo)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            if (tipoBuscado.Titulo != null)
            {
                tipoBuscado.Titulo = tipo.Titulo;
            }

            ctx.TiposUsuarios.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            ctx.TiposUsuarios.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

    }
}

