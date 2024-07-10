using DapperProject.Dtos.LocationDtos;

namespace DapperProject.Services.LocationServices
{
	public interface ILocationService
	{
		Task<List<ResultLocationDto>> GetAllLocationAsync();
		Task<int> GetLocationCount();
	}
}
