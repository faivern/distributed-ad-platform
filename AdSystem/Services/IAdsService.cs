using AdSystem.Data;
using AdSystem.Models;
namespace AdSystem.Services
{
    public interface IAdsService
    {
        Task<Ads> CreateAdAsync(AdFormViewModel model);
        Task<List<Ads>> GetAllAdsAsync();


    }
}
