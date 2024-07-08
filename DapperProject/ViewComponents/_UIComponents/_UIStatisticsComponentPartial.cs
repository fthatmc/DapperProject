using DapperProject.Services.AdServices;
using DapperProject.Services.AgentServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UIStatisticsComponentPartial : ViewComponent
	{
		private readonly ICategoryService _categoryService;
		private readonly IAdService _adService;
		private readonly IAgentService _agentService;
		private readonly ILocationService _locationService;

		public _UIStatisticsComponentPartial(ICategoryService categoryService, IAdService adService, IAgentService agentService, ILocationService locationService)
		{
			_categoryService = categoryService;
			_adService = adService;
			_agentService = agentService;
			_locationService = locationService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.c = await _categoryService.GetCategoryCount();
			ViewBag.l = await _locationService.GetLocationCount();
			ViewBag.agnt = await _agentService.GetAgentCount();
			ViewBag.ad = await _adService.GetAdCount();
			return View();
		}
	}
}
