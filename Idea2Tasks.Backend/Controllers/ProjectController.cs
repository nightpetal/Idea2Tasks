using System.Text.Json;
using Idea2Tasks.Backend.DTO;
using Idea2Tasks.Backend.Mapper;
using Idea2Tasks.Backend.Models;
using Idea2Tasks.Backend.Repositories.Interface;
using Idea2Tasks.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idea2Tasks.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _projectRepo;
        private readonly GeminiService _geminiService;

        public ProjectController(IProjectRepo projectRepo, GeminiService geminiService)
        {
            _projectRepo = projectRepo;
            _geminiService = geminiService;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> AddProject(ProjectOnlyDTO projectDTO)
        {
            var project = new Project
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                IsCompleted = projectDTO.IsCompleted,
                SubTasks = []
            };

            try
            {
                var generatedContent = await _geminiService.GenerateProjectTasksAsync(project.Name, project.Description);
                generatedContent = generatedContent.Replace("```json", "").Replace("```", "").Trim();

                var aiSubTasks = JsonSerializer.Deserialize<List<SubTaskDTO>>(generatedContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (aiSubTasks is not null)
                {
                    project.SubTasks = aiSubTasks.Select(s => new SubTask
                    {
                        Description = s.Description,
                        IsCompleted = s.IsCompleted,
                        DurationInHrs = s.DurationInHrs
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var createdProject = await _projectRepo.AddProjectAsync(project);
            return Ok(createdProject?.ToProjectDTO());
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> GetAllProjects()
        {
            var projects = await _projectRepo.GetAllAsync();
            return Ok(projects.Select(project => project.ToProjectDTO()).ToList());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDTO>> GetById(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project is null)
            {
                return NotFound();
            }

            return Ok(project.ToProjectDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProjectDTO>> Update(int id, ProjectOnlyDTO projectDTO)
        {
            var project = await _projectRepo.UpdateAsync(id, new Project
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                IsCompleted = projectDTO.IsCompleted
            });

            if (project is null)
            {
                return NotFound();
            }

            return Ok(project.ToProjectDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _projectRepo.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}