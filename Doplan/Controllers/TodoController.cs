using Doplan.Interfaces.Services;
using Doplan.Models.DTO.Requests;
using Doplan.Models.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenToTheMoonEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;

        private ITaskToDoService _taskToDoService;

        public TodoController(ILogger<TodoController> logger, ITaskToDoService taskToDoService)
        {
            _logger = logger;
            _taskToDoService = taskToDoService;
        }

        [HttpGet("GetTodoById")]
        public async Task<ActionResult<TaskToDoResponse>> GetTodoById(int id)
        {
            return Ok(await _taskToDoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskToDoRequest request)
        {
            await _taskToDoService.InsertAsync(request);
            _logger.LogError($"{request.Id_User} - User created todo ({request.Id}) at {DateTime.Now}");
            return Ok();
        }

        [HttpGet("GetTasksForUser")]
        public async Task<IActionResult> GetTasksForUser(string id)
        {
            var tasks = await _taskToDoService.GetTasksForUserAsync(id);
            return Ok(tasks);
        }

        [HttpPost("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskToDoRequest request)
        {
            await _taskToDoService.UpdateAsync(request);
            return Ok();
        }

        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskToDoService.DeleteAsync(id);
            _logger.LogError($"Deleted todo ({id}) at {DateTime.Now}");
            return Ok();
        }
    }
}
