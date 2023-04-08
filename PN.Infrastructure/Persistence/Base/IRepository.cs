using PN.Domain.Models.Base;

namespace PN.Infrastructure.Persistence.Base;

public interface IRepository<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
}