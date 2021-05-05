using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SP_Medical_Group.webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public int? IdStatusConsulta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório !")]
        public TimeSpan HorarioConsulta { get; set; }

        public string DescricaoAtendimento { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual StatusConsulta IdStatusConsultaNavigation { get; set; }
    }
}
