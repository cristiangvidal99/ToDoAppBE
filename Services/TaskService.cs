using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public Task<Tasks> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Tasks> CreateTask(Tasks task)
        {
            return _taskRepository.CreateTask(task);
        }
    }
}
