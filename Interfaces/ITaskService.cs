using Api.Models;

namespace Api.Interfaces
{
    public interface ITaskService
    {
        Task<Tasks> GetTaskById(int id);
        Task<Tasks> CreateTask(Tasks task);
        Task<string> DeleteTask(int id);
        Task<Tasks> UpdateTask(Tasks task);
    }
}
