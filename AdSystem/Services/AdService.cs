using AdSystem.Data;
using AdSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace AdSystem.Services
{
    public class AdService : IAdsService
    {
        private readonly AdsDbContext _context;
        private readonly IAdvertiserService _advertiserService;
        public AdService(AdsDbContext context, IAdvertiserService advertiserService)
        {
            _context = context;
            _advertiserService = advertiserService;
        }
        public async Task<Ads> CreateAdAsync(AdFormViewModel model)
        {
            // fee depending on advertiser type

            var advertiser = await _advertiserService.CreateAdvertiserAsync(model);

            var ad = new Ads
            {
                AdTitle = model.Title,
                AdDescription = model.Description,
                AdItemPrice = model.ItemPrice,
                AdAdvertisingPrice = model.IsCompany ? 40m : 0m,
                AdCreatedAt = DateTime.UtcNow,
                AdvId = advertiser.AdvId

            };

            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return ad;
        }
        public async Task<List<Ads>> GetAllAdsAsync()
        {
            return await _context.Ads
                .Include(a => a.Advertiser)
                .ToListAsync();
        }
    }
}
