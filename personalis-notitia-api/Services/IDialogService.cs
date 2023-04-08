using personalis_notitia_api.Models;
using personalis_notitia_api.Requests;

namespace personalis_notitia_api.Services;

public interface IDialogService
{
    Task<string> GetDialogResponseAsync(DialogRequest request);

    Task<IEnumerable<Dialog>> GetDialogHistory();
}