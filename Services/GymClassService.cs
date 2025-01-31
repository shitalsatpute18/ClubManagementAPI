using ClubManagementAPI.Common;
using ClubManagementAPI.DTO;
using ClubManagementAPI.Models;
using ClubManagementAPI.Interfaces;

namespace ClubManagementAPI.Services
{
    public class GymClassService : IGymClassService
    {
        private readonly IGymClassRepository _gymClassRepository;

        public GymClassService(IGymClassRepository gymClassRepository)
        {
            _gymClassRepository = gymClassRepository;
        }

        public async Task<APIResponse<GymClassDTO>> CreateGymClassAsync(GymClassDTO gymClassDto)
        {
            if (gymClassDto.Capacity < 1)
                return new APIResponse<GymClassDTO>(400, false, "Capacity must be at least 1.", null);

            if (gymClassDto.EndDate <= DateTime.Now)
                return new APIResponse<GymClassDTO>(400, false, "End date must be in the future.", null);

            bool isAvailable = await _gymClassRepository.IsClassAvailableAsync(gymClassDto.StartDate, gymClassDto.StartTime);
            if (!isAvailable)
                return new APIResponse<GymClassDTO>(400, false, "A class already exists at this date and time.", null);

            var gymClass = new GymClass
            {
                Name = gymClassDto.Name,
                StartDate = gymClassDto.StartDate,
                EndDate = gymClassDto.EndDate,
                StartTime = gymClassDto.StartTime,
                Duration = gymClassDto.Duration,
                Capacity = gymClassDto.Capacity
            };

            int classId = await _gymClassRepository.CreateGymClassAsync(gymClass);
            var createdGymClassDto = new GymClassDTO
            {
                Name = gymClass.Name,
                StartDate = gymClass.StartDate,
                EndDate = gymClass.EndDate,
                StartTime = gymClass.StartTime,
                Duration = gymClass.Duration,
                Capacity = gymClass.Capacity
            };

            return new APIResponse<GymClassDTO>(200, true, "Gym class created successfully.", createdGymClassDto);
        }
    }
}













