using DapperProject.Dtos.SliderDtos;
using DapperProject.Dtos.TestimonialDtos;
using DapperProject.Services.TestimonialServcies;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestiomonialDto createTestiomonialDto)
        {
            await _testimonialService.CreateTestimonialAsync(createTestiomonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _testimonialService.GetTestimonialByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("Index");
        }
    }
}
