using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchAll
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IFilmRepository _filmRepository;

        public Handler(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            #region GetAllFilms
            List<Film>? films;
            int totalRecords;
            try
            {
                (films, totalRecords) = await _filmRepository.GetAllAsync(request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return new Response($"Erro: {ex.Message}", 500);
            }

            List<FilmSummaryDto> filmSummaryList = films.Select(film => new FilmSummaryDto(film)).ToList();
            #endregion

            #region Response
            return new Response("Lista de filmes encontrada", new ResponseData(new(filmSummaryList), totalRecords));
            #endregion
        }
    }
}
