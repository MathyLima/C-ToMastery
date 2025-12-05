using GamingOrganization.API.Enums;

namespace GamingOrganization.API.Entities
{
    public class UserTask:EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public UserTasksLevelEnum TaskLevel { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
