using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator:AbstractValidator<RequestsProductJson>
    {
        public RequestProductValidator()
        {
            RuleFor(product=>product.Name).NotEmpty().WithMessage("O nome do produto não pode ser vazio."); 
            RuleFor(product=>product.Brand).NotEmpty().WithMessage("A marca do produto não pode ser vazia.");
            RuleFor(product => product.Price).GreaterThanOrEqualTo(0).WithMessage("O preço do produto não pode ser negativo");
        }
    }
}
