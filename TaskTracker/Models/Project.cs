using TaskTracker.Models.Enums;

namespace TaskTracker.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;
        public int Priority { get; set; }
    }
}
