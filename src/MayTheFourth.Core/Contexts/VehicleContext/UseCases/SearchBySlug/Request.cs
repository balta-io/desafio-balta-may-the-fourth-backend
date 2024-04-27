using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchBySlug;

public record Request(string Slug) : IRequest<Response>;