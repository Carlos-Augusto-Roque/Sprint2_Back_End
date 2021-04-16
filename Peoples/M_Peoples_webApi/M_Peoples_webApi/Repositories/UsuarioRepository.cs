using M_Peoples_webApi.Domains;
using M_Peoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=senai@132";
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuarios (IdTipoUsuario,Email,Senha) VALUES (@IdTipoUsuario,@Email,@Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Usuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString()

                        };

                        listaUsuario.Add(usuario);
                                                
                    }
                }
            }

            return listaUsuario;
        }
        
        public void Atualizar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection (stringConexao))
            {
                string queryUpdate = "UPDATE Usuarios SET (IdTipoUsuario = @IdTipoUsuario,Email = @Email,Senha = @Senha WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand (queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.idUsuario);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                };
            }
        }


        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
