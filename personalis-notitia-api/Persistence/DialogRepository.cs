using Microsoft.Extensions.Options;
using MongoDB.Driver;
using personalis_notitia_api.Models;
using personalis_notitia_api.Options;
using personalis_notitia_api.Persistence.Base;

namespace personalis_notitia_api.Persistence;

public class DialogRepository : Repository<Dialog>, IDialogRepository
{
    private readonly IMongoCollection<Dialog> _collection;

    public DialogRepository(IMongoClient client, IOptions<DatabaseOptions> options) : base(client, options)
    {
        _collection = base.GetCollection();
    }
}