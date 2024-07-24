

using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.CategoryDtos;
using DapperProject.Dtos.DataDtos;

namespace DapperProject.Services.DataServices
{
    public class DataService : IDataService
    {
        private readonly DapperContext _context;

        public DataService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultDataDto>> GetAllDataAsync()
        {
            string query = "Select * From CarModels$";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultDataDto>(query);
            return values.ToList();
        }

        public async Task<int> GetAutomaticCarCount()
        {
            string query = "Select Count(*) From CarModels$  Where SHIFTTYPE like '%Automatic transmission%'";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GetBrandCount()
        {
            string query = "Select Count(DISTINCT BRAND) FROM CarModels$";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GetCarCount()
        {
            string query = "Select Count(*) From CarModels$";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GetDizelCount()
        {
            string query = "Select Count(*) From CarModels$ Where FUEL like '%Diesel%'";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GetHatcbackCount()
        {
            string query = "Select Count(*) From CarModels$ Where CASETYPE like '%Hatchback 5 Doors%'";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GetHighModel()
        {
            string query = "Select MAX(YEAR_) FROM CarModels$";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        

        public async Task<int> GetOffRoadCount()
        {
            string query = "Select Count(*) From CarModels$ Where CASETYPE like '%Off Road%'";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GetSedanCount()
        {
            string query = "Select Count(*) From CarModels$ Where CASETYPE like '%Sedan%'";
            var connection = _context.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }
    }
}
