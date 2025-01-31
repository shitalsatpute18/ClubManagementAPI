using ClubManagementAPI.DTO;

namespace ClubManagementAPI.Interfaces
{
    public interface ISearchBookingRepository
    {
        Task<List<SearchBookingResultDTO>> SearchBookingsAsync(SearchBookingDTO criteria);
    }
}

