using DapperProject.Dtos.AdDtos;
using DapperProject.Dtos.CategoryDtos;

namespace DapperProject.Services.AdServices
{
    public interface IAdService
    {
        Task<List<ResultAdDto>> GetAllAdWithOtherAsync();
        Task<List<ResultLast4AdsDto>> GetLast4AdsAsync();
        Task<List<ResultResentAdPostDto>> GetResentAdPostAsync();
		Task<int> GetAdCount();
	}
}
