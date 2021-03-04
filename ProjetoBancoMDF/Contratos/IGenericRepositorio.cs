using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoMDF.Contratos
{
    public interface IGenericRepositorio<T>
    {
        void Inserir(T obj);
        void Atualizar(T obj);
        void Excluir(int id);
        List<T> ConsultarTodos();
        T ConsultarPorId(int id);
    }
}
