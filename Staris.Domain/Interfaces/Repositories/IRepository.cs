using Microsoft.EntityFrameworkCore;
using Staris.Domain.Common;

namespace Staris.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    public DbSet<T> Entity { get; init; }
}
