using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AgentDtos;
using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.SliderServices
{
	public class SliderService : ISliderService
	{
		private readonly DapperContext _context;

		public SliderService(DapperContext context)
		{
			_context = context;
		}

		public async Task<List<ResultSliderDto>> GetAllSliderAsync()
		{
			string query = "Select * From TblSlider";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultSliderDto>(query);
			return values.ToList();
		}
	}
}
