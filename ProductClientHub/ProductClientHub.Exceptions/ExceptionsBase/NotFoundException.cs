using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public class NotFoundException: ProductClientHubExceptions
        
    {
        public NotFoundException(string ErrorMessage) : base(ErrorMessage)
        {
        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;


    }
}
