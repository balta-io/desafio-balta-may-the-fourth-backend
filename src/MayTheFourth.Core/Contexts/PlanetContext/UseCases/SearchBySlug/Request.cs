using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchBySlug;

public record Request(string Slug) : IRequest<Response>;
