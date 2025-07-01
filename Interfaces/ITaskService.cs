using Api.Models;

namespace Api.Interfaces
{
    public interface ITaskService
    {
        Task<Tasks> GetTaskById(int id);
        Task<Tasks> CreateTask(Tasks task);
    }
}
