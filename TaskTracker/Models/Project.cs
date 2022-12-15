using System.ComponentModel.DataAnnotations;
using TaskTracker.Models.Enums;

namespace TaskTracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus? Status { get; set; } = ProjectStatus.NotStarted;
        [Required]
        public int Priority { get; set; }
    }
}
