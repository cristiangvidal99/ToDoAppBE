using Api.Models;

namespace Api.Interfaces
{
    public interface ITaskRepository
    {
        Task<Tasks> CreateTask(Tasks task);
        Task<string> DeleteTask(int id);
        Task<Tasks> UpdateTask(Tasks task);

    }
}
