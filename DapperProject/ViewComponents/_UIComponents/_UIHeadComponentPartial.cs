using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UIHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
