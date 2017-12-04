using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjeto.Dominio.Contrato
{
    public interface IRepositorio<T> where T : class 
    {
        void Salvar(T entidade);
        void Delete(T entidade);
        IEnumerable<T> ListaUsuarios();
        T ListaUsuarioPorId(string valor);
    }
}
