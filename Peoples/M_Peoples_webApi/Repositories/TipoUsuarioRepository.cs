using M_Peoples_webApi.Domains;
using M_Peoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog= M_Peoples; user Id=sa; pwd=1234";

        public void Cadastrar(TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TiposUsuarios (Descricao) VALUES(@Descricao)";

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", tipoUsuario.descricao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
          

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> listaTipos = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection (stringConexao))
            {
                string querySelectAll = "SELECT * FROM TiposUsuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            descricao = rdr["Descricao"].ToString()
                        };

                        listaTipos.Add(tipoUsuario);
                    }
                }
            }

            return listaTipos;
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string querySelectById = "SELECT IdTipoUsuario,Descricao FROM TiposUsuarios WHERE IdTipoUsuario = @IdTipoUsuario";

                
                con.Open();

                
                SqlDataReader rdr;

                
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", id);

                   
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                           
                            idTipoUsuario = Convert.ToInt32(rdr[0]),
                            
                            descricao = rdr[1].ToString()
                            

                        };

                        
                        return tipoUsuario;
                    }

                   
                    return null;
                }
            }
        }

        public void Atualizar(int id,TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE TiposUsuarios SET Descricao = @Descricao WHERE IdTipoUsuario = @IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", id);
                    cmd.Parameters.AddWithValue("@Descricao", tipoUsuario.descricao);
                                        
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TiposUsuarios WHERE IdTipoUsuario = @IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
