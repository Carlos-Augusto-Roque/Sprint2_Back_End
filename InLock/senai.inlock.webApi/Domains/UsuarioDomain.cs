using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        public int idTipoUsuario { get; set; }
     
        public TipoUsuarioDomain tipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o email !")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha !")]
        public string senha { get; set; }
    }
}
