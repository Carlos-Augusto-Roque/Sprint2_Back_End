using M_Peoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuarioDomain tipoUsuario);

        List<TipoUsuarioDomain> Listar();

        void Atualizar(int id,TipoUsuarioDomain tipoUsuario);

        void Deletar(int id);

        //falta metodo buscar por id

    }
}
