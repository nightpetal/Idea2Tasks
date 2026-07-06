using System.ComponentModel.DataAnnotations;

namespace Idea2Tasks.Backend.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        [Required]
        public int DurationInHrs { get; set; }

        public int ProjectId { get; set; }
    }
}