using GamingOrganization.API.Entities;
using GamingOrganization.API.UseCases.Users.SharedValidator;
using GamingOrganization.Exceptions.ExceptionsBase;
using GammingOrganization.Communication.Requests.User;
using GammingOrganization.Communication.Responses.User;

namespace GamingOrganization.API.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseShortUserJson Execute(RequestUserJson request)
        {
            Validate(request);
            var entity = new User{
                Name = request.Name,
                Email = request.Email,
            };

            return new ResponseShortUserJson { Id = entity.Id,Name = entity.Name };
        }

        private void Validate(RequestUserJson request)
        {
            var validator = new RequestUserValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
