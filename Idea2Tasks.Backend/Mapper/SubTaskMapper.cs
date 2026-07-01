using Idea2Tasks.Backend.DTO;
using Idea2Tasks.Backend.Models;

namespace Idea2Tasks.Backend.Mapper
{
    public static class SubTaskMapper
    {
        public static SubTaskDTO? ToSubTaskDTO(this SubTask subTask)
        {
            SubTaskDTO subTaskDTO = new()
            {
                Id = subTask.Id,
                ProjectId = subTask.ProjectId,
                Description = subTask.Description,
                DurationInHrs = subTask.DurationInHrs,
                IsCompleted = subTask.IsCompleted,
            };
            return subTaskDTO;
        }

        public static SubTask ToSubTask(this SubTaskDTO dto)
        {
            return new SubTask
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                Description = dto.Description,
                DurationInHrs = dto.DurationInHrs,
                IsCompleted = dto.IsCompleted,
            };
        }
    }
}