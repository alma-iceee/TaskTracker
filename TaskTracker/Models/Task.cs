using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public Enums.TaskStatus? Status { get; set; } = Enums.TaskStatus.ToDo;
        public string? Description { get; set; }
        [Required]
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
    }
}
