using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Id do Tipo obrigatório !")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Email obrigatório !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória !")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha deve ter no mínimo 3 e no máximo 20 caracteres")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
