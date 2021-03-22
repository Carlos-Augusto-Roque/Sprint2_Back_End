using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog=Filmes; user Id=sa; pwd=1234";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                                                                                 
                string queryInsert = "INSERT INTO Filmes(IdGenero,Titulo) VALUES (@IdGenero,@titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                   
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.idGenero);

                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.titulo);
                    
                    con.Open();
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

       
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                      
                string queryDelete = "DELETE FROM Filmes WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                   
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();
            
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFilme,Titulo,Nome FROM Filmes INNER JOIN Generos ON Filmes.IdGenero = Generos.idGenero ";
                con.Open();
                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    
                    while (rdr.Read())
                    {
                    FilmeDomain filme = new FilmeDomain()
                                                                   
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            titulo = rdr[1].ToString(),

                            genero = new GeneroDomain()

                        {
                            nome = rdr[2].ToString()
                        }
                    };

                        listaFilmes.Add(filme);
                    }
                }
            }
         return listaFilmes;
        }
    }
}
