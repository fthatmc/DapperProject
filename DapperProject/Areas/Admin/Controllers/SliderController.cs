using DapperProject.Dtos.LocationDtos;
using DapperProject.Dtos.SliderDtos;
using DapperProject.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _sliderService.CreateSliderAsync(createSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _sliderService.GetSliderAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return RedirectToAction("Index");
        }
    }
}
