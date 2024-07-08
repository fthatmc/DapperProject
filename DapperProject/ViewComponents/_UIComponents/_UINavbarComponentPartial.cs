using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UINavbarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
