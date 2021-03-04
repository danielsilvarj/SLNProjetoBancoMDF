using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoMDF.Contratos
{
    public interface IClienteRepositorio : IGenericRepositorio<Cliente>
    {
        List<Cliente> ConsultarPorNome(string nome);
    }
}
