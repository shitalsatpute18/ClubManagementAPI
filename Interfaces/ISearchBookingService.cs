using ClubManagementAPI.Common;
using ClubManagementAPI.DTO;

namespace ClubManagementAPI.Interfaces
{
    public interface ISearchBookingService
    {
        Task<APIResponse<List<SearchBookingResultDTO>>> SearchBookingsAsync(SearchBookingDTO criteria);
    }
}
