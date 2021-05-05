using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SP_Medical_Group.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
               
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public int? IdClinica { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public int? IdEspecialidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string NomeMedico { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public string CRM { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
