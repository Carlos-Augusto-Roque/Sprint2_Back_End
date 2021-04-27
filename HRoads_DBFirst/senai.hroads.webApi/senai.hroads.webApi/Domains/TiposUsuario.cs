using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Titulo obrigatório !")]
        public string Titulo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
