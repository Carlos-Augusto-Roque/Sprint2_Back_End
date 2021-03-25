using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Domains
{
    //Criar o domínio correspondente
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string dataNascimento { get; set; }
    }
}


