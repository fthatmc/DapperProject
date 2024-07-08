using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._AdminComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
