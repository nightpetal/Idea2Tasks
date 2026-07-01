using Idea2Tasks.Backend.DTO;
using Idea2Tasks.Backend.Mapper;
using Idea2Tasks.Backend.Models;
using Idea2Tasks.Backend.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> CreateTask(int projectId, SubTaskDTO subTaskDTO)
        {
            SubTask subTask = subTaskDTO.ToSubTask();

            await _subTaskRepo.AddSubTaskAsync(subTask);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {
            return Ok(await _subTaskRepo.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTasksById(int id)
        {
            var task = await _subTaskRepo.GetByIdAsync(id);
            if (task is null)
                return BadRequest();
            SubTaskDTO? subTaskDTO = task.ToSubTaskDTO();
            return Ok(subTaskDTO);
        }

        [HttpGet("p/{projectId:int}")]
        public async Task<ActionResult> GetTaskByProductId(int projectId)
        {
            var task = await _subTaskRepo.GetAllAsync();
            var projectTasks = task.Select(s => s.ProjectId == projectId).ToList();

            return Ok(projectTasks);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SubTaskDTO subTaskDTO)
        {
            var task = await _subTaskRepo.UpdateAsync(id, subTaskDTO.ToSubTask());
            if (task == null)
            {
                return NotFound();
            }
            return Ok(subTaskDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var task = await _subTaskRepo.DeleteAsync(id);
            if (!task)
                return NotFound();
            return NoContent();
        }
    }
}
