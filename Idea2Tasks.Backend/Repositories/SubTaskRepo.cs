using Idea2Tasks.Backend.Data;
using Idea2Tasks.Backend.Models;
using Idea2Tasks.Backend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Idea2Tasks.Backend.Repositories
{
    public class SubTaskRepo : ISubTaskRepo
    {
        private readonly AppDb _appDb;

        public SubTaskRepo(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<SubTask?> AddSubTaskAsync(SubTask subTask)
        {
            await _appDb.SubTasks.AddAsync(subTask);
            await _appDb.SaveChangesAsync();
            return subTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _appDb.SubTasks.FindAsync(id);
            if (user is null)
                return false;
            _appDb.SubTasks.Remove(user);
            await _appDb.SaveChangesAsync();
            return true;
        }

        public async Task<List<SubTask>> GetAllAsync()
        {
            return await _appDb.SubTasks.ToListAsync();
        }

        public async Task<SubTask?> GetByIdAsync(int id)
        {
            var user = await _appDb.SubTasks.FindAsync(id);
            if (user is null)
                return null;
            return user;
        }

        public async Task<SubTask?> UpdateAsync(int id, SubTask subTask)
        {
            var existingSubTask = await _appDb.SubTasks.FindAsync(id);
            if (existingSubTask is null)
                return null;

            existingSubTask.Description = subTask.Description;
            existingSubTask.IsCompleted = subTask.IsCompleted;
            existingSubTask.DurationInHrs = subTask.DurationInHrs;
            existingSubTask.ProjectId = subTask.ProjectId;

            await _appDb.SaveChangesAsync();
            return existingSubTask;
        }
    }
}