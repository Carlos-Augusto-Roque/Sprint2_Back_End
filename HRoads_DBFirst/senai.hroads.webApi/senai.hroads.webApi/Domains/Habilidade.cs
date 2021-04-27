using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTipoHabilidade { get; set; }
        public string Nome { get; set; }

        public virtual TiposDeHabilidade IdTipoHabilidadeNavigation { get; set; }
    }
}
