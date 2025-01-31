using ClubManagementAPI.Models;

namespace ClubManagementAPI.Interfaces
{
    public interface IGymClassRepository
    {
        Task<int> CreateGymClassAsync(GymClass gymClass);
        Task<bool> IsClassAvailableAsync(DateTime startDate, TimeSpan startTime);
    }
}


