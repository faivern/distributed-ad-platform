using AdSystem.Data;
using AdSystem.Models;
namespace AdSystem.Services
{
    public interface IAdvertiserService
    {
        Task<Advertisers> CreateAdvertiserAsync(AdFormViewModel model);
    }
}
