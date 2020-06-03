using Mercado.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dados
{
    public class ProdutoDAO
    {
        private string _connectionString = @"Server=localhost;port=3306;Database=mercado_db;Uid=root;Pwd=P@ssw0rd;";

        public ProdutoDAO()
        {
        }

        public void AdicionarProduto(Produto novoProduto)
        {           
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO
                
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO
                    
                    //CRIA SCRIPT
                    string sql = @"INSERT INTO TB_PRODUTO (NOME, PRECO, CATEGORIA, QNT_ESTOQUE) 
                                   VALUES (@NOME, @PRECO, @CATEGORIA, @QNT_ESTOQUE);";

                    //ADICIONANDO PARAMETROS
                    comando.Parameters.AddWithValue("@NOME", novoProduto.Nome);
                    comando.Parameters.AddWithValue("@PRECO", novoProduto.Preco);
                    comando.Parameters.AddWithValue("@CATEGORIA", novoProduto.Categoria);
                    comando.Parameters.AddWithValue("@QNT_ESTOQUE", novoProduto.QuantidadeEstoque);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
               
        public List<Produto> BuscaTodos()
        {
            var listaProduto = new List<Produto>(); //CRIA LISTA

            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, PRECO, CATEGORIA, QNT_ESTOQUE FROM TB_PRODUTO;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    MySqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PRODUTO BUSCADO
                        Produto produtoBuscado = new Produto();
                        produtoBuscado.Id = int.Parse(leitor["ID"].ToString());
                        produtoBuscado.Nome = leitor["NOME"].ToString();
                        produtoBuscado.Preco = double.Parse(leitor["PRECO"].ToString());
                        produtoBuscado.Categoria = leitor["CATEGORIA"].ToString();

                        //ADICIONA NA LISTA
                        listaProduto.Add(produtoBuscado);
                    }
                }
            }

            return listaProduto;
        }

        public void DeletarProduto(Produto produtoBuscado)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM TB_PRODUTO WHERE ID = @ID;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@ID", produtoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarProduto(Produto produtoBuscado)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE TB_PRODUTO SET QNT_ESTOQUE = @QNT_ESTOQUE WHERE ID = @ID;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@ID", produtoBuscado.Id);
                    comando.Parameters.AddWithValue("@QNT_ESTOQUE", produtoBuscado.QuantidadeEstoque);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();    
                }
            }
        }

        public DataTable BuscaTodosDT()
        {
            var listaProduto = new DataTable(); //CRIA LISTA

            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, PRECO, CATEGORIA, QNT_ESTOQUE FROM TB_PRODUTO;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    MySqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    listaProduto.Load(leitor);
                }
            }

            return listaProduto;
        }

        public List<Produto> BuscaPorNome(string nome)
        {
            var listaProduto = new List<Produto>(); //CRIA LISTA

            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, PRECO, CATEGORIA, QNT_ESTOQUE FROM TB_PRODUTO WHERE NOME LIKE '@NOMEBUSCA';"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@NOMEBUSCA", nome + '%');

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    MySqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PRODUTO BUSCADO
                        Produto produtoBuscado = new Produto();
                        produtoBuscado.Id = int.Parse(leitor["ID"].ToString());
                        produtoBuscado.Nome = leitor["NOME"].ToString();
                        produtoBuscado.Preco = double.Parse(leitor["PRECO"].ToString());
                        produtoBuscado.Categoria = leitor["CATEGORIA"].ToString();

                        //ADICIONA NA LISTA
                        listaProduto.Add(produtoBuscado);
                    }
                }
            }

            return listaProduto;
        }

        public Produto BuscarPorId(int id)
        {
            var produtoBuscado = new Produto(); //CRIA LISTA

            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, PRECO, CATEGORIA, QNT_ESTOQUE FROM TB_PRODUTO WHERE ID = @ID;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@ID",id);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    MySqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PRODUTO BUSCADO
                        produtoBuscado.Id = int.Parse(leitor["ID"].ToString());
                        produtoBuscado.Nome = leitor["NOME"].ToString();
                        produtoBuscado.Preco = double.Parse(leitor["PRECO"].ToString());
                        produtoBuscado.Categoria = leitor["CATEGORIA"].ToString();
                        produtoBuscado.QuantidadeEmEstoque(int.Parse(leitor["QNT_ESTOQUE"].ToString()));
                    }
                }
            }

            return produtoBuscado;
        }

    }
}
