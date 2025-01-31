using ClubManagementAPI.DTO;
using ClubManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymClassController : ControllerBase
    {
        private readonly IGymClassService _gymClassService;

        public GymClassController(IGymClassService gymClassService)
        {
            _gymClassService = gymClassService;
        }

        [HttpPost("createClass")]

        public async Task<IActionResult> CreateGymClass([FromBody] GymClassDTO gymClassDto)
        {
            var response = await _gymClassService.CreateGymClassAsync(gymClassDto);

            return StatusCode(response.StatusCode, response);
        }
    }
}
























































