using GammingOrganization.Communication.Requests;

namespace GammingOrganization.Communication.Responses.User
{
    public class ResponseAllUserJson
    {
        public List<ResponseShortUserJson> Users { get; set; } = [];
    }
}
