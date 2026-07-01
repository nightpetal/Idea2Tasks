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
                var generatedContent =
                    await _geminiService.GenerateProjectTasksAsync(
                        project.Name,
                        project.Description
                    );

                generatedContent = generatedContent
                    .Replace("```json", "")
                    .Replace("```", "")
                    .Trim();


                Console.WriteLine($"Gemini Response:\n{generatedContent}");
                var aiSubTasks = JsonSerializer.Deserialize<List<SubTaskDTO>>(
                    generatedContent,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (aiSubTasks != null)
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

            await _projectRepo.AddProjectAsync(project);

            return Ok(project.ToProjectDTO());
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> GetAllProjects()
        {
            var projects = await _projectRepo.GetAllAsync();
            var projectDTOs = projects.Select(s => s.ToProjectDTO()).ToList();
            return Ok(projectDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> Get(int id)
        {
            return Ok(await _projectRepo.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProjectOnlyDTO projectDTO)
        {
            Project proj = new Project
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                IsCompleted = projectDTO.IsCompleted,
            };
            var project = await _projectRepo.UpdateAsync(id, proj);

            if (project is null)
                return NotFound();
            return Ok(projectDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool flag = await _projectRepo.DeleteAsync(id);
            if (!flag)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}