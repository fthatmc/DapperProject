using DapperProject.Dtos.AdDtos;

namespace DapperProject.Services.AdServices
{
    public interface IAdService
    {
        Task<List<ResultAdDto>> GetAllAdWithOtherAsync();
        Task<List<ResultLast4AdsDto>> GetLast4AdsAsync();
        Task<List<ResultResentAdPostDto>> GetResentAdPostAsync();
		Task<int> GetAdCount();
        Task<GetByIdAdDto> GetGetByIdAdAsync(int id);
    }
}
