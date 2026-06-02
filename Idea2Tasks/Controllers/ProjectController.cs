using Idea2Tasks.Data;
using Idea2Tasks.DTO;
using Idea2Tasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idea2Tasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly AppDb appDb;

        public ProjectController(AppDb appDb)
        {
            this.appDb = appDb;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> AddProject(ProjectDTO projectDTO)
        {
            var project = new Project
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                IsCompleted = projectDTO.IsCompleted,
                SubTasks = projectDTO.SubTasks.Select(s => new SubTask
                {
                    Description = s.Description,
                    IsCompleted = s.IsCompleted,
                    Duration = s.Duration
                }).ToList()
            };

            await appDb.Projects.AddAsync(project);
            await appDb.SaveChangesAsync();

            var resultDTO = MapProjectToDTO(project);

            return CreatedAtAction(
                nameof(GetProject),
                new { id = project.Id },
                resultDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            var projects = await appDb.Projects
                .Include(p => p.SubTasks)
                .ToListAsync();

            var projectDTOs = projects.Select(MapProjectToDTO).ToList();

            return Ok(projectDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await appDb.Projects
                .Include(p => p.SubTasks)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return NotFound();

            return Ok(MapProjectToDTO(project));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectById(int id, ProjectDTO projectDTO)
        {
            var project = await appDb.Projects
                .Include(p => p.SubTasks)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return NotFound();

            project.Name = projectDTO.Name;
            project.Description = projectDTO.Description;
            project.IsCompleted = projectDTO.IsCompleted;

            await appDb.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectById(int id)
        {
            var project = await appDb.Projects.FindAsync(id);

            if (project == null)
                return NotFound();

            appDb.Projects.Remove(project);
            await appDb.SaveChangesAsync();

            return NoContent();
        }

        private static ProjectDTO MapProjectToDTO(Project project)
        {
            return new ProjectDTO
            {
                Name = project.Name,
                Description = project.Description,
                IsCompleted = project.IsCompleted,
                SubTasks = project.SubTasks.Select(s => new SubTaskDTO
                {
                    Id = s.Id,
                    Description = s.Description,
                    IsCompleted = s.IsCompleted,
                    Duration = s.Duration,
                    ProjectId = s.ProjectId
                }).ToList()
            };
        }
    }
}