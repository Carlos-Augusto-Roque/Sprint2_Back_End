using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SP_Medical_Group.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
                
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
