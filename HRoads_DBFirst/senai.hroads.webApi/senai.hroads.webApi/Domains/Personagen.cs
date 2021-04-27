using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagen
    {
        public int IdPersonagem { get; set; }
        public int IdClasse { get; set; }

        [Required(ErrorMessage = "Nome obrigatório !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Capacidade de Vida obrigatório !")]
        public int CapacidadeVida { get; set; }

        [Required(ErrorMessage = "Capacidade de Mana obrigatório !")]
        public int CapacidadeMana { get; set; }

        [Required(ErrorMessage = "Data de Atualizacao obrigatório !")]
        public DateTime DataAtualizacao { get; set; }

        [Required(ErrorMessage = "Data de Criacao obrigatório !")]
        public DateTime DataCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
