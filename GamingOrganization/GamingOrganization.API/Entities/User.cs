namespace GamingOrganization.API.Entities
{
    public class User:EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double Experience { get; set; }
        public List<UserTask> Tasks { get; set; } = [];
    }
}
