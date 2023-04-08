using MongoDB.Driver;
using PN.Domain.Models;
using PN.Infrastructure.Options;
using PN.Infrastructure.Persistence.Base;

namespace PN.Infrastructure.Persistence;

public class DialogRepository : Repository<Dialog>, IDialogRepository
{
    private readonly IMongoCollection<Dialog> _collection;

    public DialogRepository(IMongoClient client, IDatabaseOptions options) : base(client, options)
    {
        _collection = base.GetCollection();
    }
}