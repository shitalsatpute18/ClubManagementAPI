using ClubManagementAPI.Common;
using ClubManagementAPI.DTO;

namespace ClubManagementAPI.Interfaces
{
    public interface IBookingService
    {
        Task<APIResponse<BookingDTO>> CreateBookingAsync(BookingDTO bookingDto);
    }
}
