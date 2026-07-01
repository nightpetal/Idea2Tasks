using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = String.Empty;
        [Required]
        public bool IsCompleted { get; set; } = false;

        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
    }
}