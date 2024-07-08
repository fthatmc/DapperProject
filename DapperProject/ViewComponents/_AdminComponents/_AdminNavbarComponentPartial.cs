using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._AdminComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
