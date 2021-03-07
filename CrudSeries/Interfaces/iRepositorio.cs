using System.Collections.Generic;

namespace CrudSeries.Interfaces
{
    public interface iRepositorio<T>
    {
        List<T> Lista();
        T RetornarPorId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(int id,T entidade);
        int ProximoId();
    }
}