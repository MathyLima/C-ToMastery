using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public abstract class ProductClientHubExceptions:SystemException
    {
        public ProductClientHubExceptions(string ErrorMessage):base(ErrorMessage)
        {
        }
        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
