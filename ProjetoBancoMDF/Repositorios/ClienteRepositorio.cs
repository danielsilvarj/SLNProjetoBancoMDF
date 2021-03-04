using ProjetoBancoMDF.Contratos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoMDF.Repositorios
{
    public class ClienteRepositorio : Conexao, IClienteRepositorio
    {
        public void Atualizar(Cliente obj)
        {
            AbrirConexao();
            string query = "update Cliente set Nome = @Nome, Email = @Email where IdCliente = @IdCliente";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
            cmd.ExecuteNonQuery();
            FecharConexao();

        }

        public Cliente ConsultarPorId(int id)
        {
            AbrirConexao();
            string query = "select * from Cliente where IdCliente = @IdCliente";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCliente", id);
            dr = cmd.ExecuteReader();
            Cliente c = null; //sem espaço de memória..
                              //verificar se algum cliente foi encontrado..
            if (dr.Read())
            {
                c = new Cliente();
                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
            }
            FecharConexao();
            return c;
        }

        public List<Cliente> ConsultarPorNome(string nome)
        {
            AbrirConexao();
            string query = "select * from Cliente where Nome like @Nome";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", $"%{nome}%");
            dr = cmd.ExecuteReader();
            //declarando uma lista de clientes..
            List<Cliente> lista = new List<Cliente>();
            //varrer os clientes obtidos pelo SqlDataReader..
            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
                lista.Add(c); //adicionar na lista..
            }
            FecharConexao();
            //retornando a lista..
            return lista;

        }

        public List<Cliente> ConsultarTodos()
        {
            AbrirConexao();
            string query = "select * from Cliente";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            //declarando uma lista de clientes..
            List<Cliente> lista = new List<Cliente>();
            //varrer os clientes obtidos pelo SqlDataReader..
            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
                lista.Add(c); //adicionar na lista..
            }
            FecharConexao();
            //retornando a lista..
            return lista;

        }

        public void Excluir(int id)
        {
            AbrirConexao();
            string query = "delete from Cliente where IdCliente = @IdCliente";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCliente", id);
            cmd.ExecuteNonQuery();
            FecharConexao();

        }

        public void Inserir(Cliente obj)
        {
            AbrirConexao();
            string query = "insert into Cliente(Nome, Email, DataCadastro) values(@Nome, @Email, @DataCadastro)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", obj.Nome);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@DataCadastro", obj.DataCadastro);

            cmd.ExecuteNonQuery();

            FecharConexao();
        }
    }
}
