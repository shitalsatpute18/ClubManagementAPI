using Dapper;
using Microsoft.Data.SqlClient;
using ClubManagementAPI.Interfaces;

namespace ClubManagementAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> IsClassFullAsync(int gymClassId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Bookings WHERE GymClassId = @GymClassId";
                int bookingCount = await connection.ExecuteScalarAsync<int>(query, new { GymClassId = gymClassId });

                // class capacity is checked based on the GymClass table
                string capacityQuery = "SELECT Capacity FROM GymClasses WHERE Id = @GymClassId";
                int capacity = await connection.ExecuteScalarAsync<int>(capacityQuery, new { GymClassId = gymClassId });

                return bookingCount >= capacity;
            }
        }

        public async Task<bool> IsBookingExistsAsync(int gymClassId, int memberId, DateTime participationDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Bookings WHERE GymClassId = @GymClassId AND MemberId = @MemberId AND ParticipationDate = @ParticipationDate";
                int count = await connection.ExecuteScalarAsync<int>(query, new { GymClassId = gymClassId, MemberId = memberId, ParticipationDate = participationDate });
                return count > 0;
            }
        }

        public async Task<int> CreateBookingAsync(int gymClassId, int memberId, DateTime participationDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Bookings (GymClassId, MemberId, ParticipationDate) VALUES (@GymClassId, @MemberId, @ParticipationDate); SELECT SCOPE_IDENTITY();";
                return await connection.ExecuteScalarAsync<int>(query, new { GymClassId = gymClassId, MemberId = memberId, ParticipationDate = participationDate });
            }
        }
    }
}
