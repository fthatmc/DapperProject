using DapperProject.Dtos.AdDtos;
using DapperProject.Dtos.AgentDtos;
using DapperProject.Services.AdServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.StiuationService;
using DapperProject.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdsController : Controller
    {
        private readonly IAdService _adsService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IStiuationService _stiuationService;

        public AdsController(IAdService adsService, ILocationService locationService, ICategoryService categoryService, ITagService tagService, IStiuationService stiuationService)
        {
            _adsService = adsService;
            _locationService = locationService;
            _categoryService = categoryService;
            _tagService = tagService;
            _stiuationService = stiuationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _adsService.GetAllAdWithOtherAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAds()
        {
            
            ViewBag.location = await _locationService.GetAllLocationAsync();
            ViewBag.category = await _categoryService.GetAllCategoryAsync();
            ViewBag.stiuation = await _stiuationService.GetAllStiuationAsync();
            ViewBag.tag = await _tagService.GetAllTagAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAds(CreateAdDto createAdDto)
        {
            await _adsService.CreateAdAsync(createAdDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAds(int id)
        {
            ViewBag.location = await _locationService.GetAllLocationAsync();
            ViewBag.category = await _categoryService.GetAllCategoryAsync();
            ViewBag.stiuation = await _stiuationService.GetAllStiuationAsync();
            ViewBag.tag = await _tagService.GetAllTagAsync();
            var value = await _adsService.GetGetByIdAdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAds(UpdateAdDto updateAdDto)
        {
            await _adsService.UpdateAdAsync(updateAdDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AdRecentTrue(int id)
        {
            await _adsService.IsRecentTrue(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AdRecentFalse(int id)
        {
            await _adsService.IsRecentFalse(id);
            return RedirectToAction("Index");
        }
    }
}
