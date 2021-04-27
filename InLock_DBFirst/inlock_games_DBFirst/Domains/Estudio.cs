using System;
using System.Collections.Generic;

#nullable disable

namespace inlock_games_DbFirst.Domains
{
    public partial class Estudio
    {
        public Estudio()
        {
            Jogos = new HashSet<Jogo>();
        }

        public int IdEstudio { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
