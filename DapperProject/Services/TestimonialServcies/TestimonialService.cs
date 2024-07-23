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

		public async Task CreateTestimonialAsync(CreateTestiomonialDto createTestimonialDto)
		{
			string query = "insert into TblTestimonial (NameSurname,Description,ImageUrl) values (@NameSurname,@Description,@ImageUrl)";
			var parameters = new DynamicParameters();
			parameters.Add("@NameSurname", createTestimonialDto.NameSurname);
			parameters.Add("@Description", createTestimonialDto.Description);
			parameters.Add("@ImageUrl", createTestimonialDto.ImageUrl);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task DeleteTestimonialAsync(int id)
		{
			string query = "Delete From TblTestimonial Where TestimonialId=@TestimonialId";
			var parameters = new DynamicParameters();
			parameters.Add("@TestimonialId", id);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
		{
			string query = "Select * From TblTestimonial";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultTestimonialDto>(query);
			return values.ToList();
		}

		public async Task<GetByIdTestimonialDto> GetTestimonialByIdAsync(int id)
		{
			string query = "Select * From TblTestimonial Where TestimonialId=@TestimonialId";
			var parameters = new DynamicParameters();
			parameters.Add("@TestimonialId", id);
			var connection = _context.CreateConnection();
			var values = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
			return values;
		}

		public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
		{
			string query = "Update TblTestimonial Set NameSurname=@NameSurname,Description=@Description,ImageUrl=@ImageUrl where TestimonialId=@TestimonialId";
			var parameters = new DynamicParameters();
			parameters.Add("@NameSurname", updateTestimonialDto.NameSurname);
			parameters.Add("@Description", updateTestimonialDto.Description);
			parameters.Add("@ImageUrl", updateTestimonialDto.ImageUrl);
			parameters.Add("@TestimonialId", updateTestimonialDto.TestimonialId);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}
	}
}
