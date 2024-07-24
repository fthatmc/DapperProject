using DapperProject.Dtos.DataDtos;

namespace DapperProject.Services.DataServices
{
    public interface IDataService
    {
        Task<List<ResultDataDto>> GetAllDataAsync();
        Task<int> GetCarCount();
        Task<int> GetSedanCount();
        Task<int> GetHatcbackCount();
        Task<int> GetOffRoadCount();
        Task<int> GetBrandCount();
        Task<int> GetDizelCount();
        Task<int> GetHighModel();
        Task<int> GetAutomaticCarCount();
        
    }
}
