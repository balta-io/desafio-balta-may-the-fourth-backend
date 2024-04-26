using MediatR;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchBySlug;

public record Request(string Slug) : IRequest<Response>;
