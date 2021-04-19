using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog= inlock_games_manha; user Id=sa; pwd=1234";

        public void Cadastrar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudios (Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand (queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT Estudios.IdEstudio,Estudios.Nome,Jogos.Nome FROM Estudios LEFT JOIN Jogos ON Estudios.IdEstudio = Jogos.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString(),
                            

                            jogo = new JogoDomain()
                            {
                                
                                nome = rdr[2].ToString(),
                                                               
                            }
                        };

                        listaEstudio.Add(estudio);
                    }
                }
            }

            return listaEstudio;
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetById = "SELECT IdEstudio,Nome FROM Estudios WHERE IdEstudio = @IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGetById,con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString()
                            
                        };

                        return estudio;
                    }
                    return null;
                }
            }
        }

        public void Atualizar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Estudios SET Nome = @Nome WHERE IdEstudio = @IdEstudio";

                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", estudio.idEstudio);
                    cmd.Parameters.AddWithValue("@Nome", estudio.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeleteJ = "DELETE FROM Jogos WHERE IdEstudio = @IdEstudio";
                string queryDeleteE = "DELETE FROM Estudios WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDeleteJ, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(queryDeleteE, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                   

                    cmd.ExecuteNonQuery();
                }

            }
        }

    }
}
