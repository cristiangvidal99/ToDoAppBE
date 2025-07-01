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

        [HttpGet("GetTaskById")]
        public Task<Tasks> GetTaskById(int id)
        {
            _logger.LogInformation($"-HttpGet: {nameof(GetTaskById)}-");
            return _taskService.GetTaskById(id);
        }

        [HttpPost("CreateTask")]
        public Task<Tasks> CreateTask(Tasks task)
        {
            _logger.LogInformation($"-HttpPost: {nameof(CreateTask)}-");
            return _taskService.CreateTask(task);
        }
    }
}
