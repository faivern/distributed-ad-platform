using AdSystem.Data;
using AdSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AdSystem.Services
{
    public class AdvertiserService : IAdvertiserService
    {
        private readonly AdsDbContext _context;


        public AdvertiserService(AdsDbContext context)
        {
            _context = context;
        }
        public async Task<Advertisers> CreateAdvertiserAsync(AdFormViewModel model)
        {
            var advertiser = new Advertisers
            {
                AdvType = model.IsCompany ? "COMPANY" : "SUBSCRIBER",
                AdvFirstName = model.FirstName,
                AdvLastName = model.LastName,
                AdvOrgNumber = model.IsCompany ? model.OrgNumber : null,
                AdvPhone = model.Phone,
                AdvZipCode = model.ZipCode,
                AdvAddress = model.DeliveryAddress,
                AdvCity = model.City,
                AdvInvoiceAddress = model.IsCompany ? (model.InvoiceAddress ?? model.DeliveryAddress) : null,
                AdvInvoiceZipCode = model.IsCompany ? (model.InvoiceZipCode ?? model.ZipCode) : null,
                AdvInvoiceCity = model.IsCompany ? (model.InvoiceCity ?? model.City) : null
            };

            _context.Advertisers.Add(advertiser);
            await _context.SaveChangesAsync();
            return advertiser;
        }
    }
}
