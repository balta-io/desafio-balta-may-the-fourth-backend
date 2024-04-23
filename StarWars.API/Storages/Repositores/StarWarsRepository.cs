using System;
using Microsoft.EntityFrameworkCore;
using StarWars.API.Models;
using StarWars.API.Storages.Datas;

namespace StarWars.API.Storages.Repositores
{
    public class StarWarsRepository : IStarWarsRepository
    {
        private readonly StarWarsContext _context;

        public StarWarsRepository(StarWarsContext context)
        {
            _context = context;
        }

        public async Task<MovieModel?> CreateMovie(MovieModel model, CancellationToken cancellationToken = default)
        {
            _context.Movies.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<List<MovieModel>>? GetMoviesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _context.Movies.ToListAsync(cancellationToken);

            return response;
        }
    }
}

