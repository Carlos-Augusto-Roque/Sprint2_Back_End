using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Domains
{
    public class TipoUsuarioDomain
    {
        public  int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o tipo do usuário !")]
        public string descricao { get; set; }
    }
}
