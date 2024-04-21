using MayTheFouthBackend.Domain.Entities;

namespace MayTheFouthBackend.Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : Entity
    {
    }
}
