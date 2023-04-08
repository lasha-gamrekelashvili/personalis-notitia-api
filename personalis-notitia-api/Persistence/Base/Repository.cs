using Microsoft.Extensions.Options;
using MongoDB.Driver;
using personalis_notitia_api.Models.Base;
using personalis_notitia_api.Options;

namespace personalis_notitia_api.Persistence.Base;

public class Repository<T> : IRepository<T> where T : BaseModel
{
    private readonly IMongoCollection<T> _collection;

    protected Repository(IMongoClient client, IOptions<DatabaseOptions> options)
    {
        var db = client.GetDatabase(options.Value.DatabaseName);
        _collection = db.GetCollection<T>(typeof(T).Name.ToLower());
    }

    protected IMongoCollection<T> GetCollection()
    {
        return _collection;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection
            .Find(MatchAll())
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    private static FilterDefinition<T> MatchAll()
    {
        var filters = new List<FilterDefinition<T>>
        {
            Builders<T>.Filter.Empty
        };

        return Builders<T>.Filter.And(filters);
    }
}