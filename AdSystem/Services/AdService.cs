using AdSystem.Data;
using AdSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AdSystem.Services
{
    public class AdService : IAdsService
    {
        private readonly AdsDbContext _context;
        public AdService(AdsDbContext context)
        {
            _context = context;
        }
        public async Task<Ads> CreateAdAsync(AdFormViewModel model)
        {
            decimal advertisingCompanyPrice = 40m;

            var ad = new Ads
            {
                AdTitle = model.Title,
                AdDescription = model.Description,
                AdItemPrice = model.ItemPrice,
                AdAdvertisingPrice = advertisingCompanyPrice,
                AdCreatedAt = DateTime.UtcNow
            };

            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return ad;
        }
        public async Task<List<Ads>> GetAllAdsAsync()
        {
            return await _context.Ads.ToListAsync();
        }
    }
}
