using Idea2Tasks.Backend.DTO;
using Idea2Tasks.Backend.Mapper;
using Idea2Tasks.Backend.Models;
using Idea2Tasks.Backend.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Idea2Tasks.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubTaskController : ControllerBase
    {
        private readonly ISubTaskRepo _subTaskRepo;

        public SubTaskController(ISubTaskRepo subTaskRepo)
        {
            _subTaskRepo = subTaskRepo;
        }

        [HttpPost]
        public async Task<ActionResult<SubTaskDTO>> CreateTask([FromQuery] int projectId, [FromBody] SubTaskDTO subTaskDTO)
        {
            var subTask = subTaskDTO.ToSubTask();
            subTask.ProjectId = projectId != 0 ? projectId : subTaskDTO.ProjectId;

            var createdTask = await _subTaskRepo.AddSubTaskAsync(subTask);
            if (createdTask is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetTasksById), new { id = createdTask.Id }, createdTask.ToSubTaskDTO());
        }

        [HttpGet]
        public async Task<ActionResult<List<SubTaskDTO>>> GetAllTasks()
        {
            var tasks = await _subTaskRepo.GetAllAsync();
            return Ok(tasks.Select(task => task.ToSubTaskDTO()).Where(task => task is not null).Select(task => task!).ToList());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubTaskDTO>> GetTasksById(int id)
        {
            var task = await _subTaskRepo.GetByIdAsync(id);
            if (task is null)
            {
                return NotFound();
            }

            return Ok(task.ToSubTaskDTO());
        }

        [HttpGet("p/{projectId:int}")]
        public async Task<ActionResult<List<SubTaskDTO>>> GetTaskByProjectId(int projectId)
        {
            var tasks = await _subTaskRepo.GetAllAsync();
            var projectTasks = tasks
                .Where(task => task.ProjectId == projectId)
                .Select(task => task.ToSubTaskDTO())
                .Where(task => task is not null)
                .Select(task => task!)
                .ToList();

            return Ok(projectTasks);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SubTaskDTO>> Update(int id, SubTaskDTO subTaskDTO)
        {
            var task = await _subTaskRepo.UpdateAsync(id, subTaskDTO.ToSubTask());
            if (task is null)
            {
                return NotFound();
            }

            return Ok(task.ToSubTaskDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _subTaskRepo.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
