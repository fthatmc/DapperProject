using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AdDtos;
using DapperProject.Dtos.CategoryDtos;
using DapperProject.Dtos.TagDtos;

namespace DapperProject.Services.AdServices
{
    public class AdService : IAdService
    {
        private readonly DapperContext _context;

        public AdService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateAdAsync(CreateAdDto createAdDto)
        {
            string query = "Insert Into TblAds (AdTitle,Desciption,Price,Garage,SquareMeter,BedRooms,BathRooms,BuildAge,BuildYear,Description1,Description2,IsResent,CategoryId,ImageId,LocationId,AdStiuationId,TagId,ImageURL,VideoUrl) values " +
                "(@AdTitle,@Desciption,@Price,@Garage,@SquareMeter,@BedRooms,@BathRooms,@BuildAge,@BuildYear,@Description1,@Description2,@IsResent,@CategoryId,@ImageId,@LocationId,@AdStiuationId,@TagId,@ImageURL,@VideoUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@AdTitle", createAdDto.AdTitle);
            parameters.Add("@Desciption", createAdDto.Desciption);
            parameters.Add("@Price", createAdDto.Price);
            parameters.Add("@Garage", createAdDto.Garage);
            parameters.Add("@SquareMeter", createAdDto.SquareMeter);
            parameters.Add("@BedRooms", createAdDto.BedRooms);
            parameters.Add("@BathRooms", createAdDto.BathRooms);
            parameters.Add("@BuildAge", createAdDto.BuildAge);
            parameters.Add("@BuildYear", createAdDto.BuildYear);
            parameters.Add("@Description1", createAdDto.Description1);
            parameters.Add("@Description2", createAdDto.Description2);
            parameters.Add("@IsResent", createAdDto.IsResent);
            parameters.Add("@CategoryId", createAdDto.CategoryId);
            parameters.Add("@ImageId", createAdDto.ImageId);
            parameters.Add("@LocationId", createAdDto.LocationId);
            parameters.Add("@AdStiuationId", createAdDto.AdStiuationId);
            parameters.Add("@TagId", createAdDto.TagId);
            parameters.Add("@ImageURL", createAdDto.ImageURL);
            parameters.Add("@VideoUrl", createAdDto.VideoUrl);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAdAsync(int id)
        {
            string query = "Delete From TblAds Where AdId=@AdId";
            var parameters = new DynamicParameters();
            parameters.Add("@AdId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetAdCount()
		{
			string query = "Select Count(*) From TblAds";
			var connection = _context.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;
		}

		public async Task<List<ResultAdDto>> GetAllAdWithOtherAsync()
        {
            string query = "Select AdId,AdTitle,Desciption,Price,Garage,BuildYear,SquareMeter,BedRooms,BathRooms,BuildAge,Description1,Description2,VideoUrl,ImageURL,IsResent,CategoryName,location,AdStiuation,TagName From TblAds INNER JOIN TblLocation On TblLocation.LocationId = TblAds.LocationId INNER JOIN  TblTag On TblTag.TagId = TblAds.TagId INNER JOIN TblCategory On TblCategory.CategoryId = TblAds.CategoryId INNER JOIN TblStiuation On TblStiuation.AdStiuationId = TblAds.AdStiuationId";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultAdDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdAdDto> GetGetByIdAdAsync(int id)
        {
            string query = "Select AdId,AdTitle,Desciption,Price,Garage,BuildYear,SquareMeter,BedRooms,BathRooms,BuildAge,Description1,Description2,VideoUrl,ImageURL,IsResent,CategoryName,location,AdStiuation,TagName,Image1,Image2,Image3,Image4,Image5,Tag1,Tag2,Tag3,Tag4,Tag5 From TblAds INNER JOIN TblLocation On TblLocation.LocationId = TblAds.LocationId INNER JOIN  TblTag On TblTag.TagId = TblAds.TagId INNER JOIN TblCategory On TblCategory.CategoryId = TblAds.CategoryId INNER JOIN TblStiuation On TblStiuation.AdStiuationId = TblAds.AdStiuationId INNER JOIN TblImage On TblImage.ImageId = TblAds.ImageId Where AdId=@AdId";
            var parameters = new DynamicParameters();
            parameters.Add("@AdId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdAdDto>(query, parameters);
            return values;
        }

        public async Task<List<ResultLast4AdsDto>> GetLast4AdsAsync()
		{
			string query = "Select top 4 AdId,AdTitle,Desciption,Price,SquareMeter,BathRooms,BedRooms,ImageURL,CategoryName,Location,AdStiuation FROM TblAds INNER JOIN  TblLocation ON TblLocation.LocationId = TblAds.LocationId INNER JOIN TblStiuation ON TblStiuation.AdStiuationId = TblAds.AdStiuationId INNER JOIN  TblCategory ON TblCategory.CategoryId = TblAds.CategoryId Order by AdId Desc";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultLast4AdsDto>(query);
			return values.ToList();
		}

		public async Task<List<ResultResentAdPostDto>> GetResentAdPostAsync()
		{
			string query = "Select AdId,AdTitle,Price,ImageURL,CategoryName,AdStiuation FROM TblAds INNER JOIN TblStiuation ON TblStiuation.AdStiuationId = TblAds.AdStiuationId INNER JOIN  TblCategory ON TblCategory.CategoryId = TblAds.CategoryId where IsResent=1";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultResentAdPostDto>(query);
			return values.ToList();
		}

        public async Task IsRecentFalse(int id)
        {
            string query = "Update TblAds set IsResent=0 where AdId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task IsRecentTrue(int id)
        {
            string query = "Update TblAds set IsResent=1 where AdId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultAdDto>> ResultAdSearchAync(int locationId, int categoryId, int adStiuationId)
		{
			string query = "Select AdId,AdTitle,Desciption,Price,Garage,BuildYear,SquareMeter,BedRooms,BathRooms,BuildAge, ImageURL ,CategoryName,location,AdStiuation From TblAds INNER JOIN TblLocation On TblLocation.LocationId = TblAds.LocationId INNER JOIN TblCategory On TblCategory.CategoryId = TblAds.CategoryId INNER JOIN TblStiuation On TblStiuation.AdStiuationId = TblAds.AdStiuationId Where TblAds.LocationId =@locationId And TblAds.AdStiuationId =@AdStiuationId And TblAds.CategoryId =@CategoryId";
			var parameters = new DynamicParameters();
			parameters.Add("@LocationId", locationId);
			parameters.Add("@AdStiuationId", adStiuationId);
			parameters.Add("@CategoryId", categoryId);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultAdDto>(query, parameters);
				return values.ToList();
			}
		}

        public async Task UpdateAdAsync(UpdateAdDto updateAdDto)
        {
            string query = "Update TblAds Set AdTitle=@AdTitle,Desciption=@Desciption,Price=@Price,Garage=@Garage,SquareMeter=@SquareMeter,BedRooms=@BedRooms" +
                ",BathRooms=@BathRooms,BuildAge=@BuildAge,BuildYear=@BuildYear,Description1=@Description1,Description2=@Description2,IsResent=@IsResent,CategoryId=@CategoryId" +
                ",ImageId=@ImageId,LocationId=@LocationId,AdStiuationId=@AdStiuationId,TagId=@TagId,ImageURL=@ImageURL,VideoUrl=@VideoUrl Where AdId=@AdId";
            var parameters = new DynamicParameters();
            parameters.Add("@AdTitle", updateAdDto.AdTitle);
            parameters.Add("@Desciption", updateAdDto.Desciption);
            parameters.Add("@Price", updateAdDto.Price);
            parameters.Add("@Garage", updateAdDto.Garage);
            parameters.Add("@SquareMeter", updateAdDto.SquareMeter);
            parameters.Add("@BedRooms", updateAdDto.BedRooms);
            parameters.Add("@BathRooms", updateAdDto.BathRooms);
            parameters.Add("@BuildAge", updateAdDto.BuildAge);
            parameters.Add("@BuildYear", updateAdDto.BuildYear);
            parameters.Add("@Description1", updateAdDto.Description1);
            parameters.Add("@Description2", updateAdDto.Description2);
            parameters.Add("@IsResent", updateAdDto.IsResent);
            parameters.Add("@CategoryId", updateAdDto.CategoryId);
            parameters.Add("@ImageId", updateAdDto.ImageId);
            parameters.Add("@LocationId", updateAdDto.LocationId);
            parameters.Add("@AdStiuationId", updateAdDto.AdStiuationId);
            parameters.Add("@TagId", updateAdDto.TagId);
            parameters.Add("@ImageURL", updateAdDto.ImageURL);
            parameters.Add("@VideoUrl", updateAdDto.VideoUrl);
            parameters.Add("@AdId", updateAdDto.AdId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
