using DapperProject.Dtos.AdDtos;
using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AdServices
{
    public interface IAdService
    {
        Task<List<ResultAdDto>> GetAllAdWithOtherAsync();
        Task<List<ResultLast4AdsDto>> GetLast4AdsAsync();
        Task<List<ResultResentAdPostDto>> GetResentAdPostAsync();
		Task<int> GetAdCount();
        Task<GetByIdAdDto> GetGetByIdAdAsync(int id);
		Task<List<ResultAdDto>> ResultAdSearchAync(int locationId, int categoryId, int adStiuationId);
        Task CreateAdAsync(CreateAdDto createAgentDto);
        Task UpdateAdAsync(UpdateAdDto updateAgentDto);
        Task DeleteAdAsync(int id);
        Task IsRecentTrue(int id);
        Task IsRecentFalse(int id);
    }
}
