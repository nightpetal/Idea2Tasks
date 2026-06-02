using Idea2Tasks.Data;
using Idea2Tasks.DTO;
using Idea2Tasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idea2Tasks.Controllers
{
    [ApiController]
    [Route("api/project/{projectId}/[controller]")]
    public class SubTaskController : ControllerBase
    {
        private readonly AppDb appDb;
        public SubTaskController(AppDb _appDb)
        {
            appDb = _appDb;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(int projectId, SubTaskDTO subTaskDTO)
        {
            SubTask subTask = new SubTask
            {
                Description = subTaskDTO.Description,
                Duration = subTaskDTO.Duration,
                IsCompleted = subTaskDTO.IsCompleted,
                ProjectId = projectId
            };

            appDb.SubTasks.Add(subTask);
            await appDb.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/api/[controller]")]
        public async Task<ActionResult> GetAllTasks()
        {
            var tasks = await appDb.SubTasks.ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<ActionResult> GetTasksById(int id)
        {
            var task = await appDb.SubTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            SubTaskDTO subTaskDTO = new()
            {
                Id = task.Id,
                Description = task.Description,
                Duration = task.Duration,
                IsCompleted = task.IsCompleted,
                ProjectId = task.ProjectId
            };
            return Ok(subTaskDTO);
        }

        [HttpGet]
        public async Task<ActionResult> GetTaskByProductId(int projectId)
        {
            var task = await appDb.SubTasks
            .Where(s => s.ProjectId == projectId).ToListAsync();

            var subTaskDTO = task.Select(s => new SubTaskDTO
            {
                Id = s.Id,
                Description = s.Description,
                IsCompleted = s.IsCompleted,
                Duration = s.Duration,
                ProjectId = s.ProjectId
            }).ToList();

            return Ok(subTaskDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTaskById(int id, SubTaskDTO subTaskDTO)
        {
            var task = await appDb.SubTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            task.Description = subTaskDTO.Description;
            task.Duration = subTaskDTO.Duration;
            task.IsCompleted = subTaskDTO.IsCompleted;

            SubTaskDTO taskDTO = new SubTaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                Duration = task.Duration,
                IsCompleted = task.IsCompleted,
                ProjectId = task.ProjectId
            };
            await appDb.SaveChangesAsync();
            return Ok(taskDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskById(int id)
        {
            var task = await appDb.SubTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            appDb.SubTasks.Remove(task);
            await appDb.SaveChangesAsync();
            return NoContent();
        }
    }
}
