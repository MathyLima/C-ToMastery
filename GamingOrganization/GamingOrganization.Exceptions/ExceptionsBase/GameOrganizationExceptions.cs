using System.Net;

namespace GamingOrganization.Exceptions.ExceptionsBase
{
    public abstract class GameOrganizationExceptions:SystemException
    {
        public GameOrganizationExceptions(string ErrorMessage):base(ErrorMessage) { }
        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();

    }
}
