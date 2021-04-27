using inlock_games_DbFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlock_games_DbFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúdios cadastrados
        /// </summary>
        /// <returns>Lista de todos os estudios cadastrados</returns>
        List<Estudio> Listar();

        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estudio buscado</param>
        /// <returns>estudio buscado</returns>
        Estudio BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estúdio 
        /// </summary>
        /// <param name="novoEstudio">objeto novoEstudio que será cadastrado</param>
        void Cadastrar(Estudio novoEstudio);

        /// <summary>
        /// Atualiza um estúdio através de seu id 
        /// </summary>
        /// <param name="id">id do estúdio a ser atualizado</param>
        /// <param name="estudioAtualizado">objeto estudioAtualizado com as novas informações</param>
        void Atualizar(int id, Estudio estudioAtualizado);

        /// <summary>
        /// Deleta um estúdio cadastrado
        /// </summary>
        /// <param name="id">id do estúdio a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os estudios e seus respectivos jogos 
        /// </summary>
        /// <returns>Lista de todos os estúdios e seus respectivos jogos</returns>
        List<Estudio> ListarJogos();
    }
}
