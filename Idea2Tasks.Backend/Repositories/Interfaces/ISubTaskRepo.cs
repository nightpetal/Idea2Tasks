using Idea2Tasks.Backend.Models;

namespace Idea2Tasks.Backend.Repositories.Interface
{
    public interface ISubTaskRepo
    {
        Task<SubTask?> AddSubTaskAsync(SubTask subTask);
        Task<List<SubTask>> GetAllAsync();
        Task<SubTask?> GetByIdAsync(int id);
        Task<SubTask?> UpdateAsync(int id, SubTask subTask);
        Task<bool> DeleteAsync(int id);
    }
}