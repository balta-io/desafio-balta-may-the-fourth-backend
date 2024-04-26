using MediatR;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchBySlug;

public record Request(string Slug) : IRequest<Response>;
