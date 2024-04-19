using FluentValidation;
using MediatR;

namespace MayTheFourth.Application.Features.BasicExample
{
    public class AddProductRequest : IRequest
    {
        public Guid ProductID { get; set; }
    }

    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.ProductID).NotEmpty().NotNull();
        }
    }
}
