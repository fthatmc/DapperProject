using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AgentDtos;
using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServcies
{
	public class TestimonialService : ITestimonialService
	{
		private readonly DapperContext _context;

		public TestimonialService(DapperContext context)
		{
			_context = context;
		}

		public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
		{
			string query = "Select * From TblTestimonial";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultTestimonialDto>(query);
			return values.ToList();
		}
	}
}
