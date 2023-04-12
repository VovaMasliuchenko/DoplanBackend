using Doplan.Data.Context;
using Doplan.Data.Entities;
using Doplan.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doplan.Data.Repositories
{
    public class TaskToDoRepository : GenericRepository<TaskToDo>, ITaskToDoRepository
    {

        private readonly DoplanDBContext _dbContext;

        public TaskToDoRepository(DoplanDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskToDo>> GetTasksForUserAsync(string userId)
        {
            return await _dbContext.TaskToDo.Where(t => t.Id_User == userId).ToListAsync();
        }

    }
}
