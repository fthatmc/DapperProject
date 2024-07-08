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

        public async Task<List<ResultAdDto>> GetAllAdWithOtherAsync()
        {
            string query = "Select AdId,AdTitle,Desciption,Price,Garage,BuildYear,SquareMeter,BedRooms,BathRooms,BuildAge,Description1,Description2,VideoUrl,ImageURL,IsRentorSale,CategoryName,location,AdStiuation,TagName From TblAds INNER JOIN TblLocation On TblLocation.LocationId = TblAds.LocationId INNER JOIN  TblTag On TblTag.TagId = TblAds.TagId INNER JOIN TblCategory On TblCategory.CategoryId = TblAds.CategoryId INNER JOIN TblStiuation On TblStiuation.AdStiuationId = TblAds.AdStiuationId";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultAdDto>(query);
            return values.ToList();
        }

		public async Task<List<ResultLast4AdsDto>> GetLast4AdsAsync()
		{
			string query = "Select top 4 AdId,AdTitle,Desciption,Price,SquareMeter,BathRooms,BedRooms,ImageURL,CategoryName,Location,AdStiuation FROM TblAds INNER JOIN  TblLocation ON TblLocation.LocationId = TblAds.LocationId INNER JOIN TblStiuation ON TblStiuation.AdStiuationId = TblAds.AdStiuationId INNER JOIN  TblCategory ON TblCategory.CategoryId = TblAds.CategoryId Order by AdId Desc";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultLast4AdsDto>(query);
			return values.ToList();
		}
	}
}
