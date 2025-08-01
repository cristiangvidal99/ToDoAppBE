using Api.Interfaces;
using Api.Models;
using System.Threading.Tasks;

namespace Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public Task<List<Tasks>> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }
        public Task<Tasks> GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }
        public Task<CreateTask> CreateTask(CreateTask task)
        {
            return _taskRepository.CreateTask(task);
        }
        public Task<string> DeleteTask(int id)
        {
            return _taskRepository.DeleteTask(id);
        }
        public Task<Tasks> UpdateTask(Tasks task)
        {
            return _taskRepository.UpdateTask(task);
        }
    }
}
