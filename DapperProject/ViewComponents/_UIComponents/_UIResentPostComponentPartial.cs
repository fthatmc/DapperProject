using DapperProject.Services.AdServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UIResentPostComponentPartial : ViewComponent
	{
		private readonly IAdService _adService;

		public _UIResentPostComponentPartial(IAdService adService)
		{
			_adService = adService;
		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _adService.GetResentAdPostAsync();
			return View(values);
		}
	}
}
