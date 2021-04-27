using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        
        public int IdHabilidade { get; set; }
        public int? IdTipoHabilidade { get; set; }

        [Required(ErrorMessage = "Nome obrigatório !")]
        public string Nome { get; set; }

        public virtual TiposDeHabilidade IdTipoHabilidadeNavigation { get; set; }

                    

    }
}
