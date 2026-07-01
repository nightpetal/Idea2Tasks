using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.Backend.DTO
{
    public class ProjectDTO
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }
        public bool IsCompleted { get; set; } = false;

        public int SubTaskDTOId { get; set; }
        public List<SubTaskDTO>? SubTaskDTO { get; set; }
    }
}