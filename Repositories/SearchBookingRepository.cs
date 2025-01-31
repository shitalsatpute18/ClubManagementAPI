using ClubManagementAPI.Data;
using ClubManagementAPI.DTO;
using ClubManagementAPI.Interfaces;
using Dapper;


namespace ClubManagementAPI.Repositories
{
    public class SearchBookingRepository : ISearchBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public SearchBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SearchBookingResultDTO>> SearchBookingsAsync(SearchBookingDTO criteria)
        {
            var sql = @"
                SELECT 
                    b.Id AS BookingId,
                    g.Name AS GymClassName,
                    g.StartTime AS StartTime,
                    b.ParticipationDate AS ParticipationDate,
                    m.Name AS MemberName
                FROM Bookings b
                INNER JOIN GymClasses g ON b.GymClassId = g.Id
                INNER JOIN Members m ON b.MemberId = m.Id
                WHERE (@MemberName IS NULL OR m.Name = @MemberName)
                AND (@StartDate IS NULL OR b.ParticipationDate >= @StartDate)
                AND (@EndDate IS NULL OR b.ParticipationDate <= @EndDate)
                ORDER BY b.ParticipationDate";

            using (var connection = _context.CreateConnection())
            {
                var bookings = await connection.QueryAsync<SearchBookingResultDTO>(sql, new
                {
                    criteria.MemberName,
                    criteria.StartDate,
                    criteria.EndDate
                });

                return bookings.ToList();
            }
        }
    }
}
