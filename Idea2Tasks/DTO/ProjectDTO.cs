using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.DTO
{
    public class ProjectDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = String.Empty;
        [Required]
        public bool IsCompleted { get; set; } = false;

        public ICollection<SubTaskDTO> SubTasks { get; set; } = new List<SubTaskDTO>();
    }
}