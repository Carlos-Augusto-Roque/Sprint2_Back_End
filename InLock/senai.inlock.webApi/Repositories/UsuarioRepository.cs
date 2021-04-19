using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog= inlock_games_manha; user Id=sa; pwd=1234";
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuarios (IdTipoUsuario,Email,Senha)" +
                                     "VALUES (@IdTipoUsuario,@Email,@Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
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
                string querySelectAll = "SELECT Usuarios.IdUsuario,Usuarios.IdTipoUsuario,Usuarios.Email,Usuarios.Senha,TiposUsuarios.Titulo FROM Usuarios INNER JOIN TiposUsuarios ON Usuarios.IdTipoUsuario = TiposUsuarios.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            idTipoUsuario = Convert.ToInt32(rdr[1]),
                            email = rdr[2].ToString(),
                            senha = rdr[3].ToString(),
                            

                            tipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = rdr[4].ToString()
                            }
                        };

                        listaUsuario.Add(usuario);
                    }
                }
            }

            return listaUsuario;
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetById = "SELECT Usuarios.IdUsuario,Usuarios.IdTipoUsuario,Usuarios.Email,Usuarios.Senha,TiposUsuarios.Titulo FROM Usuarios INNER JOIN TiposUsuarios ON Usuarios.IdUsuario = @IdUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGetById, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            idTipoUsuario = Convert.ToInt32(rdr[1]),
                            email = rdr[2].ToString(),
                            senha = rdr[3].ToString(),


                            tipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = rdr[4].ToString()
                            }
                        };

                        return usuario;
                    }
                    return null;
                }
            }

        }

        public void Atualizar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE  Usuarios SET IdTipoUsuario = @IdTipoUsuario,Email = @Email,Senha = @Senha WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.idUsuario);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.senha);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public UsuarioDomain Login(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT IdUsuario,IdTipoUsuario,Email,Senha FROM Usuarios WHERE Email = @Email AND Senha = @Senha;";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            idUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString()                            
                        };
                        // Retorna o usuário buscado
                        return usuario;
                    }
                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
