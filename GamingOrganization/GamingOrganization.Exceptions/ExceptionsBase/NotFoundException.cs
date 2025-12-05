using GamingOrganization.Exceptions.ExceptionsBase;
using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public class NotFoundException : GameOrganizationExceptions

    {
        public NotFoundException(string ErrorMessage) : base(ErrorMessage)
        {
        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;


    }
}