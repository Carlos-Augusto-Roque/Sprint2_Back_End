using M_Peoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(UsuarioDomain usuario);

        List<UsuarioDomain> Listar();

        void Atualizar(UsuarioDomain usuario);

        void Deletar(int id);

        //falta metodo buscar por id
    }
}
