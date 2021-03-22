using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    /// <summary>
    /// classe que representa a entidade Filmes
    /// </summary>
    public class FilmeDomain
    {
        
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string titulo { get; set; }
        public GeneroDomain genero { get; set; }
    }
}
