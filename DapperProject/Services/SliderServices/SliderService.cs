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

		public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
		{
			string query = "insert into TblSlider (Address,Title,Description,ImageURL,Price) values (@Address,@Title,@Description,@ImageURL,@Price)";
			var parameters = new DynamicParameters();
			parameters.Add("@Address", createSliderDto.Address);
			parameters.Add("@Title", createSliderDto.Title);
			parameters.Add("@Description", createSliderDto.Description);
			parameters.Add("@ImageURL", createSliderDto.ImageURL);
			parameters.Add("@Price", createSliderDto.Price);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task DeleteSliderAsync(int id)
		{
			string query = "Delete From TblSlider Where SliderId=@SliderId";
			var parameters = new DynamicParameters();
			parameters.Add("@SliderId", id);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultSliderDto>> GetAllSliderAsync()
		{
			string query = "Select * From TblSlider";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultSliderDto>(query);
			return values.ToList();
		}

		public async Task<GetByIdSliderDto> GetSliderAsync(int id)
		{
			string query = "Select * From TblSlider Where SliderId=@SliderId";
			var parameters = new DynamicParameters();
			parameters.Add("@SliderId", id);
			var connection = _context.CreateConnection();
			var values = await connection.QueryFirstOrDefaultAsync<GetByIdSliderDto>(query, parameters);
			return values;
		}

		public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
		{
			string query = "Update TblSlider Set Title=@Title,Address=@Address,Description=@Description,ImageURL=@ImageURL,Price=@Price where SliderId=@SliderId";
			var parameters = new DynamicParameters();
			parameters.Add("@Title", updateSliderDto.Title);
			parameters.Add("@Address", updateSliderDto.Address);
			parameters.Add("@Description", updateSliderDto.Description);
			parameters.Add("@ImageURL", updateSliderDto.ImageURL);
			parameters.Add("@Price", updateSliderDto.Price);
			parameters.Add("@SliderId", updateSliderDto.SliderId);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}
	}
}
