using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._AdminComponents
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
