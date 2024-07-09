using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


//listelemler bitti, id ye ve filtreye göre sayfalar yapılacak

//sonra crud işlemler