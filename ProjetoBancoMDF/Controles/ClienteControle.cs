using ProjetoBancoMDF.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoMDF.Controles
{
    public class ClienteControle
    {
        public void CadastrarCliente()
        {
            try
            {
                Console.WriteLine("\n-CADASTRO DE CLIENTE-\n");
                Cliente c = new Cliente();

                Console.Write("Nome do Cliente........: ");
                c.Nome = Console.ReadLine();
                Console.Write("Email do Cliente.......: ");
                c.Email = Console.ReadLine();
                c.DataCadastro = DateTime.Now; //data do sistema..
                ClienteRepositorio rep = new ClienteRepositorio();
                rep.Inserir(c); //gravando no banco de dados..
                Console.WriteLine("\nCliente cadastrado com sucesso.");

            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }

        //método para atualizar os dados de um cliente..
        public void AtualizarCliente()
        {
            try
            {
                Console.WriteLine("\n - ATUALIZAR CLIENTE - \n");
                Console.Write("Informe o Id...: ");
                int idCliente = int.Parse(Console.ReadLine());

                //buscar o cliente pelo id..
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ConsultarPorId(idCliente);
                //verificar se um cliente foi encontrado..
                if (c != null)
                {
                    Console.Write("Informe o Nome.: ");
                    c.Nome = Console.ReadLine();
                    Console.Write("Informe o Email: ");
                    c.Email = Console.ReadLine();
                    rep.Atualizar(c); //atualizando na base de dados..
                    Console.WriteLine("\nCliente atualizado com sucesso.");
                }
                else
                {
                    //imprimir mensagem de erro..
                    Console.WriteLine("\nCliente não foi encontrado.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }

        //método para excluir o cliente..
        public void ExcluirCliente()
        {
            try
            {
                Console.WriteLine("\n - EXCLUIR CLIENTE - \n");
                Console.Write("Informe o Id....: ");
                int idCliente = int.Parse(Console.ReadLine());

                //buscar o cliente no banco de dados pelo id..
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ConsultarPorId(idCliente);

                //verificar se o cliente foi encontrado..
                if (c != null)
                {
                    rep.Excluir(idCliente);
                    Console.WriteLine("\nCliente excluido com sucesso -> "
                   + c.ToString());
                }
                else
                {
                    Console.WriteLine("\nCliente não foi encontrado.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }

        public void ConsultarClientes()
        {
            try
            {
                Console.WriteLine("\n - CONSULTA DE CLIENTES - \n");
                ClienteRepositorio rep = new ClienteRepositorio();
                List<Cliente> lista = rep.ConsultarTodos();
                Console.WriteLine($"\n{lista.Count} Cliente(s) obtidos:");
                //varrer uma lista..
                foreach (Cliente c in lista)
                {
                    //imprimindo o ToString() de cada Cliente..
                    Console.WriteLine(c.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }

        public void ConsultarClientesPorNome()
        {
            try
            {
                Console.WriteLine("\n - CONSULTA DE CLIENTES POR NOME - \n");
                Console.Write("Informe o nome...: ");
                string nome = Console.ReadLine();
                ClienteRepositorio rep = new ClienteRepositorio();
                List<Cliente> lista = rep.ConsultarPorNome(nome);
                Console.WriteLine($"\n{lista.Count} Cliente(s) obtidos:");
                //varrer uma lista..
                foreach (Cliente c in lista)
                {
                    //imprimindo o ToString() de cada Cliente..
                    Console.WriteLine(c.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }

    }
}
