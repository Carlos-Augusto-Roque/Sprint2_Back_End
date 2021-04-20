using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    /// <summary>
    /// classe que representa a entidade Generos
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        [Required(ErrorMessage ="O campo nome deve ser preenchido")]
        public string nome { get; set; }
    }
}
