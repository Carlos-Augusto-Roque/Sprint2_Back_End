using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SP_Medical_Group.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage ="Campo obrigatório !")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public TimeSpan HorarioAbertura { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public TimeSpan HorarioFechamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string Site { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string CNPJ { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
