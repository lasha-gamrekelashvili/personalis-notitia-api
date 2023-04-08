using Microsoft.Extensions.Options;
using MongoDB.Driver;
using personalis_notitia_api.Options;
using personalis_notitia_api.Persistence.Mongo;

namespace personalis_notitia_api.Persistence.Dialog;

public class DialogRepository : Repository<Models.Dialog>, IDialogRepository
{
    private readonly IMongoCollection<Models.Dialog> _collection;

    public DialogRepository(IMongoClient client, IOptions<DatabaseOptions> options) : base(client, options)
    {
        var db = client.GetDatabase(options.Value.DatabaseName);
        _collection = db.GetCollection<Models.Dialog>(nameof(Models.Dialog).ToLower());
    }
}