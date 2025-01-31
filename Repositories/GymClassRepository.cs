using ClubManagementAPI.Data;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models;
using Dapper;

namespace ClubManagementAPI.Repositories
{
    public class GymClassRepository : IGymClassRepository
    {
        private readonly ApplicationDbContext _context;

        public GymClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateGymClassAsync(GymClass gymClass)
        {
            var sql = @"
                INSERT INTO GymClasses (Name, StartDate, EndDate, StartTime, Duration, Capacity) 
                VALUES (@Name, @StartDate, @EndDate, @StartTime, @Duration, @Capacity);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, new
                {
                    gymClass.Name,
                    gymClass.StartDate,
                    gymClass.EndDate,
                    gymClass.StartTime,
                    gymClass.Duration,
                    gymClass.Capacity
                });
            }
        }

        public async Task<bool> IsClassAvailableAsync(DateTime startDate, TimeSpan startTime)
        {
            var sql = "SELECT COUNT(1) FROM GymClasses WHERE StartDate = @StartDate AND StartTime = @StartTime";

            using (var connection = _context.CreateConnection())
            {
                int count = await connection.ExecuteScalarAsync<int>(sql, new { startDate, startTime });
                return count == 0;
            }
        }

    }
}













