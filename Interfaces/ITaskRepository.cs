using Api.Models;

namespace Api.Interfaces
{
    public interface ITaskRepository
    {
        Task<CreateTask> CreateTask(CreateTask task);
        Task<string> DeleteTask(int id);
        Task<Tasks> UpdateTask(Tasks task);

    }
}
