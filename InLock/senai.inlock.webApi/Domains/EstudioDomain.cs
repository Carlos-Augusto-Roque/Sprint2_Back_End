using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Campo do nome obrigatório ! ")]
        public string nome { get; set; }

        public JogoDomain jogo { get; set; }
        public int idJogo { get; set; }

    }
}
