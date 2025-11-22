using Microsoft.AspNetCore.Mvc;
using AdSystem.Services;
using AdSystem.Models;

namespace AdSystem.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdsService _adsService;
        public AdsController(IAdsService adsService)
        {
            _adsService = adsService;
        }

        // displays all ads
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ads = await _adsService.GetAllAdsAsync();
            return View(ads);
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
        [ValidateAntiForgeryToken] // prevents CSRF, just a good practice for form submissions
        public async Task<IActionResult> Create(AdFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _adsService.CreateAdAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }
    }
}
