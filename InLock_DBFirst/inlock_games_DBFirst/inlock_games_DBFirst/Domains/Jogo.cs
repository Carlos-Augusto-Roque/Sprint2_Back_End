using System;
using System.Collections.Generic;

#nullable disable

namespace inlock_games_DbFirst.Domains
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public int? IdEstudio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }

        public virtual Estudio IdEstudioNavigation { get; set; }
    }
}
