using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doplan.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        public Task InsertAsync(T obj);
        Task Update(T obj);
        void Delete(int id);
        public Task SaveChangesAsync();
    }
}
