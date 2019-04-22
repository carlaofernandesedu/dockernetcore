using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Repositorio
{
    public interface IAsyncCrudDAO<T>
    {
        Task<int> Update(T item);
        Task<int> Create(T item);
        Task<List<T>> Get();
        Task<T> Find(long id);

        Task<int> Delete(T item);
        void Initialize();

    }
}
