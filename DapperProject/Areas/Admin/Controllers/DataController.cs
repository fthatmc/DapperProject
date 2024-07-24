using DapperProject.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataController : Controller
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _dataService.GetAllDataAsync();
            return View(value);
        }
    }
}
