namespace ClubManagementAPI.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> IsClassFullAsync(int gymClassId);
        Task<bool> IsBookingExistsAsync(int gymClassId, int memberId, DateTime participationDate);
        Task<int> CreateBookingAsync(int gymClassId, int memberId, DateTime participationDate);
    }
}
