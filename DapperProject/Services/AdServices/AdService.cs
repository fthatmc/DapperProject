using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.AdDtos;
using DapperProject.Dtos.CategoryDtos;

namespace DapperProject.Services.AdServices
{
    public class AdService : IAdService
    {
        private readonly DapperContext _context;

        public AdService(DapperContext context)
        {
            _context = context;
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
	}
}
