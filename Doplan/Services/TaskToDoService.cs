using AutoMapper;
using Doplan.Data.Entities;
using Doplan.Interfaces.Repositories;
using Doplan.Interfaces.Services;
using Doplan.Models.DTO.Requests;
using Doplan.Models.DTO.Responses;

namespace Doplan.Services
{
    public class TaskToDoService : ITaskToDoService
    {

        private readonly IMapper mapper;
        private readonly ITaskToDoRepository taskToDoRepository;
        public TaskToDoService(IMapper _mapper, ITaskToDoRepository _taskToDoRepository)
        {
            mapper = _mapper;
            taskToDoRepository = _taskToDoRepository;
        }

        public async Task DeleteAsync(int id)
        {
            taskToDoRepository.Delete(id);
            await taskToDoRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskToDoResponse>> GetAll()
        {
            var task = await taskToDoRepository.GetAll();
            return mapper.Map<List<TaskToDoResponse>>(task);
        }

        public async Task<TaskToDoResponse> GetByIdAsync(int id)
        {
                var task = await taskToDoRepository.GetById(id);
                return mapper.Map<TaskToDoResponse>(task);      
        }

        public async Task InsertAsync(TaskToDoRequest request)
        {
            var task = mapper.Map<TaskToDoRequest, TaskToDo>(request);
            await taskToDoRepository.InsertAsync(task);
            await taskToDoRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskToDoRequest request)
        {
            var task = mapper.Map<TaskToDoRequest, TaskToDo>(request);
            await taskToDoRepository.Update(task);
            await taskToDoRepository.SaveChangesAsync();
        }

        public async Task<List<TaskToDo>> GetTasksForUserAsync(string userId)
        {
            var todos = await taskToDoRepository.GetTasksForUserAsync(userId);
            return todos;
        }
    }
}
