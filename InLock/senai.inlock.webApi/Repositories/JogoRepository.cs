using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog= inlock_games_manha; user Id=sa; pwd=1234";

        public void Cadastrar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos (IdEstudio,Nome,Descricao,DataLancamento,Valor)" +
                                     "VALUES (@IdEstudio,@Nome,@Descricao,@DataLancamento,@Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.idEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT Jogos.Nome,Jogos.IdJogo,Jogos.Descricao,Jogos.DataLancamento,Jogos.Valor,Estudios.IdEstudio,Estudios.Nome From Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            nome = rdr[0].ToString(),
                            idJogo = Convert.ToInt32(rdr[1]),
                            descricao = rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToInt32(rdr[4]),
                            
                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(rdr[5]),
                                nome = rdr[6].ToString()
                            }
                        };

                        listaJogo.Add(jogo);
                    }
                }
            }

            return listaJogo;
        }
    }
}
