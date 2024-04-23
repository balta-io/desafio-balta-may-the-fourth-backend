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

        public async Task<MoveModel?> CreateMove(MoveModel model, CancellationToken cancellationToken = default)
        {
            _context.Moves.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<List<MoveModel>>? GetMovesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _context.Moves.ToListAsync(cancellationToken);

            return response;
        }
    }
}

