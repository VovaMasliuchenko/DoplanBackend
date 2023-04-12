using Doplan.Data.Entities;

namespace Doplan.Interfaces.Repositories
{
    public interface ITaskToDoRepository : IGenericRepository<TaskToDo>
    {
        public Task<List<TaskToDo>> GetTasksForUserAsync(string userId);
    }
}
