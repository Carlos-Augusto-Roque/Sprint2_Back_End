using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class TiposDeHabilidade
    {
        public TiposDeHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHabilidade { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
