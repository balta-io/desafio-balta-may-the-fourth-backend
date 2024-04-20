using FluentValidation;
using MediatR;

namespace MayTheFourth.Application.Features.Filmes.DeleteFilmes
{
    public sealed record DeleteFilmesRequest(int FilmeId) : IRequest;

    public class DeleteFilmesRequestValidator : AbstractValidator<DeleteFilmesRequest>
    {
        public DeleteFilmesRequestValidator()
        {
            RuleFor(x => x.FilmeId).NotEmpty().NotNull();
        }
    }
}
