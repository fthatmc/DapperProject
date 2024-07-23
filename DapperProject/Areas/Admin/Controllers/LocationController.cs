using DapperProject.Dtos.CategoryDtos;
using DapperProject.Dtos.LocationDtos;
using DapperProject.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _locationService.GetAllLocationAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            await _locationService.CreateLocationAsync(createLocationDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _locationService.GetByIdLocationAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            await _locationService.UpdateLocationAsync(updateLocationDto);
            return RedirectToAction("Index");
        }
    }
}
