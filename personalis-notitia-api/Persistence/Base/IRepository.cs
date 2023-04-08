using personalis_notitia_api.Models.Base;

namespace personalis_notitia_api.Persistence.Base;

public interface IRepository<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
}