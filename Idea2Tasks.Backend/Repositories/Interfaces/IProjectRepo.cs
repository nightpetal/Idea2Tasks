using Idea2Tasks.Backend.Models;

namespace Idea2Tasks.Backend.Repositories.Interface
{
    public interface IProjectRepo
    {
        Task<Project?> AddProjectAsync(Project project);
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<Project?> UpdateAsync(int id, Project project);
        Task<bool> DeleteAsync(int id);
    }
}