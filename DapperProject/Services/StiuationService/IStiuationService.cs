using DapperProject.Dtos.StiuationDtos;

namespace DapperProject.Services.StiuationService
{
	public interface IStiuationService
	{
		Task<List<ResultStiuationDto>> GetAllStiuationAsync();
	}
}
