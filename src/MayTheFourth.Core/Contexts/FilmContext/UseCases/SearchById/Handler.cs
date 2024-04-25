using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IFilmRepository _filmRepository;
    public Handler(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        //TODO: Need to implement validation system
        #endregion

        #region Search film by id
        Film? film;
        try
        {
            film = await _filmRepository.GetByIdAsync(request.Id, cancellationToken);
            if(film == null)
                return new Response("Erro: Filme não encontrado.", ((int)HttpStatusCode.NotFound));
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }

        FilmDetailsDto filmDetails = new(film);
        #endregion

        #region Response
        return new Response("Filme encontrado com sucesso.", new ResponseData(filmDetails));
        #endregion
    }
}
