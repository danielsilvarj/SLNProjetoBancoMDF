using ProjetoBancoMDF.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoMDF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n - CONTROLE DE CLIENTES - \n");
            Console.WriteLine("1) Cadastrar Cliente");
            Console.WriteLine("2) Atualizar Cliente");
            Console.WriteLine("3) Excluir Cliente");
            Console.WriteLine("4) Consultar todos os Clientes");
            Console.WriteLine("5) Consultar Clientes por nome");
            Console.Write("\nInforme a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine());
            ClienteControle ct = new ClienteControle();
            switch (opcao)
            {
                case 1:
                    ct.CadastrarCliente();
                    break;
                case 2:
                    ct.AtualizarCliente();
                    break;
                case 3:
                    ct.ExcluirCliente();
                    break;
                case 4:
                    ct.ConsultarClientes();
                    break;
                case 5:
                    ct.ConsultarClientesPorNome();
                    break;
                default:
                    Console.WriteLine("\nOpção inválida.");
                    break;
            }

            Console.ReadKey(); //pausando..
        }
    }
}
