using DapperProject.Services.AdServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UILast4PostComponentPartial : ViewComponent
	{
		private readonly IAdService _adService;

		public _UILast4PostComponentPartial(IAdService adService)
		{
			_adService = adService;
		}

		
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _adService.GetLast4AdsAsync();
			return View(values);
		}
		
	}
}
