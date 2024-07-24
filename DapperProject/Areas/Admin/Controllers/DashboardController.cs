using DapperProject.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IDataService _dataService;

        public DashboardController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CarCount= await _dataService.GetCarCount();
            ViewBag.SedanCount = await _dataService.GetSedanCount();
            ViewBag.HatcbackCount = await _dataService.GetHatcbackCount();
            ViewBag.OffRoadCount = await _dataService.GetOffRoadCount();
            ViewBag.BrandCount = await _dataService.GetBrandCount();
            ViewBag.DieselCount = await _dataService.GetDizelCount();
            ViewBag.HighModel = await _dataService.GetHighModel();
            ViewBag.AutomaticCarCount = await _dataService.GetAutomaticCarCount();
            
            return View();
        }
    }
}
