namespace MayTheFouthBackend.Domain.Interfaces.IRepositories;

public interface IUnitOfWord
{
    Task Commit(CancellationToken cancellationToken);
}
