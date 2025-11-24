using Microsoft.AspNetCore.Mvc;
using AdSystem.Services;
using AdSystem.Models;

namespace AdSystem.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdsService _adsService;
        private readonly ExchangeRateService _exchangeRateService;

        public AdsController(IAdsService adsService, ExchangeRateService exchangeRateService)
        {
            _adsService = adsService;
            _exchangeRateService = exchangeRateService;
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

        // handle form post for creating an ad
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdFormViewModel model)
        {
            // If its NOT a company, ignore OrgNumber validation
            if (!model.IsCompany)
            {
                ModelState.Remove(nameof(model.OrgNumber));
            }
            else if (string.IsNullOrWhiteSpace(model.OrgNumber))
            {
                ModelState.AddModelError(nameof(model.OrgNumber), "Organisationsnummer är obligatoriskt för företag.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _adsService.CreateAdAsync(model);
            return RedirectToAction("Index", "Ads");
        }


    }
}
