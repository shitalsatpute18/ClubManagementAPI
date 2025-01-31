using ClubManagementAPI.Common;
using ClubManagementAPI.DTO;

namespace ClubManagementAPI.Interfaces
{
    public interface IGymClassService
    {
        Task<APIResponse<GymClassDTO>> CreateGymClassAsync(GymClassDTO gymClassDto);
    }
}
