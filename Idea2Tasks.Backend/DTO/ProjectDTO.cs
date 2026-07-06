using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.Backend.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        public List<SubTaskDTO>? SubTasks { get; set; }
    }
}