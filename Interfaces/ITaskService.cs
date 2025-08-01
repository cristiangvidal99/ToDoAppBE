using Api.Models;

namespace Api.Interfaces
{
    public interface ITaskService
    {
        Task<List<Tasks>> GetAllTasks();
        Task<Tasks> GetTaskById(int id);

        Task<CreateTask> CreateTask(CreateTask task);
        Task<string> DeleteTask(int id);
        Task<Tasks> UpdateTask(Tasks task);
    }
}
