using Idea2Tasks.Backend.Data;
using Idea2Tasks.Backend.Models;
using Idea2Tasks.Backend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Idea2Tasks.Backend.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly AppDb _appDb;

        public ProjectRepo(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<Project?> AddProjectAsync(Project project)
        {
            await _appDb.Projects.AddAsync(project);
            await _appDb.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _appDb.Projects.FindAsync(id);
            if (user is null)
                return false;
            _appDb.Projects.Remove(user);
            await _appDb.SaveChangesAsync();
            return true;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _appDb.Projects.Include(p => p.SubTasks).ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var user = await _appDb.Projects
                .Include(p => p.SubTasks)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (user is null)
                return null;
            return user;
        }

        public async Task<Project?> UpdateAsync(int id, Project project)
        {
            var existingProject = await _appDb.Projects.FindAsync(id);
            if (existingProject is null)
                return null;
            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.IsCompleted = project.IsCompleted;
            existingProject.SubTasks = project.SubTasks;
            await _appDb.SaveChangesAsync();
            return existingProject;
        }
    }
}