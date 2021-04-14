using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Domains
{
    //Criar o domínio correspondente
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }

        public string nome { get; set; }
                
        //Exemplo de Data Annotation - (Validação dos campos)
        [Required(ErrorMessage = "O campo sobrenome é obrigatório !")]
        [StringLength(10,MinimumLength = 5 , ErrorMessage = "O campo deve conter de 5 a 10 caracteres")]
        public string sobrenome { get; set; }

        //Data Annotation (especifica o tipo do campo mas não valida o campo)
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }
    }
}