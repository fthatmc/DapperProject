using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UIResentPostComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
