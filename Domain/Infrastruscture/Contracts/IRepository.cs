using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastruscture.Contracts
{
    public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> Get();

        Task<T> Get(string id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(string id);
    }
}
