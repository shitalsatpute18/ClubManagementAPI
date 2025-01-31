using ClubManagementAPI.DTO;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Common;
using System.Linq;

namespace ClubManagementAPI.Services
{
    public class SearchBookingService : ISearchBookingService
    {
        private readonly ISearchBookingRepository _searchBookingRepository;

        public SearchBookingService(ISearchBookingRepository searchBookingRepository)
        {
            _searchBookingRepository = searchBookingRepository;
        }

        public async Task<APIResponse<List<SearchBookingResultDTO>>> SearchBookingsAsync(SearchBookingDTO criteria)
        {
            var bookings = await _searchBookingRepository.SearchBookingsAsync(criteria);

            if (bookings == null || !bookings.Any())
            {
                return new APIResponse<List<SearchBookingResultDTO>>(404, false, "No bookings found.", null);
            }

            return new APIResponse<List<SearchBookingResultDTO>>(200, true, "Bookings found successfully.", bookings);
        }
    }
}
