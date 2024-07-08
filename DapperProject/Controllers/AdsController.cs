using DapperProject.Services.AdServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class AdsController : Controller
	{
		private readonly IAdService _adService;

		public AdsController(IAdService adService)
		{
			_adService = adService;
		}

		public async Task<IActionResult>  Index()
		{
			var values = await _adService.GetAllAdWithOtherAsync();
			return View(values);
		}

		public IActionResult AdDetail(int id)
		{
			return View();
		}
	}
}
