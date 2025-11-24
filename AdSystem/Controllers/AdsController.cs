using Microsoft.AspNetCore.Mvc;
using AdSystem.Services;
using AdSystem.Models;

namespace AdSystem.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdsService _adsService;
        private readonly ExchangeRateService _exchangeRateService;
        private readonly SubscriberSyncService _subscriberSyncService;

        public AdsController(IAdsService adsService, ExchangeRateService exchangeRateService, SubscriberSyncService subscriberSyncService)
        {
            _adsService = adsService;
            _exchangeRateService = exchangeRateService;
            _subscriberSyncService = subscriberSyncService;
        }

        // displays all ads
        [HttpGet]
        public async Task<IActionResult> Index(string currency = "SEK")
        {
            var ads = await _adsService.GetAllAdsAsync();

            var vm = new AdsIndexViewModel
            {
                Ads = ads,
                SelectedCurrency = currency
                // AvailableCurrencies uses default
            };

            if (currency != "SEK")
            {
                vm.CurrentRate = await _exchangeRateService.GetSekToAsync(currency);
            }
            else
            {
                vm.CurrentRate = 1m;
            }

            return View(vm);
        }

        // display form for new advertisement creation
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdFormViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdFormViewModel model)
        {
            // Företag: OrgNumber krävs
            if (!model.IsCompany)
            {
                ModelState.Remove(nameof(model.OrgNumber));
            }
            else if (string.IsNullOrWhiteSpace(model.OrgNumber))
            {
                ModelState.AddModelError(nameof(model.OrgNumber),
                    "Organisationsnummer är obligatoriskt för företag.");
            }

            // 🔹 Prenumerant: SubscriberId krävs och måste finnas i API
            if (!model.IsCompany)
            {
                if (!model.SubscriberId.HasValue || model.SubscriberId.Value <= 0)
                {
                    ModelState.AddModelError(nameof(model.SubscriberId),
                        "Giltigt prenumerationsnummer krävs.");
                }
                else
                {
                    var exists = await _subscriberSyncService
                        .SubscriberExistsAsync(model.SubscriberId.Value);

                    if (!exists)
                    {
                        ModelState.AddModelError(nameof(model.SubscriberId),
                            "Angivet prenumerationsnummer finns inte i prenumerantsystemet.");
                    }
                }
            }
            else
            {
                // Företag: ignorera SubscriberId helt
                ModelState.Remove(nameof(model.SubscriberId));
            }

            if (!ModelState.IsValid)
                return View(model);

            // PUT till abonnentsystemet vid prenumerant
            if (!model.IsCompany && model.SubscriberId.HasValue)
            {
                var dto = new SubscriberUpdateDto
                {
                    SubscriberId = model.SubscriberId.Value,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SocialSecurity = model.SocialSecurity,
                    DeliveryAddress = model.DeliveryAddress,
                    ZipCode = model.ZipCode,
                    City = model.City,
                    Phone = model.Phone
                };

                await _subscriberSyncService.UpdateSubscriberAsync(dto);
            }

            await _adsService.CreateAdAsync(model);
            return RedirectToAction("Index", "Ads");
        }



    }
}
