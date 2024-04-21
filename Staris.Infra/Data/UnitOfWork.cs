using Microsoft.EntityFrameworkCore;
using Staris.Application.Data;

namespace Staris.Infra.Data;

public class UnitOfWork : DbContext, IUnitOfWork
{
    private ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.SaveChangesAsync(cancellationToken);
        return response;
    }
}
