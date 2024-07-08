using DapperProject.Services.TestimonialServcies;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.ViewComponents._UIComponents
{
	public class _UITestimonialComponentPartial : ViewComponent
	{
		private readonly ITestimonialService _testimonialService;

		public _UITestimonialComponentPartial(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _testimonialService.GetAllTestimonialAsync();
			return View(values);
		}
	}
}
