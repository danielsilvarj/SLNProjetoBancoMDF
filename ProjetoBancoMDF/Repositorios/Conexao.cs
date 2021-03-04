using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoMDF.Repositorios
{
    public class Conexao
    {
        //atributos..
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;
        //métodos..
        protected void AbrirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConecta"].ConnectionString);
            con.Open(); //conectado..
        }
        protected void FecharConexao()
        {
            con.Close(); //desconectado..
        }
    }
}
