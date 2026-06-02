using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.DTO
{
    public class SubTaskDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = String.Empty;
        [Required]
        public bool IsCompleted { get; set; } = false;
        [Required]
        public int Duration { get; set; }

        public int ProjectId { get; set; }
    }
}