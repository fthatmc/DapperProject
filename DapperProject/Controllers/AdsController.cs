using DapperProject.Services.AdServices;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DapperProject.Controllers
{
    public class AdsController : Controller
	{
		private readonly IAdService _adService;

		public AdsController(IAdService adService)
		{
			_adService = adService;
		}

		public async Task<IActionResult>  Index(int page = 1)
		{
			var values = await _adService.GetAllAdWithOtherAsync();
			return View(values.ToPagedList(page, 6));
		}

		public async Task<IActionResult> AdDetail(int id)
		{
			var value = await _adService.GetGetByIdAdAsync(id);
			return View(value);
		}
	}
}
