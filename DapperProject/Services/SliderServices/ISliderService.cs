using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.SliderServices
{
	public interface ISliderService
	{
		Task<List<ResultSliderDto>> GetAllSliderAsync();
		Task CreateSliderAsync(CreateSliderDto createSliderDto);
		Task DeleteSliderAsync(int id);
		Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
		Task<GetByIdSliderDto> GetSliderAsync(int id);
	}
}
