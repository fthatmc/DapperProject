using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServcies
{
	public interface ITestimonialService
	{
		Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
	}
}
