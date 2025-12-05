using FluentValidation;
using GammingOrganization.Communication.Requests.User;

namespace GamingOrganization.API.UseCases.Users.SharedValidator
{
    public class RequestUserValidator:AbstractValidator<RequestUserJson>
    {
        public RequestUserValidator() {
            RuleFor(client => client.Name).NotEmpty().WithMessage("O nome do usuário não pode ser vazio");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O e-mail não é válido");
        }
    }
}
