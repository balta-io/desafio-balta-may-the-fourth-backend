using Microsoft.EntityFrameworkCore;
using Staris.Application.Data;

namespace Staris.Infra.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var response = await base.SaveChangesAsync(cancellationToken);
        return response;
    }
}
