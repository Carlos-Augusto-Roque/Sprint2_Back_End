using M_Peoples_webApi.Domains;
using M_Peoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples_webApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        //criado uma string de conexao para ter acesso ao bd
        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog=M_Peoples; user Id=sa; pwd=1234";


        //CRUD - Criação dos métodos , começando pelo crud

        //Método Create
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            //declara a SqlConnection con , passando a string conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Funcionarios(Nome,Sobrenome,DataNascimento)" + "VALUES (@Nome,@Sobrenome,@DataNascimento)";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //passa os valores para os paramentros 
                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", novoFuncionario.dataNascimento);

                    //conectar o bd
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Método Read
        public List<FuncionarioDomain> ListarTodos()
        {
            // instanciado um objeto (uma lista de funcionarios)
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>(); 

            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario,Nome,Sobrenome,DataNascimento FROM Funcionarios ";

                //conectar o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos no rdr, o laco se repete
                    while (rdr.Read())
                    {
                        //instacia um objeto genero do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            //atribui á propriedade IdFuncionario o valor da primeira coluna da tabela do bd
                            idFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            //atribui á propriedade nome o valor da segunda coluna da tabela do bd
                            nome = rdr["Nome"].ToString(),
                            //atribui á propriedade nome o valor da terceira coluna da tabela do bd
                            sobrenome = rdr["Sobrenome"].ToString(),
                            //atribui á propriedade nome o valor da quarta coluna da tabela do bd
                            dataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        //adiciona o objeto funcionario á lista  listaFuncionarios
                        listaFuncionarios.Add(funcionario);
                    }
                }

            }

            //retorna a lista de funcionarios
            return listaFuncionarios;

        }

        //Método Update
        public void Atualizar(FuncionarioDomain funcionario)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome,Sobrenome = @Sobrenome,DataNascimento = @DataNascimento WHERE IdFuncionario = @IdFuncionario";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    //passa os valores para os paramentros 
                    cmd.Parameters.AddWithValue("@IdFuncionario", funcionario.idFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.dataNascimento);

                    //conectar o bd
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Método Delete
        public void Deletar(int id)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //passa os valores para os paramentros 
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);

                    //conectar o bd
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Métodos que atendem os extras do projeto

        //Método para buscar um funcionario pelo seu id
        public FuncionarioDomain BuscarPorId(int id)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelectById = "SELECT IdFuncionario,Nome,Sobrenome,DataNascimento FROM Funcionarios WHERE IdFuncionario = @idFuncionario";

                //conecta o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executa e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //passa o valor para o parametro @idFuncionario
                    cmd.Parameters.AddWithValue("@idFuncionario", id);

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim,
                        //instancia um novo objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            //atribui á propriedade idGenero o valor da coluna idGenero da tabela do bd
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            //atribui á propriedade Nome o valor da coluna Nome da tabela do bd
                            nome = rdr[1].ToString(),
                            //atribui á propriedade Nome o valor da coluna Sobrenome da tabela do bd
                            sobrenome = rdr[2].ToString(),
                            //atribui á propriedade Nome o valor da coluna DataNascimento da tabela do bd
                            dataNascimento = Convert.ToDateTime(rdr[3])

                        };

                        //retorna o funcionario com os dados obtidos
                        return funcionario;
                    }

                    //se não,
                    //retorna null
                    return null;
                }
            }
        }


        //metodo para buscar uma lista de funcionarios pelo nome
        public List<FuncionarioDomain> BuscarPorNome(string nome)
        {
            //criado uma lista de funcionarios onde serao armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelectAll = "SELECT * FROM Funcionarios WHERE Nome = @Nome";

                //conecta o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executa e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos,o laco se repete
                    while (rdr.Read())
                    {
                        //instancia um novo objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            //atribui á propriedade idGenero o valor da coluna idGenero da tabela do bd
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            //atribui á propriedade Nome o valor da coluna Nome da tabela do bd
                            nome = rdr[1].ToString(),
                            //atribui á propriedade Nome o valor da coluna Sobrenome da tabela do bd
                            sobrenome = rdr[2].ToString(),
                            //atribui á propriedade Nome o valor da coluna DataNascimento da tabela do bd
                            dataNascimento = Convert.ToDateTime(rdr[3])

                        };

                        //retorna o funcionario com os dados obtidos
                        funcionarios.Add(funcionario);
                    }
                }
            }

            //retorna a lista dos funcionarios
            return funcionarios;
        }


        //metodo para listar o nome completo dos funcionarios 
        public FuncionarioDomain NomesCompletos(int id)
        {
            //criado uma lista de funcionarios onde serao armazenados os dados
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelect = "SELECT IdFuncionario, Nome,Sobrenome,DataNascimento FROM Funcionarios WHERE Funcionarios.IdFuncionario = @IdFuncionario";

                //conecta o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executa e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {

                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos,o laco se repete
                    while (rdr.Read())
                    {
                        
                        //instancia um novo objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()

                        {
                            //atribui á propriedade IdFuncionario o valor da coluna IdFuncionario do bd
                            idFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            //atribui á propriedade Nome o valor da coluna Nome + Sobrenome
                            nome = rdr["Nome"].ToString() + " " + rdr["Sobrenome"].ToString(),

                            //atribui á propriedade DataNascimento o valor da coluna DataNascimento
                            dataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        return funcionario;

                    }

                    return null;
                }
            }
        }

        //metodo para listar os funcionarios de forma ordenada ASC ou DESC
        public List<FuncionarioDomain> ListarOrdenado(string ordem)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario,Nome,Sobrenome,DataNascimento " + $"FROM Funcionarios ORDER BY Nome {ordem}";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            nome = rdr["Nome"].ToString(),
                            sobrenome = rdr["Sobrenome"].ToString(),
                            dataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }
    }
}
