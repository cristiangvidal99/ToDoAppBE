using Api.Models;

namespace Api.Interfaces
{
    public interface ITaskRepository
    {
        Task<Tasks> CreateTask(Tasks task);
    }
}
