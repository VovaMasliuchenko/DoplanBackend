using Doplan.Data.Context;
using Doplan.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doplan.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DoplanDBContext context;
        private DbSet<T> table;
        public bool AutoSaveChanges { get; set; } = true;

        public GenericRepository(DoplanDBContext dbContext)
        {
            context = dbContext;
            table = context.Set<T>();
        }

        public async void Delete(int id)
        {
            var entity = table.Find(id);
            table.Remove(entity); 
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task InsertAsync(T entity) =>
            await table.AddAsync(entity);

        public async Task Update(T obj)
        {
            table.Update(obj);
            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

    }
}
