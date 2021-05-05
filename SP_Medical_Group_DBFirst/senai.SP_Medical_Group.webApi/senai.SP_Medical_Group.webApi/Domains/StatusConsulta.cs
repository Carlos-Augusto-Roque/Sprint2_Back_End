using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SP_Medical_Group.webApi.Domains
{
    public partial class StatusConsulta
    {
        public StatusConsulta()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdStatusConsulta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string DescricaoStatusConsulta { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
