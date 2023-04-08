using PN.API.Requests;
using PN.Domain.Models;

namespace PN.API.Services;

public interface IDialogService
{
    Task<string> GetDialogResponseAsync(DialogRequest request);

    Task<IEnumerable<Dialog>> GetDialogHistory();
}