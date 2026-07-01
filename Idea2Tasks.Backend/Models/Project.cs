using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.Backend.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }
        public bool IsCompleted { get; set; } = false;

        public List<SubTask>? SubTasks { get; set; }
    }
}