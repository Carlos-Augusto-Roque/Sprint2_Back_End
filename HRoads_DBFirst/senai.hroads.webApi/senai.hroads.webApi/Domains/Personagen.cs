using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagen
    {
        public int IdPersonagem { get; set; }
        public int IdClasse { get; set; }
        public string Nome { get; set; }
        public int CapacidadeVida { get; set; }
        public int CapacidadeMana { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
