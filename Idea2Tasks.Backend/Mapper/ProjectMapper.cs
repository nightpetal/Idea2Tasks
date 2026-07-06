using Idea2Tasks.Backend.Models;
using Idea2Tasks.Backend.DTO;

namespace Idea2Tasks.Backend.Mapper
{
    public static class ProjectMapper
    {
        public static ProjectDTO ToProjectDTO(this Project project)
        {
            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                IsCompleted = project.IsCompleted,
                SubTasks = project.SubTasks?.Select(s => new SubTaskDTO
                {
                    Id = s.Id,
                    Description = s.Description,
                    IsCompleted = s.IsCompleted,
                    ProjectId = s.ProjectId,
                    DurationInHrs = s.DurationInHrs,
                }).ToList() ?? []
            };
        }

        public static Project ToProject(this ProjectOnlyDTO dto)
        {
            return new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
            };
        }
    }
}