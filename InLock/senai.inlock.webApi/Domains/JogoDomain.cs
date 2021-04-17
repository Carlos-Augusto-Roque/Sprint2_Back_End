using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public int idEstudio { get; set; }
        public EstudioDomain estudio { get; set; }

        public string nome { get; set; }

        public string descricao { get; set; }

        public DateTime dataLancamento { get; set; }

        public float valor { get; set; }
    }
}
