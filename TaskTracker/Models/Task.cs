using System.ComponentModel.DataAnnotations.Schema;
using TaskTracker.Models.Enums;

namespace TaskTracker.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.ToDo;
        public string? Description { get; set; }
        public int Priority { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
    }
}
