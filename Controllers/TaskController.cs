using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly ITaskService _taskService;
        
        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public Task<List<Tasks>> GetAllTasks()
        {
            _logger.LogInformation($"-HttpGet: {nameof(GetAllTasks)}-");
            return _taskService.GetAllTasks();
        }

        [HttpGet("GetTaskById")]
        public Task<Tasks> GetTaskById(int id)
        {
            _logger.LogInformation($"-HttpGet: {nameof(GetTaskById)}-");
            return _taskService.GetTaskById(id);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTask task)
        {
            try
            {
                _logger.LogInformation($"-HttpPost: {nameof(CreateTask)}-");
                var result = await _taskService.CreateTask(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la tarea");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<string> DeleteTask(int id)
        {
            _logger.LogInformation($"-HttpPost: {nameof(DeleteTask)}-");
            var result = await _taskService.DeleteTask(id);
            return result;
        }
        [HttpPut("UpdateTask")]
        public Task<Tasks> UpdateTask(Tasks task)
        {
            _logger.LogInformation($"-HttpPost: {nameof(UpdateTask)}-");
            return _taskService.UpdateTask(task);
        }
    }
}
