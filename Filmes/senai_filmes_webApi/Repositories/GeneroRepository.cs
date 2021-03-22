using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// classe responsável pelo repositório dos generos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// string de conexao com o banco de dados que recebe os parametros
        /// Data source = nome do servidor
        /// initial catalog = nome do bando de dados
        /// user Id=sa, pwd=1234 = faz a autenticacao com o usuario do SQL SErver passando o logon e senha
        /// integrated security = true = faz  a autenticacao com o usuario do sistema (Windows) 
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog=Filmes; user Id=sa; pwd=1234";
        //private string stringConexao = "Data Source=DESKTOP-84HBQ33; initial catalog=Filmes; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// cadastra novo genero 
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //declara a SqlConnection con , passando a string conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada

                // INSERT INTO Generos(Nome) VALUES('Ficção Científica');
                // INSERT INTO Generos(Nome) VALUES('Joana D'Arc');
                // INSERT INTO Generos(Nome) VALUES('')DROP TABLE Filmes--');

                // string queryInsert = "INSERT INTO Generos(Nome) VALUES('" + novoGenero.nome + "')";

                //Observações:

                // Não usar dessa forma pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE Filmes--"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //passa o valor para o paramentro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    //conectar o bd
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }   
        }


        /// <summary>
        /// deleta um genero
        /// </summary>
        /// <param name="id">id do genero a ser deletado</param>
        public void Deletar(int id)
        {
            // declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "Delete FROM Generos WHERE idGenero = @idGenero";

                // declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // define o valor do id recebido no método como o valor do parâmetro @idGenero
                    cmd.Parameters.AddWithValue("@idGenero", id);

                    // conectar o bd
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// lista todos os generos
        /// </summary>
        /// <returns>uma lista de generos</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //cria uma lista listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //declara a SqlConecction "con" passando a string de conexao como paramentro
            //Após a aplicação acabar, o bd vai se desconectar
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a instrucao a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Generos";

                //Conectar o bd
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos no rdr, o laco se repete
                    while (rdr.Read())
                    {
                        //instacia um objeto genero do tipo generoDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui á propriedade IdGenero o valor da primeira coluna da tabela do bd
                            idGenero = Convert.ToInt32(rdr[0]),
                            //atribui á propriedade nome o valor da segunda coluna da tabela do bd
                            nome = rdr[1].ToString()
                        };

                        //adiciona o objeto genero a lista  listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            //retorna a lista de generos
            return listaGeneros;
        }
    }
}
