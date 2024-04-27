using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            PagedList<Film>? films;
            int countItems = 0;
            try
            {
                if (request.PageSize > 30) 
                    request.ChangePageSize(30);

                countItems = await _filmRepository.CountItemsAsync();
                films = await _filmRepository.GetAllAsync(request.PageNumber, request.PageSize);
                if (request.PageSize > films.Count)
                    films.ChangePageSize(countItems);
            }
            catch (Exception ex)
            {
                return new Response($"Erro: {ex.Message}", 500);
            }

            List<FilmSummaryDto> filmSummaryList = films.Items!.Select(film => new FilmSummaryDto(film)).ToList();
            
            PagedList<FilmSummaryDto> filmPagedSummaryList = 
                new PagedList<FilmSummaryDto>(films.PageNumber, films.PageSize, countItems, filmSummaryList);
          
            if (filmPagedSummaryList.PageNumber > Math.Ceiling((double)filmPagedSummaryList.Count / filmPagedSummaryList.PageSize))
            {
                return new Response($"Número de página inválido.", (int)HttpStatusCode.BadRequest);
            }
            #endregion

            #region Response
            return new Response("Lista de filmes encontrada", new ResponseData(filmPagedSummaryList));
            #endregion
        }
    }
}
