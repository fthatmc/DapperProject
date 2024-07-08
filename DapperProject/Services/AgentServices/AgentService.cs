using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AdDtos;
using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
	public class AgentService : IAgentService
	{
		private readonly DapperContext _context;

		public AgentService(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> GetAgentCount()
		{
			string query = "Select Count(*) From TblAgent";
			var connection = _context.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;
		}

		public async Task<List<AgentDtos>> GetAllAgentsAsync()
		{
			string query = "Select * From TblAgent";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<AgentDtos>(query);
			return values.ToList();
		}
	}
}
