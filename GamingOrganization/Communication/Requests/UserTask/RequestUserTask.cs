namespace GammingOrganization.Communication.Requests.UserTask
{
    public class RequestUserTaskJson
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public List<RequestSubTaskJson> SubTasks { get; set; } = [];
    }
}
