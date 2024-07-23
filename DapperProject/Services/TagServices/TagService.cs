using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.TagDtos;

namespace DapperProject.Services.TagServices
{
    public class TagService : ITagService
    {
        private readonly DapperContext _context;

        public TagService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateTagAsync(CreateTagDto createTagDto)
        {
            string query = "insert into TblTag (TagName,Tag1,Tag2,Tag3,Tag4,Tag5) values (@TagName,@Tag1,@Tag2,@Tag3,@Tag4,@Tag5)";
            var parameters = new DynamicParameters();
            parameters.Add("@TagName", createTagDto.TagName);
            parameters.Add("@Tag1", createTagDto.Tag1);
            parameters.Add("@Tag2", createTagDto.Tag2);
            parameters.Add("@Tag3", createTagDto.Tag3);
            parameters.Add("@Tag4", createTagDto.Tag4);
            parameters.Add("@Tag5", createTagDto.Tag5);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTagAsync(int id)
        {
            string query = "Delete From TblTag Where TagId=@TagId";
            var parameters = new DynamicParameters();
            parameters.Add("@TagId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTagDto>> GetAllTagAsync()
        {
            string query = "Select * From TblTag";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdTagDto> GetTagAsync(int id)
        {
            string query = "Select * From TblTag Where TagId=@TagId";
            var parameters = new DynamicParameters();
            parameters.Add("@TagId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdTagDto>(query, parameters);
            return values;
        }

        public async Task UpdateTagAsync(UpdateTagDto updateTagDto)
        {
            string query = "Update TblTag Set TagName=@TagName,Tag1=@Tag1,Tag2=@Tag2,Tag3=@Tag3,Tag4=@Tag4,Tag5=@Tag5 where TagId=@TagId";
            var parameters = new DynamicParameters();
            parameters.Add("@TagName", updateTagDto.TagName);
            parameters.Add("@Tag1", updateTagDto.Tag1);
            parameters.Add("@Tag2", updateTagDto.Tag2);
            parameters.Add("@Tag3", updateTagDto.Tag3);
            parameters.Add("@Tag4", updateTagDto.Tag4);
            parameters.Add("@Tag5", updateTagDto.Tag5);
            parameters.Add("@TagId", updateTagDto.TagId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
