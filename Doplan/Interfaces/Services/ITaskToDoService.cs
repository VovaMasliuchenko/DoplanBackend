using Doplan.Data.Entities;
using Doplan.Models.DTO.Requests;
using Doplan.Models.DTO.Responses;

namespace Doplan.Interfaces.Services
{

    public interface ITaskToDoService
    {
        Task<TaskToDoResponse> GetByIdAsync(int id);
        Task<IEnumerable<TaskToDoResponse>> GetAll();
        Task InsertAsync(TaskToDoRequest request);
        Task UpdateAsync(TaskToDoRequest request);
        Task DeleteAsync(int id);
        Task<List<TaskToDo>> GetTasksForUserAsync(string userId);
    }

}