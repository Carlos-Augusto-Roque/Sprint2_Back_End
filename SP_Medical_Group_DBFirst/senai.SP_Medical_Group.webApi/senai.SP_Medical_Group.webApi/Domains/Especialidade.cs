using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SP_Medical_Group.webApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string DescricaoEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
