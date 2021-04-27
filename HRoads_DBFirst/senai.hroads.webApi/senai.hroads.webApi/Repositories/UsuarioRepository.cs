using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioBuscado.IdTipoUsuario != null)
            {
                usuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;
            }
            if (usuarioBuscado.Email != null)
            {
                usuarioBuscado.Email = usuario.Email;
            }
            if (usuarioBuscado.Senha != null)
            {
                usuarioBuscado.Senha = usuario.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuario =  ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);

            return usuario;
        }
    }
}
