using DapperProject.Services.AdServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.StiuationService;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class DefaultController : Controller
    {
        
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;
        private readonly IStiuationService _stiuationService;
		private readonly IAdService _adService;

		public DefaultController(ICategoryService categoryService, ILocationService locationService, IStiuationService stiuationService, IAdService adService)
		{
			_categoryService = categoryService;
			_locationService = locationService;
			_stiuationService = stiuationService;
			_adService = adService;
		}

		public async Task<IActionResult> Index()
        {
			ViewBag.location = await _locationService.GetAllLocationAsync();
			ViewBag.category = await _categoryService.GetAllCategoryAsync();
			ViewBag.stiuation = await _stiuationService.GetAllStiuationAsync();
			return View();
		}

		[HttpPost]
		public IActionResult Index(int locationId, int categoryId, int adStiuationId)
		{

			
			TempData["locationId"] = locationId;
			TempData["categoryId"] = categoryId;
			TempData["adStiuationId"] = adStiuationId;
			return RedirectToAction("Search", "Default");
		}

		public async Task<IActionResult> Search()
		{

			var values = await _adService.ResultAdSearchAync(Convert.ToInt32(TempData["locationId"].ToString()), Convert.ToInt32(TempData["categoryId"].ToString()), Convert.ToInt32(TempData["adStiuationId"].ToString()));
			return View(values);

		}
	}
}


