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

            try
            {
                films = await _filmRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return new Response($"Erro: {ex.Message}", 500);
            }

            #endregion

            #region Response
                return new Response("Lista de filmes encontrada", new ResponseData(films!));
            #endregion
        }
    }
}
