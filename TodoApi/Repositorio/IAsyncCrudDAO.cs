using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Repositorio
{
    public interface IAsyncCrudDAO<T>
    {
        void Create(T item);
        Task<List<T>> Get();
        Task<T> Find(long id);
        void Initialize();

    }
}
