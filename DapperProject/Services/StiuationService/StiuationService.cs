using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.StiuationDtos;

namespace DapperProject.Services.StiuationService
{
	public class StiuationService : IStiuationService
	{
		private readonly DapperContext _context;

		public StiuationService(DapperContext context)
		{
			_context = context;
		}

		public async Task<List<ResultStiuationDto>> GetAllStiuationAsync()
		{
			string query = "Select * From TblStiuation";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultStiuationDto>(query);
			return values.ToList();
		}
	}
}
