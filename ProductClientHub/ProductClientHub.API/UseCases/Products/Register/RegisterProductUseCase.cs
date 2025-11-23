using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Products.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute( Guid clientId,RequestsProductJson request)
        {
            var dbContext = new ProductClientsHubDbContext();
            Validate(dbContext, clientId, request);
            var entity = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId
            };

            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public void Validate(ProductClientsHubDbContext dbContext, Guid clientId,RequestsProductJson request)
        {
            var clientExist = dbContext.Clients.Any(client => client.Id == clientId);
            if (!clientExist)
            {
                throw new NotFoundException("Cliente não existe");
            }
            var validator = new RequestProductValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure=>failure.ErrorMessage).ToList();
                // Handle validation failures
                throw new ErrorOnValidationException(errors);
            }

        }

    }
}
