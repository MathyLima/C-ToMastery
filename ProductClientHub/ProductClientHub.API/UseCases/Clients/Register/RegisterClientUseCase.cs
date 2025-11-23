using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseShortClientJson Execute(RequestsClientJson request)
        {
            Validate(request);
            var dbContext = new ProductClientsHubDbContext();
            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email

            };

            dbContext.Clients.Add(entity);
            dbContext.SaveChanges();
            //Continua com a regra de negócio
            return new ResponseShortClientJson();
        }

        private void Validate(RequestsClientJson request)
        {
            var Validator = new RequestClientValidator();
            var result = Validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
