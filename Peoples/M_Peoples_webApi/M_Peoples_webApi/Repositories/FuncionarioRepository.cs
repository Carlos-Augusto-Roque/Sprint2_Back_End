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

        //metodo para listar os funcionarios
        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>(); // instanciado um objeto (uma lista de funcionarios)

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
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //atribui á propriedade IdFuncionario o valor da primeira coluna da tabela do bd
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            //atribui á propriedade nome o valor da segunda coluna da tabela do bd
                            nome = rdr[1].ToString(),
                            //atribui á propriedade nome o valor da terceira coluna da tabela do bd
                            sobrenome = rdr[2].ToString(),
                            //atribui á propriedade nome o valor da quarta coluna da tabela do bd
                            dataNascimento = rdr[3].ToString()
                        };

                        //adiciona o objeto funcionario á lista  listaFuncionarios
                        listaFuncionarios.Add(funcionario);
                    }
                }

            }
            //retorna a lista de funcionarios
            return listaFuncionarios;

        }

        //metodo para buscar um funcionario pelo seu id
        public FuncionarioDomain BuscarPorId(int id)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelectById = "SELECT * FROM Funcionarios WHERE IdFuncionario = @idFuncionario";

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
                            idFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            //atribui á propriedade Nome o valor da coluna Nome da tabela do bd
                            nome = rdr["Nome"].ToString(),
                            //atribui á propriedade Nome o valor da coluna Sobrenome da tabela do bd
                            sobrenome = rdr["Sobrenome"].ToString(),
                            //atribui á propriedade Nome o valor da coluna DataNascimento da tabela do bd
                            dataNascimento = rdr["DataNascimento"].ToString(),

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


        //metodo para buscar um funcionario pelo seu nome
        public FuncionarioDomain BuscarPorNome(string nome)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelectByName = "SELECT * FROM Funcionarios WHERE Nome = @nome";

                //conecta o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executa e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectByName, con))
                {
                    //passa o valor para o parametro @idFuncionario
                    cmd.Parameters.AddWithValue("@nome", nome);

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
                            idFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            //atribui á propriedade Nome o valor da coluna Nome da tabela do bd
                            nome = rdr["Nome"].ToString(),
                            //atribui á propriedade Nome o valor da coluna Sobrenome da tabela do bd
                            sobrenome = rdr["Sobrenome"].ToString(),
                            //atribui á propriedade Nome o valor da coluna DataNascimento da tabela do bd
                            dataNascimento = rdr["DataNascimento"].ToString(),

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

        //metodo para mostrar somente o nome completo do funcionario (buscado pelo id)
        public FuncionarioDomain NomesCompletos(int id)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string querySelect = "SELECT Nome, Sobrenome FROM Funcionarios WHERE Funcionarios.IdFuncionario = @idFuncionario";

                //conecta o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executa e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    //passa o valor para o parametro @idFuncionario
                    cmd.Parameters.AddWithValue("@idfuncionario", id);

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim,
                        //instancia um novo objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain func = new FuncionarioDomain()

                        {
                            //atribui á propriedade Nome o valor da coluna Nome + Sobrenome
                            nome = rdr["Nome"].ToString() + " " + rdr["Sobrenome"].ToString()
                        };

                        //retorna o nome e sobrenome do funcionario buscado
                        return func;
                    }

                    //se não,
                    //retorna null
                    return null;
                }
            }
        }


        //metodo para deletar um usuario pelo seu id
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

        //metodo para atualizar um funcionario passando o id no corpo da requisicao
        public void Atualizar(FuncionarioDomain funcionario)
        {
            //propiedade que vai assegurar que o bd se desconecte ao encerrar a aplicação
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declarado a instrução a ser executada
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome,Sobrenome = @Sobrenome,DataNascimento = @DataNascimento WHERE IdFuncionario = @IdFuncionario";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    //passa os valores para os paramentros 
                    cmd.Parameters.AddWithValue("@Nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.dataNascimento);
                    cmd.Parameters.AddWithValue("@IdFuncionario", funcionario.idFuncionario);

                    //conectar o bd
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //metodo para cadastrar um funcionario
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            //declara a SqlConnection con , passando a string conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Funcionarios(Nome,Sobrenome,DataNascimento) VALUES (@Nome,@Sobrenome,@DataNascimento)";

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

        
    }
}
