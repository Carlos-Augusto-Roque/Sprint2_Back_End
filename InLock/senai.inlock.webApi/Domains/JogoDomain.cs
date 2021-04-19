using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public int idEstudio { get; set; }
        public EstudioDomain estudio { get; set; }

        [Required(ErrorMessage = "Campo do nome obrigatório ! ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo da descrição obrigatório ! ")]
        public string descricao { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo da data do lançamento obrigatório ! ")]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "Campo do valor obrigatório ! ")]
        public decimal valor { get; set; }
    }
}
