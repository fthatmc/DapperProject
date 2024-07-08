
using Dapper;
using DapperProject.Context;

namespace DapperProject.Services.LocationServices
{
	public class LocationService : ILocationService
	{
		private readonly DapperContext _context;

		public LocationService(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> GetLocationCount()
		{
			string query = "Select Count(*) From TblLocation";
			var connection = _context.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;
		}
	}
}
